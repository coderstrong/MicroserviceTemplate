using System;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Api.Application.Behaviors;

namespace ProjectName.Api.Infrastructure
{
    public static class MediaRConfig
    {
        public static IServiceCollection AddMediaRModule(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            AssemblyScanner.FindValidatorsInAssembly(assembly)
            .ForEach(result =>
            {
                Console.WriteLine("Here we are");
                services.AddTransient(result.InterfaceType, result.ValidatorType);
            });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            services.AddMediatR(assembly);

            return services;
        }
    }
}
