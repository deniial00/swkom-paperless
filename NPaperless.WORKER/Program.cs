using NPaperless.SA;
using NPaperless.SA.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using Minio;


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

		services.AddSingleton<IMinioClient>(
			new MinioClient()
				.WithEndpoint("swkom-minio", 9000)
				.WithCredentials("swkom-minio", "swkom-minio")
				.WithSSL(false)
				.Build()
		);

		services.AddHostedService<Worker>();
	}).Build();

host.Run();