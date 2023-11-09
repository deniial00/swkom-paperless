namespace NPaperless.Core.Queue.Interfaces;

public interface IQueueConsumer
{
    event EventHandler<QueueReceivedEventArgs> OnReceived;
    void StartReceive();
    void StopReceive();
    bool ConnectionIsWorking();
}

