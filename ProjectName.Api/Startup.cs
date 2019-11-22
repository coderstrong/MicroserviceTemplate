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

            var CoreContext = new ServiceDescriptor(typeof(DbContextOptions<ProfileContext>), ProfileContextFactory, ServiceLifetime.Scoped);
            services.Replace(CoreContext);

            services.CreateDefaultDbContext();
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

        public DbContextOptions<ProfileContext> ProfileContextFactory(IServiceProvider provider)
        {
            string connectionString = Configuration.GetSection("ConnectionStrings:CoreConnection").Value;

            var optionsBuilder = new DbContextOptionsBuilder<ProfileContext>();
            if (!String.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            return optionsBuilder.Options;
        }
    }
}
