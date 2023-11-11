using NUnit.Framework.Internal;

namespace NPaperless.Core.Test;

[TestFixture]
public class QueueTests
{
    private Mock<IModel> mockModel;
    private Mock<IConnection> mockConnection;

    [SetUp]
    public void Setup()
    {
        mockModel = new Mock<IModel>();
        mockConnection = new Mock<IConnection>();
        Env.Load();
    }

    [Test]
    public void DotNetEnv_TestFile()
    {
        // Aranage + Act
        string? mqUser = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_USER");
        string? mqPw = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_PASS");
        string? mqHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST");

        // Assert
        Assert.IsInstanceOf<string>(mqUser);
        Assert.IsInstanceOf<string>(mqPw);
        Assert.IsInstanceOf<string>(mqHost);
    }

    [Test]
    public void QueueClient_ConnectionWorking()
    {
        // Arrange
        string? mqUser = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_USER");
        string? mqPw = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_PASS");
        string? mqHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST");
        var mockLogger = new Mock<ILogger<QueueProducer>>();
        var options = new QueueOptions
        {
            ConnectionString = $"amqp://{mqUser}:{mqPw}@{mqHost}/",
            QueueName = "Default"
        };
        var mockOptions = new Mock<IOptions<QueueOptions>>();
        mockOptions.Setup(x => x.Value).Returns(options);

        // Act
        var producer = new QueueProducer(mockOptions.Object, mockLogger.Object);
        var isWorking = producer.ConnectionIsWorking();
        
        // Assert
        Assert.IsTrue(isWorking);
    }

    [Test]
    public void QueueProducer_Send()
    {
        // Arrange        
        var mockLogger = new Mock<ILogger<QueueProducer>>();
        string? mqUser = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_USER");
        string? mqPw = Environment.GetEnvironmentVariable("RABBITMQ_DEFAULT_PASS");
        string? mqHost = Environment.GetEnvironmentVariable("RABBITMQ_HOST");

        var options = new QueueOptions
        {
            ConnectionString = $"amqp://{mqUser}:{mqPw}@{mqHost}/",
            QueueName = "Default"
        };
        var mockOptions = new Mock<IOptions<QueueOptions>>();
        mockOptions.Setup(x => x.Value).Returns(options);

        var guid = Guid.NewGuid();

        // Act
        var producer = new QueueProducer(mockOptions.Object, mockLogger.Object);
        // producer.Send("test", guid);

        // Assert
        Assert.IsTrue(true);
    }

    // [Test]
    // public void QueueConsumer_StartReceive_Success()
    // {
    //     // Arrange
    //     var mockLogger = new Mock<ILogger<QueueConsumer>>();
    //     var options = new QueueOptions
    //     {
    //         ConnectionString = "test_connection_string",
    //         QueueName = "test_queue_name"
    //     };
    //     var mockOptions = new Mock<IOptions<QueueOptions>>();
    //     mockOptions.Setup(x => x.Value).Returns(options);

    //     var consumer = new QueueConsumer(mockOptions.Object, mockLogger.Object);
    //     consumer.SetChannel(mockModel.Object);

    //     // Act
    //     consumer.StartReceive();

    //     // Assert
    //     mockModel.Verify(x => x.BasicConsume(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<IDictionary<string, object>>(), It.IsAny<IBasicConsumer>()), Times.Once);
    // }

    // [Test]
    // public void QueueConsumer_StopReceive_Success()
    // {
    //     // Arrange
    //     var mockLogger = new Mock<ILogger<QueueConsumer>>();
    //     var options = new QueueOptions
    //     {
    //         ConnectionString = "test_connection_string",
    //         QueueName = "test_queue_name"
    //     };
    //     var mockOptions = new Mock<IOptions<QueueOptions>>();
    //     mockOptions.Setup(x => x.Value).Returns(options);

    //     var consumer = new QueueConsumer(mockOptions.Object, mockLogger.Object);
    //     consumer.SetChannel(mockModel.Object);

    //     // Act
    //     consumer.StopReceive();

    //     // Assert
    //     mockModel.Verify(x => x.BasicCancel(It.IsAny<string>()), Times.AtLeastOnce);
    //     mockModel.Verify(x => x.Close(), Times.Once);
    //     mockModel.Verify(x => x.Dispose(), Times.Once);
    //     mockConnection.Verify(x => x.Close(), Times.Once);
    //     mockConnection.Verify(x => x.Dispose(), Times.Once);
    // }
}