using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connection)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddScoped<IUnitOfWork>(u => new UnitOfWork(connection));
            //services.AddFileConfigurationServices("Sapp", new Version("0.0.0.11"), "/");
            return services;
        }
    }
}
