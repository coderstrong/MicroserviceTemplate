using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    public class ProfileContext : DbContext, IContext, IDisposable
    {
        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options)
        {
        }
        public Guid OperationId
        {
            get { return OperationId; }
            set { OperationId = OperationId == null ? Guid.NewGuid() : OperationId; }
        }
        private IDbContextTransaction _transaction;
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Contract> Contracts { get; set; }
        

        public DbSet<T> Repository<T>() where T : class
        {
            return Set<T>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public ProfileContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProfileContext>();
            return new ProfileContext(builder.Options);
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
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}