namespace NPaperless.Core.Queue;

using NPaperless.Core.Queue.Interfaces;

public class QueueOptions
{
    public const string Queue = "Queue";

    public string ConnectionString { get; set; } = string.Empty;
    public string QueueName { get; set; } = string.Empty;
}
