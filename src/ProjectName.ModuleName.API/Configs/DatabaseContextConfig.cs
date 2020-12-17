using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.ModuleName.Infrastructure.Database;

namespace ProjectName.ModuleName.API.Configs
{
    public static class DatabaseContextConfig
    {
        public static IServiceCollection CreateDomainDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ProjectNameModuleNameContext>(options => options.UseInMemoryDatabase(databaseName: "BlogSample" + Guid.NewGuid()), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            return services;
        }
    }
}
