using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.Domain.Entities;

namespace ProjectName.Infrastructure.Database.Configurations
{
    public class PostStatusEntityConfiguration
        : IEntityTypeConfiguration<PostStatus>
    {
        public void Configure(EntityTypeBuilder<PostStatus> builder)
        {
            builder.ToTable("PostStatus", BlogContext.DefaultSchema);
            builder.HasKey(m => m.Id);
        }
    }
}
