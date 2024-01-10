using NPaperless.BL.Interfaces;
using FluentValidation;
using NPaperless.BL.Entities;
﻿using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;


namespace NPaperless.BL {
	public class DocumentLogic : IDocumentLogic {
		private readonly IValidator<Document> _validator;
		private readonly IMinioClient _minioClient;
        public DocumentLogic(IValidator<Document> validator, IMinioClient minioClient) {
            _validator = validator;
			_minioClient = minioClient;
        }
		public async Task<string> CreateDocument(Document newDocument, IEnumerable<IFormFile> documentFiles){

			
			var result = _validator.Validate(newDocument);
			string bucketName = "swkom-minio";

            if (true) {
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
						}
					}
				}
				catch (MinioException e)
				{
					throw new BLException("Error uploading file: ", e);
				}
			}

			return null;
		}

		public string GetDocument(int id, int? page, bool? fullPerms){
			throw new BLException("NotImplementedException");
		}
		public bool DeleteDocument(int id){
			throw new BLException("NotImplementedException");
		}
		public string UpdateDocument(){
			throw new BLException("NotImplementedException");
		}
	}
}