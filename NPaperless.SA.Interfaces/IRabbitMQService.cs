namespace NPaperless.SA.Interfaces;
public interface IRabbitMQService
{
	public void SendJobToQueue(Guid guid);
	public Guid? RetrieveJobFromQueue();
}
