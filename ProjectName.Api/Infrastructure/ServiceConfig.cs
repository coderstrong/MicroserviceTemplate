using Microsoft.Extensions.DependencyInjection;
using ProjectName.Domain.AggregatesModel.BlogAggregate;
using ProjectName.Domain.AggregatesModel.PostAggregate;
using ProjectName.Domain.SeedWork;
using ProjectName.Infrastructure.Repositories;

namespace ProjectName.Api.Infrastructure
{
    public static class ServiceConfig
    {
        public static IServiceCollection LoadServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryGeneric<,>), typeof(RepositoryGeneric<,>));
            services.AddTransient<IPostRepository, PostRepository>();

            return services;
        }
    }
}
