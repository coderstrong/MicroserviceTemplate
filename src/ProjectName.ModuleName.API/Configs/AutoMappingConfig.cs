using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.ModuleName.API.Configs.AutoMapper;

namespace ProjectName.ModuleName.API.Configs
{
    public static class MapperExtentions
    {
        public static IServiceCollection LoadMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BlogMappingConfigs());
            });

            services.AddSingleton(mappingConfig.CreateMapper());

            return services;
        }
    }
}
