namespace NPaperless.Core.Queue.Interfaces;

public interface IQueueProducer
{
    void Send(string body, Guid documentId);
}

