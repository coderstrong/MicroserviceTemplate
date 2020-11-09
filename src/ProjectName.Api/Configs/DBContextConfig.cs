using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Infrastructure.Database;

namespace ProjectName.API.Infrastructure
{
    public static class DBContextConfig
    {
        public static IServiceCollection CreateDomainDbContext(this IServiceCollection services)
        {
            services.AddDbContext<BlogContext>(options => options.UseInMemoryDatabase(databaseName: "BlogSample" + Guid.NewGuid()), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            return services;
        }
    }
}
