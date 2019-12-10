using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Infrastructure
{
    public static class DBContextConfig
    {
        public static IServiceCollection CreateProfileDbContext(this IServiceCollection services)
        {
            services.AddDbContext<EmployeeContext>(options => options.UseInMemoryDatabase(databaseName: "Profile" + Guid.NewGuid()), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            return services;
        }

        public static IServiceCollection CreateReportDbContext(this IServiceCollection services)
        {
            services.AddDbContext<PortalContext>(options => options.UseInMemoryDatabase(databaseName: "Report" + Guid.NewGuid()), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            return services;
        }
    }
}
