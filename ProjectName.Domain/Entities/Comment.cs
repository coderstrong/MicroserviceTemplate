using System;
using System.Collections.Generic;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Domain.Entities
{
    public class Comment : ValueObject
    {
        public int Id { get; set; }

        public int? ParentId { get; private set; }

        public int PostId { get; private set; }

        public DateTime Date { get; private set; }

        public string Author { get; private set; }

        public string EmailAddress { get; private set; }

        public string Content { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return ParentId;
            yield return PostId;
            yield return Date;
            yield return Author;
            yield return EmailAddress;
            yield return Content;
        }
    }
}
