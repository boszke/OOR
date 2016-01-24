﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace rmq
{
    public class Producer : IDisposable
    {
        protected IModel Model;
        protected IConnection Connection;
        protected string QueueName;

        public Producer(string hostName, string queueName)
        {
            QueueName = queueName;
            var connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = hostName;
            Connection = connectionFactory.CreateConnection();
            Model = Connection.CreateModel();
            Model.QueueDeclare(QueueName, false, false, false, null);
        }

        public void SendMessage(byte[] message)
        {
            IBasicProperties basicProporties = Model.CreateBasicProperties();
            Model.BasicPublish("", QueueName, basicProporties, message);
        }

        public void Dispose()
        {
            if (Connection != null)
                Connection.Close();
            if (Model != null)
                Model.Abort();
        }
    }
}
