using Microsoft.Extensions.DependencyInjection;
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

            return services;
        }
    }
}
