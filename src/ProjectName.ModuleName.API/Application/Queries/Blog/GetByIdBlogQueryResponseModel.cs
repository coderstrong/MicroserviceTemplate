using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public class GetBlogByIdQueryResponseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}