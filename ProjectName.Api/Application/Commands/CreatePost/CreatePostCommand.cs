using MediatR;

namespace ProjectName.Api.Application.Commands
{
    public class CreatePostCommand : IRequest<bool>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public int[] Tags { get; set; }
    }
}
