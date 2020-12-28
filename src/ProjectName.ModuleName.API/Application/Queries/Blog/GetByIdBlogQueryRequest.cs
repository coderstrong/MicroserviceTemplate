using System;
using MediatR;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public class GetBlogByIdQueryRequest : IRequest<GetBlogByIdQueryResponseModel>
    {
        public Guid Id { get; set; }
    }
}