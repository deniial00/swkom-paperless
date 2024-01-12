using NPaperless.SA.Interfaces;

using System;
using System.Text;
using Minio;

using RabbitMQ.Client;

namespace NPaperless.SA;
public class RabbitMQService : IRabbitMQService
{
	private readonly ConnectionFactory _connectionFactory;
	private readonly string _queueName;

	public RabbitMQService(ConnectionFactory connectionFactory, string queueName)
	{
		_connectionFactory = connectionFactory;
		_queueName = queueName;
	}

	//TODO: Umschreiben auf Event-based mit EventHandler
	public Guid? RetrieveJobFromQueue() 
	{
		using (var connection = _connectionFactory.CreateConnection())
		using (var channel = connection.CreateModel())
		{
			channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

			BasicGetResult result = channel.BasicGet(_queueName, autoAck: true);
			
			if(result != null)
			{
				var bytes = result.Body.ToArray();
				var guid = new Guid(bytes);

				return guid;
			}
		}
		
		return null;
		// throw new Exception(); // kann eigentlich nd passieren. außer es wird keine guid geschickt
	}

	public void SendJobToQueue(Guid guid)
	{
		using (var connection = _connectionFactory.CreateConnection())
		using (var channel = connection.CreateModel())
		{
			channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
			var body = guid.ToByteArray();
			channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
		}
	}
}