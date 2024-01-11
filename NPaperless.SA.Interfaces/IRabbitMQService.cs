namespace NPaperless.SA.Interfaces;
public interface IRabbitMQService
{
	// public void SendDocumentToQueue(Document doc);
	public void SendJobToQueue(Guid guid);
	// // public Document RetrieveDocumentFromQueue();
	public Guid RetrieveJobFromQueue();
}
