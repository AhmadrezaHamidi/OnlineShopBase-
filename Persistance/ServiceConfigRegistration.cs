using Application.EF.Context;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Base.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class ServiceConfigRegistration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services,
            Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services
            .AddDbContext<BloggingContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Local")));
         
            services.AddUnitOfWork<BloggingContext>();

            return services;
        }
    }
}
