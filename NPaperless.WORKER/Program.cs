using NPaperless.SA;
using NPaperless.SA.Interfaces;

using RabbitMQ.Client;
using Minio;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
 
 var host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseUrls("http://0.0.0.0:8081/")
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
        });
    });