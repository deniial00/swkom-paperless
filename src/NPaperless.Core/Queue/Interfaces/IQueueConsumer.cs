namespace NPaperless.Core.Queue;

public interface IQueueConsumer
{
    event EventHandler<QueueReceivedEventArgs> OnReceived;
    void StartReceive();
    void StopReceive();
}

