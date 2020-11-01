using MediatR;
using ProjectName.Api.Model;

namespace ProjectName.Api.Application.Commands
{
    public class CreatePostCommand : IRequest<PostResponseModel>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
    }
}
