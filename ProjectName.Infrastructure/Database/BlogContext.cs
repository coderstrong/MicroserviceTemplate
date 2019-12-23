using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.AggregatesModel.PostAggregate;
using ProjectName.Domain.SeedWork;
using ProjectName.Infrastructure.Database.Configurations;
using ProjectName.Infrastructure.Utils;

namespace ProjectName.Infrastructure.Database
{
    public class BlogContext : DbContext, IUnitOfWork, IDisposable
    {
        public const string DefaultSchema = "BlogSample";

        private readonly IMediator _mediator;
        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<PostStatus> PostStatus { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PostStatusEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagConfiguration());
            modelBuilder.ApplyConfiguration(new TagEntityConfiguration());
        }

        public Guid OperationId()
        {
            return this.ContextId.InstanceId;
        }

        public DbSet<T> Repository<T>() where T : Entity
        {
            return Set<T>();
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync<BlogContext>(this);

            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
