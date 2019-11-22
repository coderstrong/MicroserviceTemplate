using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Project.Api.Infrastructure;
using ProjectName.Api.Infrastructure;
using ProjectName.Infrastructure.Database;
using System;

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

            services.CreateProfileDbContext();

            // DB Context
            var ProfileContext = new ServiceDescriptor(typeof(DbContextOptions<ProfileContext>), ProfileContextFactory, ServiceLifetime.Scoped);
            services.Replace(ProfileContext);
            var ReportContext = new ServiceDescriptor(typeof(DbContextOptions<ReportContext>), ReportContextFactory, ServiceLifetime.Scoped);
            services.Replace(ReportContext);
            ConfigureContext(services);

            services.LoadServices();
            // Add Swagger
            SwaggerConfig.RegisterSwaggerServices(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            SwaggerConfig.RegisterSwaggerMiddlewares(app);
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void ConfigureContext(IServiceCollection services)
        {
            services.CreateProfileDbContext();
            services.CreateReportDbContext();
        }

        private DbContextOptions<ProfileContext> ProfileContextFactory(IServiceProvider provider)
        {
            string connectionString = Configuration.GetSection("ConnectionStrings:ProfileConnection").Value;

            var optionsBuilder = new DbContextOptionsBuilder<ProfileContext>();
            if (!String.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            return optionsBuilder.Options;
        }

        private DbContextOptions<ReportContext> ReportContextFactory(IServiceProvider provider)
        {
            string connectionString = Configuration.GetSection("ConnectionStrings:ReportConnection").Value;

            var optionsBuilder = new DbContextOptionsBuilder<ReportContext>();
            if (!String.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            return optionsBuilder.Options;
        }
    }
}