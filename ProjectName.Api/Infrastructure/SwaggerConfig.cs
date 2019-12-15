using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Project.Api.Infrastructure
{
    public class SwaggerConfig
    {
        public static void RegisterSwaggerServices(IServiceCollection services)
        {
            // Register the Swagger services
            services.AddOpenApiDocument(config =>
            {
                config.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));

                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Demo API";
                    document.Info.Description = "A simple ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Thao Tran",
                        Email = string.Empty,
                        Url = "https://coderstrong.github.io"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "",
                        Url = ""
                    };
                };
            });
        }

        public static void RegisterSwaggerMiddlewares(IApplicationBuilder app)
        {
            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
