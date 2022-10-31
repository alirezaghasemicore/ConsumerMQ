using Application.Interfaces;
using Application.Services;
using Data.Providers;
using Data.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Dependencies
{
    public class Dependency_Container
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<SqlContext>(options =>
            {
                string connection = "Server=.\\SQl2019;DataBase=RabbitDB;Integrated Security=true";
                options.UseSqlServer(connection);
            });

            services.AddScoped<IDefaultLogRepository, DefaultLogRepository>();
            services.AddScoped<IDefaultLogService, DefaultLogService>();
            services.AddScoped<IRabbitMqService, RabbitMqService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IJsonLogRepository, JsonLogRepository>();
            services.AddScoped<IJsonLogService, JsonLogService>();

        }
    }
}
