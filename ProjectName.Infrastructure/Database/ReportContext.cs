using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    public class ReportContext : DbContext, IContext, IDisposable
    {
        public ReportContext(DbContextOptions<ReportContext> options) : base(options)
        {
        }
        public Guid OperationId
        {
            get { return OperationId; }
            set { OperationId = OperationId == null ? Guid.NewGuid() : OperationId; }
        }
        private IDbContextTransaction _transaction;
        public virtual DbSet<Report> Reports { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public DbSet<T> Repository<T>() where T : class
        {
            return Set<T>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public ReportContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ReportContext>();
            return new ReportContext(builder.Options);
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