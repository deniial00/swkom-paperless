using NPaperless.SA;
using NPaperless.SA.Interfaces;

using RabbitMQ.Client;


var builder = WebApplication.CreateBuilder(args);
 
var host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((hostContext, services) =>
	{
		services.AddSingleton<IRabbitMQService>(
			new RabbitMQService(
				new ConnectionFactory{
					HostName = "swkom-mq",
					Port = 5672,
					UserName = "swkom-mq",
					Password = "swkom-mq"
				},
				"default"
			)
		);

		services.AddSingleton<IOCRService>(
			new OCRService(
				"ocr-trained-data/eng.traineddata",
				"eng"
			)
		);
		
		services.AddSingleton<IMinioService>(
			new MinioService(
				"swkom-minio",
				"swkom-minio",
				"swkom-minio",
				"swkom-minio",
				9000
		));


		services.AddHostedService<Worker>();
	}).Build();

host.Run();