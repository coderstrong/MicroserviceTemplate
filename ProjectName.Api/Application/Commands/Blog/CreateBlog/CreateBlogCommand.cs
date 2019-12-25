using MediatR;
using ProjectName.Api.ViewModel;

namespace ProjectName.Api.Application.Commands
{
    public class CreateBlogCommand : IRequest<BlogViewModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
