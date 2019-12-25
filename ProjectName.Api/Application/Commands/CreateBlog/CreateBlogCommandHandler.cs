using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectName.Domain.Entities;
using ProjectName.Domain.SeedWork;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Application.Commands
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Blog>
    {
        private readonly IRepositoryGeneric<BlogContext, Blog> _blog;

        public CreateBlogCommandHandler(IRepositoryGeneric<BlogContext, Blog> blog)
        {
            _blog = blog;
        }

        public async Task<Blog> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog blog = new Blog()
            {
                Title = "Test Blog",
                Description = "Blog về thiên nhiên"
            };

            blog = _blog.Insert(blog);

            await _blog.UnitOfWork.SaveEntitiesAsync();

            return blog;
        }
    }
}
