using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.Domain.AggregatesModel.PostAggregate;

namespace ProjectName.Infrastructure.Database.Configurations
{
    public class PostTagConfiguration
        : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.ToTable("PostTag", BlogContext.DefaultSchema);
            builder.HasKey(bt => new { bt.PostId, bt.TagId });
            builder.HasOne(bt => bt.Post)
                .WithMany(b => b.PostTags)
                .HasForeignKey(bt => bt.TagId);
            builder.HasOne(bt => bt.Tag)
                .WithMany(c => c.PostTags)
                .HasForeignKey(bc => bc.PostId);
        }
    }
}
