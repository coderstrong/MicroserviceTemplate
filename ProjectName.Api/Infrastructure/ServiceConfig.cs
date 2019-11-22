using Microsoft.Extensions.DependencyInjection;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Infrastructure
{
    public static class ServiceConfig
    {
        public static IServiceCollection LoadServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseServiceGeneric<>), typeof(BaseServiceGeneric<>));
            // add more Service here

            return services;
        }
    }
}
