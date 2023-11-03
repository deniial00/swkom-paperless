namespace NPaperless.Core.Queue;

public class QueueOptions
{
    public const string Queue = "Queue";

    public string ConnectionString { get; set; } = string.Empty;
    public string QueueName { get; set; } = string.Empty;
}
