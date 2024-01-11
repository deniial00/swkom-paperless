using NPaperless.BL.Interfaces;
using NPaperless.SA.Interfaces;

using Minio;
using Minio.DataModel.Args;

namespace NPaperless.SA;

public class Worker : BackgroundService
{
    private readonly IRabbitMQService _queueService;
    private readonly IMinioService _minioService;
    public Worker(
        IRabbitMQService queueService,
        IMinioService minioService)
    {
        _queueService = queueService;
        _minioService = minioService;
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
                    await HandleJob((Guid) job);
                } else {
                    await Task.Delay(1000, stoppingToken);
                }

            } catch (Exception e) {
                await Task.Delay(500,stoppingToken);
            }
        }
    }

    private async Task<int> HandleJob(Guid guid) 
    {
        Console.WriteLine("New job with id: {0}",guid.ToString());
        var doc = await _minioService.GetDocument(guid.ToString());
        
        return 1;
    }
}
