using Microsoft.Extensions.DependencyInjection;

namespace ProjectName.Api.Infrastructure
{
    public static class CorsConfig
    {
        public static IServiceCollection RegisterCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });

                options.AddPolicy("CustomPolicy",
                    builder =>
                    {
                        builder.WithOrigins("*")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            return services;
        }
    }
}