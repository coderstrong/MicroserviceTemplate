using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.AggregatesModel.PostAggregate;
using ProjectName.Domain.SeedWork;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogContext _context;

        public PostRepository(BlogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public Post Add(Post order)
        {
            return _context.Posts.Add(order).Entity;
        }

        public async Task<Post> GetAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
            {
                await _context.Entry(post).Collection(i => i.Comments).LoadAsync();
                await _context.Entry(post).Reference(i => i.Tags).LoadAsync();
            }
            return post;
        }

        public void Update(Post order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }
    }
}
