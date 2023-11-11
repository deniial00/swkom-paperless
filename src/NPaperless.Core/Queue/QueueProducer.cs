using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using NPaperless.Core.Entities;

namespace NPaperless.Core.Queue;

public class QueueProducer : QueueClient
{
    private readonly ILogger<QueueProducer> _logger;

    public QueueProducer(IOptions<QueueOptions> options, ILogger<QueueProducer> logger)
    : base(options.Value.ConnectionString, options.Value.QueueName)
    {
        this._logger = logger;
    }

    public void Send(Document doc, Guid documentId)
    {
        _logger.LogInformation($"Sending message with id {documentId}");

        IBasicProperties properties = base.RabbitMqChannel.CreateBasicProperties();
        properties.CorrelationId = documentId.ToString();

        base.RabbitMqChannel.BasicPublish(exchange: ExchangeName,
                                     routingKey: $"{QueueName}.*",
                                     mandatory: false,
                                     basicProperties: properties,
                                     body: doc.ToBytes());
    }
}