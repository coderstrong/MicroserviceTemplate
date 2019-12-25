using System.Threading.Tasks;
using ProjectName.Api.ViewModel;

namespace ProjectName.Api.Application.Queries
{
    public interface IBlogQueries
    {
        public Task<BlogViewModel> GetAsync(int Id);
    }
}
