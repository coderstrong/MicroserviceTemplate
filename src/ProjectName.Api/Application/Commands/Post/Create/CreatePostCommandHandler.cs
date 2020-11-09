using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectName.API.Model;
using ProjectName.Domain.Common;
using ProjectName.Domain.Entities;
using ProjectName.Infrastructure.Database;

namespace ProjectName.API.Application.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostResponseModel>
    {
        private readonly IRepositoryGeneric<BlogContext, Post> _post;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IRepositoryGeneric<BlogContext, Post> post, IMapper mapper)
        {
            _post = post;
            _mapper = mapper;
        }

        public async Task<PostResponseModel> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = new Post(request.Title, request.Author, request.Content, PostStatus.Draft);
            post.BlogId = 3;
            var posted = _post.Insert(post);

            await _post.UnitOfWork.SaveEntitiesAsync();

            return _mapper.Map<PostResponseModel>(posted);
        }
    }
}
