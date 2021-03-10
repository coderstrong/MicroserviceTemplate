using System;
using System.Linq;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.ModuleName.Application.Behaviors;

namespace ProjectName.ModuleName.API.Configs
{
    public static class MediaRConfig
    {
        public static IServiceCollection AddMediaRModule(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.GetName().Name.Contains(".Application")).ToList();

            foreach (var assembly in assemblies)
            {
                AssemblyScanner.FindValidatorsInAssembly(assembly)
                .ForEach(result =>
                {
                    services.AddTransient(result.InterfaceType, result.ValidatorType);
                });
                services.AddMediatR(assembly);
            }

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            return services;
        }
    }
}
