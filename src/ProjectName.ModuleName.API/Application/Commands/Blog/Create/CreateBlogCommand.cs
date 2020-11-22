using MediatR;
using ProjectName.ModuleName.Domain.Entities;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class CreateBlogCommand : IRequest<Blog>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
