using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using ProjectName.Api.ViewModel;
using ProjectName.Infrastructure.Dapper;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Application.Queries
{
    public class BlogQueries : IBlogQueries
    {
        private readonly BlogContext _context;
        private readonly IDapperRepository _dapper;
        private readonly IMapper _mapper;
        public BlogQueries(BlogContext context
            , IMapper mapper, IDapperRepository dapper)
        {
            _context = context;
            _mapper = mapper;
            _dapper = dapper;
        }

        public Task<BlogViewModel> GetAsync(int Id)
        {
            ///use _dapper if use linq generate complex sql
            return _dapper.Connection.QueryFirstAsync<BlogViewModel>(@"SELECT * FROM BlogSample.Blog Where Id=@Id", new { Id });
            ///other way
            ///return await _context.Blogs.AsNoTracking().Where(x => x.Id == Id).ProjectTo<BlogViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}
