using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace ProjectName.Api.Infrastructure
{
    public static class SerilogConfig
    {
        public static IServiceCollection AddLoggingSystem(this IServiceCollection services, IConfiguration configuration)
        {
            var _configSerilog = configuration.GetSection("Serilog");

            if (!_configSerilog.Exists())
            {
                throw new Exception("Missing config section Serilog");
            }
            else
            {
                var _configProperties = _configSerilog.GetSection("Properties");
                if (!_configProperties.Exists())
                {
                    throw new Exception("Please config section Properties has required severName and serviceName");
                }
                else
                {
                    if (string.IsNullOrEmpty(_configProperties["severName"]) || string.IsNullOrEmpty(_configProperties["serviceName"]))
                    {
                        throw new Exception("Please config section Properties has required severName and serviceName");
                    }
                }
            }

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddSerilog();

            services.AddSingleton<ILoggerFactory>(loggerFactory);

            return services;
        }
    }
}