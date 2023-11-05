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
    }

    [Test]
    public void QueueProducer_Send_Success()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<QueueProducer>>();
        var options = new QueueOptions
        {
            // ConnectionString = "amqp://swkom:3Od1EAjFuJ6JVT4Y@swkom-api/",
            ConnectionString = "amqp://swkom:3Od1EAjFuJ6JVT4Y@localhost/",
            QueueName = "Default"
        };
        var mockOptions = new Mock<IOptions<QueueOptions>>();
        mockOptions.Setup(x => x.Value).Returns(options);

        var producer = new QueueProducer(mockOptions.Object, mockLogger.Object);
        producer.SetChannel(mockModel.Object);

        // Act
        producer.Send("test_body", Guid.NewGuid());

        // Assert
        mockModel.Verify(x => x.BasicPublish(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<IBasicProperties>(), It.IsAny<ReadOnlyMemory<byte>>()), Times.Once);
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