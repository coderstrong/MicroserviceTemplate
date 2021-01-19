using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectName.ModuleName.Domain.Entities;
using ProjectName.ModuleName.Domain.SeedWork;
using ProjectName.ModuleName.Infrastructure.Database;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.ModuleName.Application.Queries
{
    public class GetBlogByIdQueryRequestHandler : IRequestHandler<GetBlogByIdQueryRequest, GetBlogByIdQueryResponseModel>
    {
        private readonly IRepositoryGeneric<ProjectNameModuleNameContext, Blog> _blog;
        private readonly IMapper _mapper;

        public GetBlogByIdQueryRequestHandler(IRepositoryGeneric<ProjectNameModuleNameContext, Blog> blog, IMapper mapper)
        {
            _blog = blog;
            _mapper = mapper;
        }

        public async Task<GetBlogByIdQueryResponseModel> Handle(GetBlogByIdQueryRequest query, CancellationToken cancellationToken)
        {
            var result = await _blog.AsQueryable(e => e.Id == query.Id).ProjectTo<GetBlogByIdQueryResponseModel>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();

            return result;
        }
    }
}