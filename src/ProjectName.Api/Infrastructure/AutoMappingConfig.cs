using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Api.ViewModel;
using ProjectName.Domain.Entities;

namespace ProjectName.Api.Infrastructure
{
    public class AutoMappingConfigs : Profile
    {
        public AutoMappingConfigs()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Blog, BlogViewModel>().ReverseMap();
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
