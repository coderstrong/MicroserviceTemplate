using Microsoft.Extensions.DependencyInjection;
using ProjectName.Api.Application.Queries;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Api.Infrastructure
{
    public static class DIConfig
    {
        public static IServiceCollection LoadServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryGeneric<,>), typeof(RepositoryGeneric<,>));
            services.AddTransient(typeof(IPostQueries), typeof(PostQueries));

            return services;
        }
    }
}
