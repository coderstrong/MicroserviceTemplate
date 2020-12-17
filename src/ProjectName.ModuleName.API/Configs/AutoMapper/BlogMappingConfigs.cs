using AutoMapper;
using ProjectName.ModuleName.API.Application.Commands;
using ProjectName.ModuleName.API.Application.Queries;
using ProjectName.ModuleName.Domain.Entities;

namespace ProjectName.ModuleName.API.Configs.AutoMapper
{
    public class BlogMappingConfigs : Profile
    {
        public BlogMappingConfigs()
        {
            CreateMap<Blog, GetBlogByIdResponseModel>().ReverseMap();
            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<Blog, UpdateBlogCommand>().ReverseMap();
        }
    }
}
