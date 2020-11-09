using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProjectName.API.Model;
using ProjectName.Infrastructure.Database;

namespace ProjectName.API.Application.Queries
{
    public class PostQueries : IPostQueries
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public PostQueries(BlogContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PostResponseModel>> GetAsync()
        {
            return await _context.Posts.AsNoTracking().ProjectTo<PostResponseModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PostResponseModel> GetAsync(Guid Id)
        {
            return await _context.Posts.Where(x => x.Id == Id).ProjectTo<PostResponseModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}
