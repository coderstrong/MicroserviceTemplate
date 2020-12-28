using System;
using MediatR;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public class GetBlogQueryRequest : IRequest<GetBlogQueryResponseModel>
    {
        public Guid Id { get; set; }
    }
}