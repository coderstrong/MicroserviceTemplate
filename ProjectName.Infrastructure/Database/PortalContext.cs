using System;
using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Infrastructure.Database
{
    public class PortalContext : DbContext, IContext, IDisposable
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
    }
}
