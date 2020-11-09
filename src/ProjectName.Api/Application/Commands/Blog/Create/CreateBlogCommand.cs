using MediatR;
using ProjectName.API.Model;

namespace ProjectName.API.Application.Commands
{
    public class CreateBlogCommand : IRequest<BlogResponseModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
