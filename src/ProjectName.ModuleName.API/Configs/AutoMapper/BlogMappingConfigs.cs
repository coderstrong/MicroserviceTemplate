using AutoMapper;
using ProjectName.ModuleName.Application.Commands;
using ProjectName.ModuleName.Application.Queries;
using ProjectName.ModuleName.Domain.Entities;

namespace ProjectName.ModuleName.API.Configs.AutoMapper
{
    public class BlogMappingConfigs : Profile
    {
        public BlogMappingConfigs()
        {
            CreateMap<Blog, GetBlogByIdQueryResponseModel>().ReverseMap();
            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<Blog, UpdateBlogCommand>().ReverseMap();
        }
    }
}
