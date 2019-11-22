using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Infrastructure.Database;
using System;

namespace ProjectName.Api.Infrastructure
{
    public static class DBContextConfig
    {
        public static IServiceCollection CreateDefaultDbContext(this IServiceCollection services)
        {
            services.AddTransient<IContext, ProfileContext>();
            services.AddTransient(typeof(IUnitOfWorkGeneric<>), typeof(UnitOfWorkGeneric<>));
            services.AddDbContext<ProfileContext>(options => options.UseInMemoryDatabase(databaseName: "Core" + Guid.NewGuid()));
            return services;
        }
    }


}
