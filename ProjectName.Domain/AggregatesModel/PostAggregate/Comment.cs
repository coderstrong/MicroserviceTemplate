using System;
using System.Collections.Generic;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.AggregatesModel.PostAggregate
{
    public class Comment : ValueObject
    {
        public Post Post { get; private set; }

        public int PostId { get; private set; }

        public DateTime Date { get; private set; }

        public string Author { get; private set; }

        public string EmailAddress { get; private set; }

        public string Content { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            // Using a yield return statement to return each element one at a time
            yield return Post;
            yield return PostId;
            yield return Date;
            yield return Author;
            yield return EmailAddress;
            yield return Content;
        }
    }
}
