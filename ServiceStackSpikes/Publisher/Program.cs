using System;
using Common;
using Funq;
using ServiceStack.Redis;
using ServiceStack.Redis.Messaging;
using ServiceStack.WebHost.Endpoints;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Publisher...");
            var clientAppHost = new ClientAppHost();
            clientAppHost.Init();
            clientAppHost.Start("http://localhost:81");
            while (true)
            {
                Console.WriteLine("Press enter to send a message...");
                clientAppHost.SendMessage();
                Console.ReadLine();
            }
        }

        public class ClientAppHost: AppHostHttpListenerBase
        {
            private RedisMqHost _mqHost;
            
            public ClientAppHost() : base("Publisher Console App", typeof(UpdateShippingAddress).Assembly)
            {
                
            }
            
            public override void Configure(Container container)
            {
                var redisFactory = new PooledRedisClientManager("localhost:6379");
                _mqHost = new RedisMqHost(redisFactory);
                _mqHost.Start();

            }

            public void SendMessage()
            {
                var message = new ShippingAddressUpdated
                    {
                        OrderIdInt = "12345678",
                        FirstName = "Ken"
                    };
                
                using (var mqClient = _mqHost.CreateMessageQueueClient())
                {
                    mqClient.Publish(message);
                }
            }
        }
    }
}
