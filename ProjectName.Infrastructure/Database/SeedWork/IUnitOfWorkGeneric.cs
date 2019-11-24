using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    public interface IUnitOfWorkGeneric<C> where C : DbContext, IContext, IDisposable
    {
        C GetContext(bool isMultiThread = false);

        void Dispose();

        DbSet<TEntity> Repository<TEntity>() where TEntity : BaseModel;

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}