namespace NPaperless.Core.Queue;

public interface IQueueProducer
{
    void Send(string body, Guid documentId);
}

