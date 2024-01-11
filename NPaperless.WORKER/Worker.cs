using NPaperless.BL.Interfaces;
using NPaperless.SA.Interfaces;

using Minio;

namespace NPaperless.SA;

public class Worker : BackgroundService
{
    private readonly IRabbitMQService _queueService;
    private readonly IMinioClient _minioClient;
    public Worker(IRabbitMQService queueService, IMinioClient minioService) {
        _queueService = queueService;
        _minioClient = minioService;
    }   

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
         while (!stoppingToken.IsCancellationRequested)
        {
            try
            { 
                var job = _queueService.RetrieveJobFromQueue();

                // Das ist mega blöd das so zu machen.
                if (job != null) {
                    Console.WriteLine(job.ToString());
                } else {
                    await Task.Delay(1000, stoppingToken);
                }

            } catch (Exception e) {
                await Task.Delay(500,stoppingToken);
            }
        }
    }
}