using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Worker.Data;
using Worker.Entities;
using Worker.Messaging;
using Worker.Workers;

namespace Worker
{
    class Program
    {
        private static string address = "http://auzpoc.sybrin.co.za/<your_guid_here>";
        public class RootObject
        {
            public string hostname { get; set; }
            public DateTime time { get; set; }
            public string user { get; set; }
        }

        static void Main(string[] args)
        {
            RootObject data = new RootObject();

            string hostname = Environment.MachineName;
            DateTime time = DateTime.Now;
            string user = Environment.UserName;
            data.hostname = hostname;
            data.time = time;
            data.user = user;

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(data));
            using (var client = new System.Net.WebClient())
            {
                client.UploadData(address, "PUT", bytes);
            }

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var loggerFactory = new LoggerFactory()
                .AddConsole();

            var services = new ServiceCollection()
                .AddSingleton(loggerFactory)
                .AddLogging()
                .AddSingleton<IConfiguration>(config)
                .AddTransient<IVoteData, MySqlVoteData>()
                .AddTransient<IMessageQueue, MessageQueue>()
                .AddSingleton<QueueWorker>()
                .AddDbContext<VoteContext>(builder => builder.UseMySQL(config.GetConnectionString("VoteData")));

            var provider = services.BuildServiceProvider();
            var worker = provider.GetService<QueueWorker>();
            worker.Start();
        }
    }
}
