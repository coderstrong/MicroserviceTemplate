using System;
using System.Threading.Tasks;
using ProjectName.ModuleName.API.Model;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public interface IBlogQueries
    {
        public Task<BlogResponseModel> GetAsync(Guid Id);
    }
}
