using AutoMapper;
using ProjectName.ModuleName.API.Model;
using ProjectName.ModuleName.Domain.Entities;

namespace ProjectName.ModuleName.API.Configs.AutoMapper
{
    public class PostMappingConfigs : Profile
    {
        public PostMappingConfigs()
        {
            CreateMap<Post, PostResponseModel>().ReverseMap();
        }
    }
}
