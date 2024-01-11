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
using CommunityToolkit.HighPerformance;
using Microsoft.AspNetCore.WebUtilities;



namespace NPaperless.BL {
	public class DocumentLogic : IDocumentLogic {
		private readonly IValidator<Document> _validator;
		private readonly IMinioService _minioService;
		private readonly ILogger<DocumentLogic> _logger;
		private readonly IRabbitMQService _queueService;
		private readonly IDocumentRepository _dataAccess;
		private readonly IMapper _mapper;

        public DocumentLogic(
			IValidator<Document> validator,
			// IMinioClient minioClient,
			IMinioService minioService,
			ILogger<DocumentLogic> logger,
			IRabbitMQService rabbitMQService,
			IDocumentRepository dataAccess,
			IMapper mapper) {
            _validator = validator;
			_minioService = minioService;
			_logger = logger;
			_queueService = rabbitMQService;
			_dataAccess = dataAccess;
			_mapper = mapper;
        }
		public async Task<bool> CreateDocument(Document newDocument, IEnumerable<IFormFile> documentFiles){
						
			var result = _validator.Validate(newDocument);

            // if (true) {
            if (result.IsValid) {
				try
				{	
					// Upload a file to bucket.
					foreach (var file in documentFiles)
					{
						var guid = Guid.NewGuid();
						var objectName = guid.ToString(); // Generate a unique name for the file
						using (var stream = file.OpenReadStream())
						{
							await _minioService.UploadDocument(objectName, stream, file.ContentType);
							_logger.Log(LogLevel.Debug, "Uploaded file with guid '" + objectName + "'");
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