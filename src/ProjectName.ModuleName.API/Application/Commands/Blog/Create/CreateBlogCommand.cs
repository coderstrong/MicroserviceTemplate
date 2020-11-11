using MediatR;
using ProjectName.ModuleName.API.Model;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class CreateBlogCommand : IRequest<BlogResponseModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
