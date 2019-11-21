using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    public interface IUnitOfWorkGeneric<T> where T : DbContext, IContext, IDisposable
    {
        T GetContext(bool isMultiThread = false);

        void Dispose();

        DbSet<TEntity> Repository<TEntity>() where TEntity : BaseModel;

        DbQuery<TEntity> RepositoryQuery<TEntity>() where TEntity : BaseModel;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}