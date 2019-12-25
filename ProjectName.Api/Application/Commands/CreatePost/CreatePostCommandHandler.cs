using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectName.Domain.Entities;
using ProjectName.Domain.SeedWork;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Application.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Post>
    {
        private readonly IRepositoryGeneric<BlogContext, Post> _post;

        public CreatePostCommandHandler(IRepositoryGeneric<BlogContext, Post> post)
        {
            _post = post;
        }

        public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = new Post(request.Title, request.Author, request.Content, PostStatus.Draft);
            
            var test = _post.Insert(post);

            await _post.UnitOfWork.SaveEntitiesAsync();

            return test;
        }
    }
}
