using System;
using System.Collections.Generic;
using ProjectName.Domain.Common;

namespace ProjectName.Domain.Entities
{
    public class Tag : Entity
    {
        public string Name { get; private set; }

        public virtual List<PostTag> PostTags { get; set; }
        public Guid Id { get; set; }

        public Tag(string Name)
        {
            this.Name = Name;
            this.PostTags = new List<PostTag>();
        }
    }
}
