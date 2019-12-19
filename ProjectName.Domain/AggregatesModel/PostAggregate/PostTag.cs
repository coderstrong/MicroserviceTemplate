using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectName.Domain.AggregatesModel.PostAggregate
{
    public class PostTag
    {
        public Post Post { get; set; }
        public int PostId { get; set; }

        public Tag Tag { get; set; }
        public int TagId { get; set; }

        public PostTag(int postId, int tagId)
        {
            this.PostId = postId;
            this.TagId = tagId;
        }
    }
}
