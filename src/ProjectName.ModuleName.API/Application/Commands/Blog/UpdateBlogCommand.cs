using System;
using System.Collections.Generic;
using MediatR;
using ProjectName.ModuleName.Domain.Entities;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class UpdateBlogCommand : IRequest<Blog>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<Post> Posts { get; set; }
        public Guid Id { get; set; }
    }
}
