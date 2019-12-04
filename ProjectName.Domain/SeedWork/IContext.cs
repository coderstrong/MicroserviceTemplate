using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    public interface IContext : IDisposable
    {
        Guid OperationId();

        DbSet<T> Repository<T>() where T : class;

        void BeginTransaction();

        void Commit();

        void Rollback();

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
