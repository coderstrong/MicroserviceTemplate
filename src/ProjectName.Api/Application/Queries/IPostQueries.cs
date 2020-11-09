using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectName.API.Model;

namespace ProjectName.API.Application.Queries
{
    public interface IPostQueries
    {
        public Task<List<PostResponseModel>> GetAsync();

        public Task<PostResponseModel> GetAsync(Guid Id);
    }
}
