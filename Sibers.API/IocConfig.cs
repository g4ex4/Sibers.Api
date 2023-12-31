﻿using Microsoft.EntityFrameworkCore;
using Sibers.BLL.Common.Mappings;
using Sibers.BLL.Services;
using Sibers.DAL;
using Sibers.DAL.Common;
using Sibers.DAL.Implementations;
using Sibers.DAL.Interfaces;
using Sibers.WebAPI.IdentityData;
using System.Reflection;

namespace Sibers.WebAPI
{
    public static class IocConfig
    {
        /// <summary>
        /// Метод расширения добавляющий конфигурацию проекта
        /// </summary>
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            return services;
        }

        /// <summary>
        /// Метод расширения добавляющий UnitOfWork и IdentityContext
        /// </summary>
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<IdentityContext>(opt
            => opt.UseSqlServer(configuration.GetConnectionString("IdentityContext")));

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("AppDbContext"));
            });
            return services;
        }

        /// <summary>
        /// Метод расширения добавляющий сервисы приложения
        /// </summary>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var assembly = typeof(IService).Assembly;
            var serviceInterfaces = assembly
                .GetTypes()
                .Where(t => typeof(IService).IsAssignableFrom(t) && t != typeof(IService) && t.IsInterface);
            var servicePairs = serviceInterfaces
                .Select(x => new
                {
                    serviceInterface = x,
                    serviceImplementaions = assembly
                        .GetTypes()
                        .Where(t => x.IsAssignableFrom(t) && t.IsClass)
                        .ToList()
                });
            foreach (var servicePair in servicePairs)
            {
                foreach (var implementation in servicePair.serviceImplementaions)
                {
                    services.AddTransient(servicePair.serviceInterface, implementation);
                }
            }

            return services;
        }

        /// <summary>
        /// Метод расширения добавляющий маппер AutoMapper
        /// </summary>
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IService).Assembly));
            });

            return services;
        }

        /// <summary>
        /// Метод расширения добавляющий CORS
        /// </summary>
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder => builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Content-Disposition")
                    .AllowCredentials()));

            return services;
        }
    }
}
