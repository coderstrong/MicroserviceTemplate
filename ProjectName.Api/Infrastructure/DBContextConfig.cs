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
            services.AddDbContext<EmployeeContext>(options => options.UseInMemoryDatabase(databaseName: "Employee" + Guid.NewGuid()), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            return services;
        }

        public static IServiceCollection CreatePortalDbContext(this IServiceCollection services)
        {
            services.AddDbContext<PortalContext>(options => options.UseInMemoryDatabase(databaseName: "Portal" + Guid.NewGuid()), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            return services;
        }
    }
}
