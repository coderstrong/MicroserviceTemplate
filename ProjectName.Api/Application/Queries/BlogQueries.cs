using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProjectName.Api.ViewModel;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Application.Queries
{
    public class BlogQueries : IBlogQueries
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public BlogQueries(BlogContext context
            , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BlogViewModel> GetAsync(int Id)
        {
            return await _context.Blogs.AsNoTracking().Where(x => x.Id == Id).ProjectTo<BlogViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}
