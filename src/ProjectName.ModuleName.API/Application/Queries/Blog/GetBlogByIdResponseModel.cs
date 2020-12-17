using System;

namespace ProjectName.ModuleName.API.Application.Queries
{
    public class GetBlogByIdResponseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}
