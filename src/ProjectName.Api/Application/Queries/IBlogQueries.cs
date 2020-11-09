using System;
using System.Threading.Tasks;
using ProjectName.API.Model;

namespace ProjectName.API.Application.Queries
{
    public interface IBlogQueries
    {
        public Task<BlogResponseModel> GetAsync(Guid Id);
    }
}
