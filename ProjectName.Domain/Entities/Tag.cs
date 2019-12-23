using System.Collections.Generic;
using System.Text;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.PostAggregate
{
    public class Tag : Entity
    {
        public string Name { get; private set; }

        private readonly List<PostTag> _postTags;
        public IReadOnlyList<PostTag> PostTags => _postTags;

        public Tag(string Name)
        {
            this.Name = Name;
        }

    }
}
