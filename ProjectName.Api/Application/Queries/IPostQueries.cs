using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectName.Api.ViewModel;

namespace ProjectName.Api.Application.Queries
{
    public interface IPostQueries
    {
        public Task<List<PostViewModel>> GetAsync();

        public Task<PostViewModel> GetAsync(int Id);
    }
}
