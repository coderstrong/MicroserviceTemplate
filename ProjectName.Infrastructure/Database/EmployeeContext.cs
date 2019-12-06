using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectName.Domain.AggregatesModel.EmployeeAggregate;

namespace ProjectName.Infrastructure.Database
{
    public class EmployeeContext : DbContext, IContext, IDisposable
    {
        public const string DefaultSchema = "Employee";

        private IDbContextTransaction _transaction;

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmployeeTypes> EmployeesTypes { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

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
