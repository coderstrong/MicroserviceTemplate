using MediatR;
using System;
using System.Collections.Generic;

namespace ProjectName.ModuleName.Application.Queries
{
    public class GetBlogQueryRequest : IRequest<IEnumerable<GetBlogQueryResponseModel>>
    {
        public Guid Id { get; set; }
    }
}