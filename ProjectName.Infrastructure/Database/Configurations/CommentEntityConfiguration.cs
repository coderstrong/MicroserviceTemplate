using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.Domain.AggregatesModel.PostAggregate;

namespace ProjectName.Infrastructure.Database.Configurations
{
    public class CommentEntityConfiguration
        : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment", BlogContext.DefaultSchema);
            builder.HasKey(m => m.Id);
        }
    }
}
