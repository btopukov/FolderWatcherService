using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BradyCodeChallenge.Common.Serializer;
using BradyCodeChallenge.FileWatcherService;
using BradyCodeChallenge.Infrastructure.Interfaces;
using BradyCodeChallenge.Service;
using Microsoft.Extensions.DependencyInjection;
using Topshelf;

namespace BradyCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create service collection and configure our services
            var services = ConfigureServices();

            // Generate a provider
            var serviceProvider = services.BuildServiceProvider();

            // start off our actual code
            serviceProvider.GetService<ApplicationRun>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection()
           .AddSingleton<IWatcher, FileWatcher>()
           .AddSingleton<ISerializer, Serializer>()
           .AddSingleton<ICalculateData, CalculateData>()
           .AddTransient<ApplicationRun>();

            return services;
        }
    }
}
