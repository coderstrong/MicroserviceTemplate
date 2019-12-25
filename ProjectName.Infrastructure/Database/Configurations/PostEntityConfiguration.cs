using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectName.Domain.Entities;

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

            builder.OwnsMany(m => m.Comments, n =>
            {
                n.ToTable("Comment", BlogContext.DefaultSchema);
                n.WithOwner().HasForeignKey("PostId");
                n.HasKey(x => x.Id);
                n.Property(m => m.Author).HasMaxLength(200);
                n.Property(m => m.Content).HasMaxLength(500);
                n.Property(m => m.EmailAddress).HasMaxLength(255);
            });

            builder.HasOne(m => m.Status).WithMany().HasForeignKey(m => m.StatusId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
