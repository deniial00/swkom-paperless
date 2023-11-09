namespace NPaperless.Core.Interfaces;

public interface IQueueProducer
{
    void Send(string body, Guid documentId);
    bool ConnectionIsWorking();
}

