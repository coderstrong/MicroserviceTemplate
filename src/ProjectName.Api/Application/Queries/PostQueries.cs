using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProjectName.Api.ViewModel;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Application.Queries
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

        public async Task<List<PostViewModel>> GetAsync()
        {
            return await _context.Posts.AsNoTracking().ProjectTo<PostViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PostViewModel> GetAsync(int Id)
        {
            return await _context.Posts.Where(x => x.Id == Id).ProjectTo<PostViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}
