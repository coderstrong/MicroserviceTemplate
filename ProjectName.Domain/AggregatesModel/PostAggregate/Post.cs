using System.Collections.Generic;
using ProjectName.Domain.AggregatesModel.BlogAggregate;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.PostAggregate
{
    public class Post : Entity, IAggregateRoot
    {
        public string Title { get; private set; }

        public string Author { get; private set; }

        public string Content { get; private set; }

        public PostStatus Status { get; private set; }
        public int StatusId { get; private set; }

        public Blog Blog { get; private set; }
        public int BlogId { get; private set; }

        private readonly List<Comment> _comments;

        public IReadOnlyList<Comment> Comments => _comments;

        private readonly List<Tag> _tags;

        public IReadOnlyList<Tag> Tags => _tags;

        public Post()
        {
            this._comments = new List<Comment>();
            this._tags = new List<Tag>();
        }

        public Post(string title, string author, string content, PostStatus postStatus)
        {
            this.Title = title;
            this.Author = author;
            this.Content = content;
            this.Status = postStatus;
            this.StatusId = postStatus.Id;
        }

        public void AddTag(string name)
        {
            this._tags.Add(new Tag(name));
        }
    }
}
