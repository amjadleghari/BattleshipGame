using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipGame.DomainObjects;
using BattleshipGame.Repositories;
using BattleshipGame.Repositories.Interfaces;
using BattleshipGame.Services;
using BattleshipGame.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BattleshipGame.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IList<Game>, List<Game>>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IScoreTrackingService, ScoreTrackingService>();
            services.AddScoped<IGameRepository, GameRepository>();
            return services;
        }

        public static IServiceCollection ConfigureIConfigurationProvider(this IServiceCollection services, string basePath)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var providers = new List<IConfigurationProvider>();
            foreach (var descriptor in services.Where(descriptor => descriptor.ServiceType == typeof(IConfiguration)).ToList())
            {
                var existingConfiguration = descriptor.ImplementationInstance as IConfigurationRoot;

                if (existingConfiguration is null)
                {
                    continue;
                }

                providers.AddRange(existingConfiguration.Providers);

                services.Remove(descriptor);
            }

            providers.AddRange(config.Providers);
            services.AddSingleton<IConfiguration>(new ConfigurationRoot(providers));
            return services;
        }
    }
}
