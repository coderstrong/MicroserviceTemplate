using MediatR;
using ProjectName.Domain.Entities;

namespace ProjectName.Api.Application.Commands
{
    public class CreateBlogCommand : IRequest<Blog>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
