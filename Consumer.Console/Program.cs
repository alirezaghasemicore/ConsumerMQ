using Application.Interfaces;
using Application.Services;
using Data.Repositories;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Consumer.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            IOC.Dependencies.Dependency_Container.RegisterServices(services);
            var provider = services.BuildServiceProvider();
            var rabbitMq = provider.GetService<IRabbitMqService>();
            rabbitMq.ReadingData();
        }
    }
}