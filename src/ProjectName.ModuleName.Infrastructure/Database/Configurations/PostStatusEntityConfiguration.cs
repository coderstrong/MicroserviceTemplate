using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.ModuleName.Domain.Entities;

namespace ProjectName.ModuleName.Infrastructure.Database.Configurations
{
    public class PostStatusEntityConfiguration
        : IEntityTypeConfiguration<PostStatus>
    {
        public void Configure(EntityTypeBuilder<PostStatus> builder)
        {
            builder.ToTable("PostStatus", ProjectNameModuleNameContext.DefaultSchema);
            builder.HasKey(m => m.Id);
        }
    }
}
