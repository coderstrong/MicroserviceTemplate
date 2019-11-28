using Microsoft.Extensions.DependencyInjection;
using ProjectName.Bussiness.Services;
using ProjectName.Infrastructure.Database;

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