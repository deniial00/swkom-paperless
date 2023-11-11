using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NPaperless.Core.Entities;
using NPaperless.Core.Queue;

namespace NPaperless.Core.Services;

public class DocumentService
{
    private readonly QueueProducer _qProducer;

    public DocumentService(IOptions<QueueOptions> options, ILogger<QueueProducer> logger) {
        _qProducer = new QueueProducer(options, logger);
    }
    
    public Document ProcessDocument(IFormFile file){
        Document document;
            
        try {
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);

                var contentType = file.ContentType;
                var fileName = file.FileName;
                
                document = new Document(stream.ToArray(), contentType, fileName);

                _qProducer.Send(document, Guid.NewGuid());
            }
        }
        catch (DocumentNotReadableException e) {
            throw e;
        }
        catch (NullReferenceException e) {
            throw e;
        }

        return document;
    }
}