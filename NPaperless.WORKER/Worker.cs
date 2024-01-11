using NPaperless.BL.Interfaces;
using NPaperless.SA.Interfaces;

using Minio;
using Minio.DataModel.Args;

namespace NPaperless.SA;

public class Worker : BackgroundService
{
    private readonly IRabbitMQService _queueService;
    private readonly IMinioService _minioService;
    private readonly IOCRService _ocrService;
    // private readonly IElasticSearchService _elasticSearchService;
    public Worker(
        IRabbitMQService queueService,
        IMinioService minioService,
        IOCRService ocrService)
    {
        _queueService = queueService;
        _minioService = minioService;
        _ocrService = ocrService;
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

        var fileContent = _ocrService.ScanDocument(doc);
        Console.WriteLine(fileContent);
        // await _elasticSearchService.IndexDocumentAsync();
        
        return 1;
    }
}