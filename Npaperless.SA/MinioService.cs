using Minio;
using Minio.DataModel.Args;

namespace NPaperless.SA.Interfaces;
public class MinioService : IMinioService
{
	private readonly IMinioClient _minioClient;
	private readonly string _bucketName;
	public MinioService(string bucketName, string hostName, string accessKey, string secretKey, int port) {
		_minioClient = new MinioClient()
					.WithEndpoint(hostName, port)
					.WithCredentials(accessKey, secretKey)
					.WithSSL(false)
					.Build();
		_bucketName = bucketName;
	}
	public async Task UploadDocument(string objectName, Stream fileStream, string contentType) {
		
		await EnsureBucketExists();

		var putObjectArgs = new PutObjectArgs()
			.WithBucket(_bucketName)
			.WithObject(objectName)
			.WithStreamData(fileStream)
			.WithObjectSize(fileStream.Length)
			.WithContentType(contentType);

		await _minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
	}
	public async Task<Stream> GetDocument(string objectName) {
		
		await EnsureBucketExists();

		var statArgs = new StatObjectArgs()
				.WithBucket(_bucketName)
				.WithObject(objectName);
		var objectStat = await _minioClient.StatObjectAsync(statArgs).ConfigureAwait(false);

		if (objectStat == null) {
			throw new Exception();
		}

		var memoryStream = new MemoryStream();
		var getArgs = new GetObjectArgs()
			.WithBucket(_bucketName)
			.WithObject(objectName)
			.WithCallbackStream(s => s.CopyTo(memoryStream));

		await _minioClient.GetObjectAsync(getArgs).ConfigureAwait(false);

		memoryStream.Position = 0;
		return memoryStream;
	}
	public async Task DeleteDocument(string objectName){

		await EnsureBucketExists();
	}

	public async Task EnsureBucketExists() {
		// Make a bucket on the server, if not already present.
		var beArgs = new BucketExistsArgs()
			.WithBucket(_bucketName);
		bool found = await _minioClient.BucketExistsAsync(beArgs).ConfigureAwait(false);
		
		if (found)
			return;

		var mbArgs = new MakeBucketArgs()
			.WithBucket(_bucketName);

		await _minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
		// _logger.Log(LogLevel.Debug, "Created bucket because it did not exist yet"); // TODO: add logging 
		
	}
}
