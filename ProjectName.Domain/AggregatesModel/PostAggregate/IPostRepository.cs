using System.Threading.Tasks;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.PostAggregate
{
    public interface IPostRepository : IRepository<Post>
    {
        Post Add(Post post);

        void Update(Post post);

        Task<Post> GetAsync(int postId);
    }
}
