using MediatR;
using ProjectName.ModuleName.Domain.Entities;
using System;

namespace ProjectName.ModuleName.Application.Commands
{
    public class UpdateBlogCommand : IRequest<Blog>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}