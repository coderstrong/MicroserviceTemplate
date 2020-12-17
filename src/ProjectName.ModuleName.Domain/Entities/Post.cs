using System;
using System.Collections.Generic;
using ProjectName.ModuleName.Domain.SeedWork;

namespace ProjectName.ModuleName.Domain.Entities
{
    public class Post : Entity
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }
        public virtual Blog Blog { get; set; }
        public int BlogId { get; set; }

        public virtual List<PostTag> PostTags { get; set; }
        public Guid Id { get; set; }

        public Post()
        {
            this.PostTags = new List<PostTag>();
        }

        public Post(string title, string author, string content, PostStatus postStatus)
        {
            this.Title = title;
            this.Author = author;
            this.Content = content;
            this.Status = postStatus.Id;
        }
    }
}
