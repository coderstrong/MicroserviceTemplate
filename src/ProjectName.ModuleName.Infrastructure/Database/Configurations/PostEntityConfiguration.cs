using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.ModuleName.Domain.Entities;

namespace ProjectName.ModuleName.Infrastructure.Database.Configurations
{
    public class PostEntityConfiguration
        : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post", ProjectNameModuleNameContext.DefaultSchema);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Property(m => m.Title).HasMaxLength(300).IsRequired();
            builder.Property(m => m.Content).HasColumnType("text").IsRequired();
            builder.Property(m => m.Status).IsRequired();
        }
    }
}
