using System;
using MediatR;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public class GetBlogByIdRequest : IRequest<GetBlogByIdResponseModel>
    {
        public Guid Id { get; set; }
    }
}
