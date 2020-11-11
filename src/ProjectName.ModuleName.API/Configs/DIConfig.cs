using Microsoft.Extensions.DependencyInjection;
using ProjectName.ModuleName.API.Application.Queries;
using ProjectName.ModuleName.Domain.Common;

namespace ProjectName.ModuleName.API.Infrastructure
{
    public static class DIConfig
    {
        public static IServiceCollection LoadServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryGeneric<,>), typeof(RepositoryGeneric<,>));
            services.AddTransient(typeof(IPostQueries), typeof(PostQueries));
            services.AddTransient(typeof(IBlogQueries), typeof(BlogQueries));
            return services;
        }
    }
}
