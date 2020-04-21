using System;
using System.Collections.Generic;
using ProjectName.Domain.Common;

namespace ProjectName.Domain.Entities
{
    public class Comment : ValueObject
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public int PostId { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }

        public string EmailAddress { get; set; }

        public string Content { get; set; }

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
