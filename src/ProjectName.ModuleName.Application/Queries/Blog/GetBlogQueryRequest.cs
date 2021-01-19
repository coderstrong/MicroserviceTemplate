using MediatR;
using System;

namespace ProjectName.ModuleName.Application.Queries
{
    public class GetBlogQueryRequest : IRequest<GetBlogQueryResponseModel>
    {
        public Guid Id { get; set; }
    }
}