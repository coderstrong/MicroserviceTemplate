using MediatR;
using ProjectName.Domain.Entities;

namespace ProjectName.Api.Application.Commands
{
    public class CreatePostCommand : IRequest<Post>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
    }
}
