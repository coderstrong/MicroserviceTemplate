using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectName.ModuleName.Domain.Entities;
using ProjectName.ModuleName.Domain.SeedWork;
using ProjectName.ModuleName.Infrastructure.Database;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public class GetBlogByIdRequestHandler : IRequestHandler<GetBlogByIdRequest, GetBlogByIdResponseModel>
    {
        private readonly IRepositoryGeneric<ProjectNameModuleNameContext, Blog> _blog;
        private readonly IMapper _mapper;

        public GetBlogByIdRequestHandler(IRepositoryGeneric<ProjectNameModuleNameContext, Blog> blog, IMapper mapper)
        {
            _blog = blog;
            _mapper = mapper;
        }

        public async Task<GetBlogByIdResponseModel> Handle(GetBlogByIdRequest query, CancellationToken cancellationToken)
        {
            var result = await _blog.AsQueryable(e => e.Id == query.Id).ProjectTo<GetBlogByIdResponseModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();

            return result;
        }
    }
}
