using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectName.Domain.AggregatesModel.PostAggregate;
using ProjectName.Domain.SeedWork;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Application.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, bool>
    {
        private readonly IRepositoryGeneric<BlogContext, Post> _post;

        public CreatePostCommandHandler(IRepositoryGeneric<BlogContext, Post> post)
        {
            _post = post;
        }

        public async Task<bool> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = new Post(request.Title, request.Author, request.Content, PostStatus.Draft);
            
            _post.Insert(post);

            return await _post.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
