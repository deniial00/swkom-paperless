using NPaperless.BL.Interfaces;
using FluentValidation;
using NPaperless.BL.Entities;
﻿using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using Microsoft.Extensions.Logging;



namespace NPaperless.BL {
	public class DocumentLogic : IDocumentLogic {
		private readonly IValidator<Document> _validator;
		private readonly IMinioClient _minioClient;
		private readonly ILogger<DocumentLogic> _logger;

        public DocumentLogic(IValidator<Document> validator, IMinioClient minioClient, ILogger<DocumentLogic> logger) {
            _validator = validator;
			_minioClient = minioClient;
			_logger = logger;
        }
		public async Task<bool> CreateDocument(Document newDocument, IEnumerable<IFormFile> documentFiles){

			
			var result = _validator.Validate(newDocument);
			string bucketName = "swkom-minio";

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
						var objectName = Guid.NewGuid().ToString(); // Generate a unique name for the file
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
					}
				}
				catch (MinioException e)
				{
					_logger.LogError("Error uploading file: ", e);
					throw new BLException("Error uploading file: ", e);
				}
				return true;
			}

			return false;
		}

		public string GetDocument(int id, int? page, bool? fullPerms){
			_logger.LogError("GetDocument is not implemented");
			throw new BLException("NotImplementedException");
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