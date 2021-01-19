using Microsoft.Extensions.DependencyInjection;
using ProjectName.ModuleName.Domain.SeedWork;
using ProjectName.ModuleName.Infrastructure;

namespace ProjectName.ModuleName.API.Configs
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection LoadServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryGeneric<,>), typeof(RepositoryGeneric<,>));
            return services;
        }
    }
}
