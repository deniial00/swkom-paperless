namespace NPaperless.Core.Queue;

using NPaperless.Core.Queue.Interfaces;

public class QueueReceivedEventArgs
{
    public QueueReceivedEventArgs(string content, Guid documentId)
    {
        Content = content;
        MessageId = documentId;
    }

    public string Content { get; }
    public Guid MessageId { get; }
}
