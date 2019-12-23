using System.Collections.Generic;
using ProjectName.Domain.AggregatesModel.BlogAggregate;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.PostAggregate
{
    public class Post : Entity
    {
        public string Title { get; private set; }

        public string Author { get; private set; }

        public string Content { get; private set; }

        public virtual PostStatus Status { get; private set; }
        public int StatusId { get; private set; }

        public virtual Blog Blog { get; private set; }
        public int BlogId { get; private set; }

        private readonly List<Comment> _comments;
        public IReadOnlyList<Comment> Comments => _comments;


        private readonly List<PostTag> _postTags;
        public IReadOnlyList<PostTag> PostTags => _postTags;


        public Post()
        {
            this._comments = new List<Comment>();
            this._postTags = new List<PostTag>();
        }

        public Post(string title, string author, string content, PostStatus postStatus)
        {
            this.Title = title;
            this.Author = author;
            this.Content = content;
            this.StatusId = postStatus.Id;
        }

        public void AddTag(int tagId)
        {
            this._postTags.Add(new PostTag(this.Id, tagId));
        }
    }
}
