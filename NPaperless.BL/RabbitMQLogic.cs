using System.Collections;
using NPaperless.BL.Interfaces;
using RabbitMQ.Client;

namespace NPaperless.BL {
	public class RabbitMQService : IRabbitMQService
	{
		private readonly IConnection _connection;
		private readonly IModel _channel;

		public RabbitMQService()
		{
			var factory = new ConnectionFactory() { HostName = "swkom-rabbitmq" };
			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();
		}

		// Implement methods for publishing and subscribing to messages
	}
}