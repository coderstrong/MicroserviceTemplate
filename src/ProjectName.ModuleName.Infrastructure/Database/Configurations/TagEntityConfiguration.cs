using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.ModuleName.Domain.Entities;

namespace ProjectName.ModuleName.Infrastructure.Database.Configurations
{
    public class TagEntityConfiguration
        : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag", BlogContext.DefaultSchema);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(50);
        }
    }
}
