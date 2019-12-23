using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Infrastructure
{
    public static class DBContextConfig
    {
        public static IServiceCollection CreateEmployeeDbContext(this IServiceCollection services)
        {
            services.AddDbContext<BlogContext>(options => options.UseInMemoryDatabase(databaseName: "BlogSample" + Guid.NewGuid()), ServiceLifetime.Transient, ServiceLifetime.Scoped);
            return services;
        }

        public static IServiceCollection CreatePortalDbContext(this IServiceCollection services)
        {
            services.AddDbContext<PortalContext>(options => options.UseInMemoryDatabase(databaseName: "Portal" + Guid.NewGuid()), ServiceLifetime.Transient, ServiceLifetime.Scoped);
            return services;
        }
    }
}
