namespace ProjectName.ModuleName.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ProjectName.ModuleName.Domain.Common;
    using ProjectName.ModuleName.Domain.Exceptions;

    public class PostStatus
        : Enumeration
    {
        public static PostStatus Draft = new PostStatus(1, nameof(Draft).ToLowerInvariant());
        public static PostStatus Published = new PostStatus(2, nameof(Published).ToLowerInvariant());
        public static PostStatus Deleted = new PostStatus(3, nameof(Deleted).ToLowerInvariant());

        public PostStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<PostStatus> List() =>
            new[] { Draft, Published, Deleted };

        public static PostStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new BlogDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static PostStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new BlogDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
