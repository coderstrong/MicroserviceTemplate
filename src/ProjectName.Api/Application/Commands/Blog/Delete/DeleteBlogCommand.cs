using System;
using MediatR;

namespace ProjectName.Api.Application.Commands
{
    public class DeleteBlogCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
