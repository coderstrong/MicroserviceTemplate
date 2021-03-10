using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectName.ModuleName.Domain.Entities;
using ProjectName.ModuleName.Domain.SeedWork;
using ProjectName.ModuleName.Infrastructure.Database;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.ModuleName.Application.Queries
{
    public class GetBlogQueryRequestHandler : IRequestHandler<GetBlogQueryRequest, IEnumerable<GetBlogQueryResponseModel>>
    {
        private readonly IRepositoryGeneric<ProjectNameModuleNameContext, Blog> _blog;
        private readonly IMapper _mapper;

        public GetBlogQueryRequestHandler(IRepositoryGeneric<ProjectNameModuleNameContext, Blog> blog, IMapper mapper)
        {
            _blog = blog;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetBlogQueryResponseModel>> Handle(GetBlogQueryRequest query, CancellationToken cancellationToken)
        {
            var result = await _blog.AsQueryable().ProjectTo<GetBlogQueryResponseModel>(_mapper.ConfigurationProvider).ToListAsync();

            return result;
        }
    }
}