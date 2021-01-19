using System;
using System.Collections.Generic;
using ProjectName.ModuleName.Domain.SeedWork;

namespace ProjectName.ModuleName.Domain.Entities
{
    public class Blog : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public virtual List<Post> Posts { get; set; }
        public Guid Id { get; set; }
    }
}
