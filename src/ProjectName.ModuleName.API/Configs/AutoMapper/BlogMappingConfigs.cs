using AutoMapper;
using ProjectName.ModuleName.API.Model;
using ProjectName.ModuleName.Domain.Entities;

namespace ProjectName.ModuleName.API.Configs.AutoMapper
{
    public class BlogMappingConfigs : Profile
    {
        public BlogMappingConfigs()
        {
            CreateMap<Blog, BlogResponseModel>().ReverseMap();
        }
    }
}
