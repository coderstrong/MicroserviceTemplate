using System;

namespace ProjectName.ModuleName.Application.Queries
{
    public class GetBlogByIdQueryResponseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}