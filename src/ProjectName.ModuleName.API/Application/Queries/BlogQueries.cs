using System;
using System.Threading.Tasks;
using AutoMapper;
using ProjectName.ModuleName.API.Model;
using ProjectName.ModuleName.Domain.Entities;
using ProjectName.ModuleName.Domain.SeedWork;
using ProjectName.ModuleName.Infrastructure.Database;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public class BlogQueries : IBlogQueries
    {
        private readonly IRepositoryGeneric<ProjectNameModuleNameContext, Blog> _blog;
        private readonly IMapper _mapper;
        public BlogQueries(IRepositoryGeneric<ProjectNameModuleNameContext, Blog> blog
            , IMapper mapper)
        {
            _blog = blog;
            _mapper = mapper;
        }

        public async Task<BlogResponseModel> GetAsync(Guid Id)
        {
            var result = await _blog.GetOneAsync(Id);
            return _mapper.Map<BlogResponseModel>(result);
        }
    }
}
