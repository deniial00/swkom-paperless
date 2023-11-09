using NPaperless.Core.Queue;
namespace NPaperless.Core.Interfaces;

public interface IQueueConsumer
{
    event EventHandler<QueueReceivedEventArgs> OnReceived;
    void StartReceive();
    void StopReceive();
    bool ConnectionIsWorking();
}

