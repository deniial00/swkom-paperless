using System;
using System.Text;
using Minio;
using NPaperless.SA.Interfaces;

using Minio.DataModel.Args;
using RabbitMQ.Client;

// using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace NPaperless.BL;
public class RabbitMQService : IRabbitMQService
{
	private readonly ConnectionFactory _connectionFactory;
	private readonly string _queueName;

	public RabbitMQService(ConnectionFactory connectionFactory, string queueName)
	{
		_connectionFactory = connectionFactory;
		_queueName = queueName;
	}

	public Guid RetrieveJobFromQueue()
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
		
		throw new Exception();
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