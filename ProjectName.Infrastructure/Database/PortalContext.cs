using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.Common;

namespace ProjectName.Infrastructure.Database
{
    public class PortalContext : DbContext, IUnitOfWork, IDisposable
    {
        public PortalContext(DbContextOptions<PortalContext> options) : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }

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
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
