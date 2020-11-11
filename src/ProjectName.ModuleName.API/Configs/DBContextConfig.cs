using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.ModuleName.Infrastructure.Database;

namespace ProjectName.ModuleName.API.Infrastructure
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
