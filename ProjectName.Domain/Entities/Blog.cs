using System.Collections.Generic;
using System.Linq;
using ProjectName.Domain.AggregatesModel.PostAggregate;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.BlogAggregate
{
    public class Blog : Entity, IAggregateRoot
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        private readonly List<Post> _Posts;

        public IReadOnlyList<Post> Posts => this._Posts;

        public Blog()
        {
            this._Posts = new List<Post>();
        }

        public Blog(string Title, string Description, List<Post> Posts)
        {
            this.Title = Title;
            this.Description = Description;
            this._Posts = Posts;
        }

        public void AddPost(Post post)
        {
            var existProject = this.Posts.Where(o => o.Id == post.Id).SingleOrDefault();
            if (existProject == null)
            {
                this._Posts.Add(post);
            }
        }
    }
}
