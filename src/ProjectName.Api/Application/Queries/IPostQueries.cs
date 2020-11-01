using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectName.Api.Model;

namespace ProjectName.Api.Application.Queries
{
    public interface IPostQueries
    {
        public Task<List<PostResponseModel>> GetAsync();

        public Task<PostResponseModel> GetAsync(Guid Id);
    }
}
