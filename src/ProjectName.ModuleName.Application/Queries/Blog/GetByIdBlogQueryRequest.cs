using MediatR;
using System;

namespace ProjectName.ModuleName.Application.Queries
{
    public class GetBlogByIdQueryRequest : IRequest<GetBlogByIdQueryResponseModel>
    {
        public Guid Id { get; set; }
    }
}