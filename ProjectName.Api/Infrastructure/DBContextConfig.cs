using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Infrastructure.Database;
using System;

namespace ProjectName.Api.Infrastructure
{
    public static class DBContextConfig
    {
        public static IServiceCollection CreateProfileDbContext(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWorkGeneric<>), typeof(UnitOfWorkGeneric<>));
            services.AddDbContext<ProfileContext>(options => options.UseInMemoryDatabase(databaseName: "Profile" + Guid.NewGuid()), ServiceLifetime.Scoped);
            return services;
        }

        public static IServiceCollection CreateReportDbContext(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWorkGeneric<>), typeof(UnitOfWorkGeneric<>));
            services.AddDbContext<ReportContext>(options => options.UseInMemoryDatabase(databaseName: "Report" + Guid.NewGuid()), ServiceLifetime.Scoped);
            return services;
        }
    }
}