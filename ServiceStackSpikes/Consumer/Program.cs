using System;
using Common;
using ServiceStack.Redis.Messaging;
using ServiceStack.WebHost.Endpoints;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var listeningOn = args.Length == 0 ? "http://*:1337/" : args[0];
            var appHost = new AppHost();
            appHost.Init();
            appHost.Start(listeningOn);

            Console.WriteLine("AppHost Created at {0}, listening on {1}",
                DateTime.Now, listeningOn);

            Console.ReadKey();
        }

        //Define the Web Services AppHost
        public class AppHost : AppHostHttpListenerBase
        {
            private RedisMqHost _mqHost;
            
            public AppHost()
                : base("HttpListener Self-Host", typeof(ShippingAddressService).Assembly) { }

            public override void Configure(Funq.Container container)
            {
                Routes
                    .Add<UpdateShippingAddress>("/shippingaddress");
            }
        }
    }
}
