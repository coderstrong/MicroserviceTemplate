using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectName.Domain.AggregatesModel.BlogAggregate;
using ProjectName.Domain.AggregatesModel.PostAggregate;

namespace ProjectName.Api.Application.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, bool>
    {
        private readonly IPostRepository _post;

        public CreatePostCommandHandler(IPostRepository post)
        {
            _post = post;
        }

        public async Task<bool> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = new Post(request.Title, request.Author, request.Content, PostStatus.Draft);
            foreach (var item in request.Tags)
            {
                post.AddTag(item);
            }
            _post.Add(post);
            return await _post.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
