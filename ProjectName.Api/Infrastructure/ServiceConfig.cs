using Microsoft.Extensions.DependencyInjection;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Api.Infrastructure
{
    public static class ServiceConfig
    {
        public static IServiceCollection LoadServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryGeneric<,>), typeof(RepositoryGeneric<,>));
            // add more Service here

            return services;
        }
    }
}
