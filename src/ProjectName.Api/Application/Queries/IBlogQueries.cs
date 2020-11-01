using System;
using System.Threading.Tasks;
using ProjectName.Api.Model;

namespace ProjectName.Api.Application.Queries
{
    public interface IBlogQueries
    {
        public Task<BlogResponseModel> GetAsync(Guid Id);
    }
}
