using Microsoft.Extensions.DependencyInjection;
using ProjectName.ModuleName.API.Application.Queries;
using ProjectName.ModuleName.Domain.SeedWork;
using ProjectName.ModuleName.Infrastructure;

namespace ProjectName.ModuleName.API.Configs
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection LoadServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryGeneric<,>), typeof(RepositoryGeneric<,>));
            services.AddTransient<IPostQueries, PostQueries>();
            services.AddTransient<IBlogQueries, BlogQueries>();
            return services;
        }
    }
}
