using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.Domain.AggregatesModel.PostAggregate;

namespace ProjectName.Infrastructure.Database.Configurations
{
    public class PostEntityConfiguration
        : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post", BlogContext.DefaultSchema);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Ignore(m => m.DomainEvents);
            builder.Property(m => m.Title).HasMaxLength(300).IsRequired();
            builder.Property(m => m.Content).HasColumnType("text").IsRequired();
            builder.Property(m => m.StatusId).IsRequired();

            builder.HasMany(m => m.Comments).WithOne(m => m.Post)
                .IsRequired(false).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Status).WithMany().HasForeignKey(m => m.StatusId).OnDelete(DeleteBehavior.Restrict);
        }
    }

    
}
