using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.Domain.AggregatesModel.BlogAggregate;

namespace ProjectName.Infrastructure.Database.Configurations
{
    public class BlogEntityConfiguration
        : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blog", BlogContext.DefaultSchema);
            builder.HasKey(m => m.Id);
        }
    }
}
