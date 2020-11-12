using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Project.Api.Infrastructure;
using ProjectName.ModuleName.API.Configs;
using ProjectName.ModuleName.Domain.Common;
using ProjectName.ModuleName.Infrastructure.Dapper;
using ProjectName.ModuleName.Infrastructure.Database;

namespace ProjectName.ModuleName.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddLoggingSystem(Configuration);
            services.AddMediaRModule();

            var BlogContext = new ServiceDescriptor(typeof(DbContextOptions<BlogContext>), BlogContextFactory, ServiceLifetime.Scoped);
            services.Replace(BlogContext);
            ConfigureContext(services);

            services.AddDapper(o =>
            {
                o.Schema = "BlogSample";
                o.DatabaseType = DatabaseType.SqlServer;
                o.ConnectionString = Configuration.GetSection("ConnectionStrings:BlogConnection").Value;
            });

            services.LoadServices();

            SwaggerConfig.RegisterSwaggerServices(services);

            services.LoadMapper();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            SwaggerConfig.RegisterSwaggerMiddlewares(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region DataContext

        private void ConfigureContext(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, BlogContext>();
            services.CreateDomainDbContext();
        }

        private DbContextOptions<BlogContext> BlogContextFactory(IServiceProvider provider)
        {
            string connectionString = Configuration.GetSection("ConnectionStrings:BlogConnection").Value;

            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();
            if (!String.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            return optionsBuilder.Options;
        }

        #endregion DataContext
    }
}
