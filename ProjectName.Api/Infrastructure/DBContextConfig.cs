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
            services.AddTransient<IContext, ProfileContext>();
            services.AddTransient(typeof(IUnitOfWorkGeneric<>), typeof(UnitOfWorkGeneric<>));
            services.AddDbContext<ProfileContext>(options => options.UseInMemoryDatabase(databaseName: "Profile" + Guid.NewGuid()));
            return services;
        }

        public static IServiceCollection CreateReportDbContext(this IServiceCollection services)
        {
            services.AddTransient<IContext, ReportContext>();
            services.AddTransient(typeof(IUnitOfWorkGeneric<>), typeof(UnitOfWorkGeneric<>));
            services.AddDbContext<ReportContext>(options => options.UseInMemoryDatabase(databaseName: "Report" + Guid.NewGuid()));
            return services;
        }
    }
}