using System;
using Funq;
using ServiceStack;
using ServiceStack.Messaging.Redis;
using ServiceStack.Redis;
using ServiceStack.Testing;
using TestMqShared;

namespace RedisMQ
{
    public class HelloService : Service
    {
        public object Any(Hello req)
        {
            return new HelloResponse { Result = "Hello, " + req.Name };
        }
    }
    public class ServerAppHost : AppHostHttpListenerBase
    {
        public ServerAppHost() : base("Test Server", typeof(HelloService).Assembly) { }

        public override void Configure(Container container)
        {
            base.Routes
                .Add<Hello>("/hello")
                .Add<Hello>("/hello/{Name}");

            var redisFactory = new PooledRedisClientManager("localhost:6379");
            container.Register<IRedisClientsManager>(redisFactory);
            var mqHost = new RedisMqServer(redisFactory, retryCount: 2);

            //Server - MQ Service Impl:

            //Listens for 'Hello' messages sent with: mqClient.Publish(new Hello { ... })
            //mqHost.RegisterHandler<Hello>(base.ExecuteMessage);
            mqHost.RegisterHandler<Hello>(m =>
                new HelloResponse { Result = "Hello, " + m.GetBody().Name }
            );
            mqHost.Start(); //Starts listening for messages
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var serverAppHost = new ServerAppHost();
            serverAppHost.Init();
            serverAppHost.Start("http://localhost:1400/");
            Console.WriteLine("Server running.  Press enter to terminate...");
            Console.ReadLine();
        }
    }
}
