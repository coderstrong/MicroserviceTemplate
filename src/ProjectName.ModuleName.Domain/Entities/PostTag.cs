using System;

namespace ProjectName.ModuleName.Domain.Entities
{
    public class PostTag
    {
        public Post Post { get; set; }
        public Guid PostId { get; set; }

        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}
