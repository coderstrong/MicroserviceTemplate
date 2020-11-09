using System;

namespace ProjectName.API.Model
{
    public class PostResponseModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public string Status { get; set; }
    }
}
