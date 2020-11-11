using System;
using MediatR;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class UpdateBlogCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}