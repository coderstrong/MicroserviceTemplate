using System.Collections.Generic;
using ProjectName.Domain.Common;

namespace ProjectName.Domain.Entities
{
    public class Post : Entity
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public virtual PostStatus Status { get; set; }
        public int StatusId { get; set; }

        public virtual Blog Blog { get; set; }
        public int BlogId { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<PostTag> PostTags { get; set; }

        public Post()
        {
            this.Comments = new List<Comment>();
            this.PostTags = new List<PostTag>();
        }

        public Post(string title, string author, string content, PostStatus postStatus)
        {
            this.Title = title;
            this.Author = author;
            this.Content = content;
            this.StatusId = postStatus.Id;
        }
    }
}
