using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.ModuleName.Domain.Entities;

namespace ProjectName.ModuleName.Infrastructure.Database.Configurations
{
    public class BlogEntityConfiguration
        : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blog", ProjectNameModuleNameContext.DefaultSchema);
            builder.HasKey(m => m.Id);
        }
    }
}
