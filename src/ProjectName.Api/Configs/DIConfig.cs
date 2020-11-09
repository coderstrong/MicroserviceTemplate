using Microsoft.Extensions.DependencyInjection;
using ProjectName.API.Application.Queries;
using ProjectName.Domain.Common;

namespace ProjectName.API.Infrastructure
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
