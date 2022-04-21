using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace netcore_3._1_api_performance_tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int processorCount = Environment.ProcessorCount;
            Console.WriteLine($"Processors - {processorCount}");

            System.Threading.ThreadPool.SetMaxThreads(12, 12);

            var task = new Task(() =>
            {
                while (true)
                {
                    int threadsCount = Process.GetCurrentProcess().Threads.Count;

                    int avaiableWorkerThreads;
                    int avaiablePortThreads;

                    ThreadPool.GetAvailableThreads(out avaiableWorkerThreads, out avaiablePortThreads);

                    Console.WriteLine($"{DateTime.Now} - threads in use {threadsCount} from avaiable workers threads: {avaiableWorkerThreads}, avaiable ports: {avaiablePortThreads}");
                    Thread.Sleep(1000);
                }
            }, TaskCreationOptions.LongRunning);

            task.Start();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
