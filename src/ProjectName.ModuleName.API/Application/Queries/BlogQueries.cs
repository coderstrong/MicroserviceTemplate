using System;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using ProjectName.ModuleName.API.Model;
using ProjectName.ModuleName.Infrastructure.Dapper;
using ProjectName.ModuleName.Infrastructure.Database;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public class BlogQueries : IBlogQueries
    {
        private readonly ProjectNameModuleNameContext _context;
        private readonly IDapperRepository _dapper;
        private readonly IMapper _mapper;
        public BlogQueries(ProjectNameModuleNameContext context
            , IMapper mapper, IDapperRepository dapper)
        {
            _context = context;
            _mapper = mapper;
            _dapper = dapper;
        }

        public Task<BlogResponseModel> GetAsync(Guid Id)
        {
            ///use _dapper if use linq generate complex sql
            return _dapper.Connection.QueryFirstAsync<BlogResponseModel>(@"SELECT * FROM BlogSample.Blog Where Id=@Id", new { Id });
            ///other way
            ///return await _context.Blogs.AsNoTracking().Where(x => x.Id == Id).ProjectTo<BlogResponseModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}
