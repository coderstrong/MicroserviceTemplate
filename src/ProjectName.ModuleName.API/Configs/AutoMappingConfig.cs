using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.ModuleName.API.Model;
using ProjectName.ModuleName.Domain.Entities;

namespace ProjectName.ModuleName.API.Infrastructure
{
    public class AutoMappingConfigs : Profile
    {
        public AutoMappingConfigs()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Post, PostResponseModel>().ReverseMap();
            CreateMap<Blog, BlogResponseModel>().ReverseMap();
        }
    }

    public static class MapperExtentions
    {
        public static IServiceCollection LoadMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMappingConfigs());
            });

            services.AddSingleton(mappingConfig.CreateMapper());

            return services;
        }
    }
}
