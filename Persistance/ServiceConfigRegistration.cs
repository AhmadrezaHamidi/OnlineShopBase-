using Application.EF.Context;
using Domain.Entitites;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistance.Base.UnitOfWork;
using Persistance.Servises;
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

            services.AddIdentity<IdentityUser, IdentityRole>()
                  .AddEntityFrameworkStores<BloggingContext>()
                  .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                      {
                          options.TokenValidationParameters = new TokenValidationParameters
                          {
                              ValidateIssuerSigningKey = true,
                              IssuerSigningKey = new SymmetricSecurityKey(
                                  Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                              ValidateIssuer = false,
                              ValidateAudience = false
                          };
                      });

            services.AddScoped<TokenService>();
            services.AddScoped<AccountService>();
            services.AddTransient<EmailService>();
            return services;
        }
    }
}
