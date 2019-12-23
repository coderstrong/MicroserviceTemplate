using System.Threading.Tasks;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.BlogAggregate
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Blog Add(Blog blog);

        void Update(Blog blog);

        Task<Blog> GetAsync(int blogId);
    }
}
