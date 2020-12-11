using MediatR;
using ProjectName.ModuleName.Domain.Entities;
using System;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class UpdatePostTagCommand : IRequest<PostTag>
    {
        public Post Post { get; set; }
        public Guid PostId { get; set; }
        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}
