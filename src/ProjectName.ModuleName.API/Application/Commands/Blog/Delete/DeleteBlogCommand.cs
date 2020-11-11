using System;
using MediatR;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class DeleteBlogCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
