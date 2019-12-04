using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    public class PortalContext : DbContext, IContext, IDisposable
    {
        public PortalContext(DbContextOptions<PortalContext> options) : base(options)
        {
        }

        private IDbContextTransaction _transaction;
        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public Guid OperationId() { return this.ContextId.InstanceId; }
        public DbSet<T> Repository<T>() where T : class
        {
            return Set<T>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
        }
    }
}