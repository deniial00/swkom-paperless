namespace NPaperless.Core.Queue;

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
