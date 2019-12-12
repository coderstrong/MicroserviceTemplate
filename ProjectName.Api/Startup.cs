using System;
using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Project.Api.Infrastructure;
using ProjectName.Api.Infrastructure;
using ProjectName.Domain.SeedWork;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api
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
            services.AddMediatR(Assembly.GetExecutingAssembly());
            // DB Context
            var ProfileContext = new ServiceDescriptor(typeof(DbContextOptions<EmployeeContext>), EmployeeContextFactory, ServiceLifetime.Scoped);
            services.Replace(ProfileContext);
            var ReportContext = new ServiceDescriptor(typeof(DbContextOptions<PortalContext>), ReportContextFactory, ServiceLifetime.Scoped);
            services.Replace(ReportContext);
            ConfigureContext(services);

            services.LoadServices();
            // Add Swagger
            SwaggerConfig.RegisterSwaggerServices(services);

            services.AddControllers();//.AddFluentValidation(apiConfiguration => apiConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>());
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
            services.AddScoped<IContext, EmployeeContext>();
            services.CreateEmployeeDbContext();
            services.CreatePortalDbContext();
        }

        private DbContextOptions<EmployeeContext> EmployeeContextFactory(IServiceProvider provider)
        {
            string connectionString = Configuration.GetSection("ConnectionStrings:EmployeeConnection").Value;

            var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();
            if (!String.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            return optionsBuilder.Options;
        }

        private DbContextOptions<PortalContext> ReportContextFactory(IServiceProvider provider)
        {
            string connectionString = Configuration.GetSection("ConnectionStrings:ReportConnection").Value;

            var optionsBuilder = new DbContextOptionsBuilder<PortalContext>();
            if (!String.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            return optionsBuilder.Options;
        }

        #endregion DataContext
    }
}
