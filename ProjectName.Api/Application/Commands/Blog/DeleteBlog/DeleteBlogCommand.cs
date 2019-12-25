using MediatR;

namespace ProjectName.Api.Application.Commands
{
    public class DeleteBlogCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
