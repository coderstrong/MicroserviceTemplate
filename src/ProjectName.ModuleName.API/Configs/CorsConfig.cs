using Microsoft.Extensions.DependencyInjection;

namespace ProjectName.ModuleName.API.Configs
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
