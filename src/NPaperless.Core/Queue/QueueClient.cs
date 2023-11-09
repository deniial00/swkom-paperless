using RabbitMQ.Client;

namespace NPaperless.Core.Queue;
public abstract class QueueClient : IDisposable
{
    protected IConnection RabbitMqConnection = null!; // to get warning away -  var is initialized in InitRabbitMQ()
    protected IModel RabbitMqChannel = null!; // to get warning away -  var is initialized in InitRabbitMQ()
    private readonly string _url;
    protected string QueueName;
    protected string ExchangeName;
    private bool disposedValue;


    protected QueueClient(string url, string queueName)
    {
        if (string.IsNullOrEmpty(url))
        {
            throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));
        }

        if (string.IsNullOrEmpty(queueName))
        {
            throw new ArgumentException($"'{nameof(queueName)}' cannot be null or empty.", nameof(queueName));
        }

        this._url = url;

        this.QueueName = queueName;
        this.ExchangeName = $"{QueueName}.exchange";

        InitRabbitMQ();
    }

    private void InitRabbitMQ()
    {
        var factory = new ConnectionFactory() { Uri = new Uri(_url) };

        // create connection  
        RabbitMqConnection = factory.CreateConnection();

        // create channel  
        RabbitMqChannel = RabbitMqConnection.CreateModel();

        RabbitMqChannel.ExchangeDeclare(ExchangeName, ExchangeType.Topic);
        RabbitMqChannel.QueueDeclare(queue: QueueName,
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

        RabbitMqChannel.QueueBind(queue: QueueName,
                            exchange: ExchangeName,
                            routingKey: $"{QueueName}.*",
                            arguments: null);

        RabbitMqChannel.BasicQos(prefetchSize: 0,
                            prefetchCount: 1,
                            global: false);

        RabbitMqConnection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
    }

    public bool ConnectionIsWorking()
        {
            try
            {
                // Check if the RabbitMqConnection is open
                return RabbitMqConnection?.IsOpen == true;
            }
            catch (Exception)
            {
                // Handle any potential exceptions here
                return false;
            }
        }

    private void RabbitMQ_ConnectionShutdown(object? sender, ShutdownEventArgs e)
    {
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                this.RabbitMqConnection.Dispose();
                this.RabbitMqChannel.Dispose();
            }

            disposedValue = true;
        }
    }

    public void SetChannel(IModel model)
    {
        RabbitMqChannel = model;
    }
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
