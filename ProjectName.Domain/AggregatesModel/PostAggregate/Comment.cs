using System;
using System.Collections.Generic;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.PostAggregate
{
    public class Comment : Entity
    {
        public int? ParentId { get; private set; }

        public Post Post { get; private set; }

        public int PostId { get; private set; }

        public DateTime Date { get; private set; }

        public string Author { get; private set; }

        public string EmailAddress { get; private set; }

        public string Content { get; private set; }


    }
}
