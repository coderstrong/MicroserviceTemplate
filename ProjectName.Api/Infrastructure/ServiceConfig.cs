using System.Linq;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Api.Application.Behaviors;
using ProjectName.Domain.AggregatesModel.EmployeeAggregate;
using ProjectName.Domain.SeedWork;
using ProjectName.Infrastructure.Repositories;

namespace ProjectName.Api.Infrastructure
{
    public static class ServiceConfig
    {
        public static IServiceCollection LoadServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryGeneric<,>), typeof(RepositoryGeneric<,>));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            var test = Assembly.GetExecutingAssembly().ExportedTypes.Where(t => t is IValidator);

            return services;
        }
    }
}
