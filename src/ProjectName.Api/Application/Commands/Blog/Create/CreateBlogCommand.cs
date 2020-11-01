using MediatR;
using ProjectName.Api.Model;

namespace ProjectName.Api.Application.Commands
{
    public class CreateBlogCommand : IRequest<BlogResponseModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
