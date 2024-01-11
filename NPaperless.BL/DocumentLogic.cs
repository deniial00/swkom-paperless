using NPaperless.BL.Interfaces;
using NPaperless.SA.Interfaces;
using NPaperless.BL.Entities;
using NPaperless.DA.Interfaces;

using FluentValidation;
﻿using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using Microsoft.Extensions.Logging;
using Npgsql.TypeMapping;
using AutoMapper;



namespace NPaperless.BL {
	public class DocumentLogic : IDocumentLogic {
		private readonly IValidator<Document> _validator;
		private readonly IMinioClient _minioClient;
		private readonly ILogger<DocumentLogic> _logger;
		private readonly IRabbitMQService _queueService;
		private readonly IDocumentRepository _dataAccess;
		private readonly IMapper _mapper;

        public DocumentLogic(IValidator<Document> validator, IMinioClient minioClient, ILogger<DocumentLogic> logger, IRabbitMQService rabbitMQService, IDocumentRepository dataAccess, IMapper mapper) {
            _validator = validator;
			_minioClient = minioClient;
			_logger = logger;
			_queueService = rabbitMQService;
			_dataAccess = dataAccess;
			_mapper = mapper;
        }
		public async Task<bool> CreateDocument(Document newDocument, IEnumerable<IFormFile> documentFiles){

			
			var result = _validator.Validate(newDocument);
			string bucketName = "swkom-minio";

            // if (true) {
            if (result.IsValid) {
				try
				{
					// Make a bucket on the server, if not already present.
					var beArgs = new BucketExistsArgs()
						.WithBucket(bucketName);
					bool found = await _minioClient.BucketExistsAsync(beArgs).ConfigureAwait(false);
					if (!found)
					{
						var mbArgs = new MakeBucketArgs()
							.WithBucket(bucketName);
						await _minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
						_logger.Log(LogLevel.Debug, "Created bucket because it did not exist yet");
					}
					
					// Upload a file to bucket.
					foreach (var file in documentFiles)
					{
						var guid = Guid.NewGuid();
						var objectName = guid.ToString(); // Generate a unique name for the file
						using (var stream = file.OpenReadStream())
						{
							var putObjectArgs = new PutObjectArgs()
								.WithBucket(bucketName)
								.WithObject(objectName)
								.WithStreamData(stream)
								.WithObjectSize(stream.Length)
								.WithContentType(file.ContentType);

							await _minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
							_logger.Log(LogLevel.Debug, "Uploaded file with guid '" + objectName + "' to bucket '" + bucketName + "'");
						}

						// Send to queue for async processing of file
						_queueService.SendJobToQueue(guid);
					}
				}
				catch (MinioException e)
				{
					_logger.LogError("Error uploading file: ", e);
					throw new BLException("Error uploading file: ", e);
				}

				var daDocument = _mapper.Map<NPaperless.DA.Entities.Document>(newDocument);
				_dataAccess.Add(daDocument);

				return true;
			}

			return false;
		}

		public Document GetDocument(int id, int? page, bool? fullPerms){
			var daDocument = _mapper.Map<NPaperless.BL.Entities.Document>(_dataAccess.GetById(id));
			return daDocument;
		}
		public bool DeleteDocument(int id){
			_logger.LogError("DeleteDocument is not implemented");
			throw new BLException("NotImplementedException");
		}
		public string UpdateDocument(){
			_logger.LogError("UpdateDocument is not implemented");
			throw new BLException("NotImplementedException");
		}
	}
}