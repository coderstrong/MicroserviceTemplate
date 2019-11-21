using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    public class UnitOfWorkGeneric<T> : IUnitOfWorkGeneric<T> where T : DbContext, IContext, IDisposable
    {
        private bool disposed = false;

        private readonly T _dataContext;
        private readonly IOptions<ConnectionStringsSetting> _connOptions;

        public UnitOfWorkGeneric(T dataContext, IOptions<ConnectionStringsSetting> connOptions)
        {
            _dataContext = dataContext;
            _connOptions = connOptions;
        }

        public DbSet<TEntity> Repository<TEntity>() where TEntity : BaseModel
        {
            return _dataContext.Repository<TEntity>();
        }

        public T GetContext(bool isMultiThread = false)
        {
            if (!isMultiThread) return _dataContext as T;
            return _dataContext as T;
        }

        public DbQuery<TEntity> RepositoryQuery<TEntity>() where TEntity : BaseModel
        {
            return _dataContext.RepositoryQuery<TEntity>();
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _dataContext?.Database?.CloseConnection();
                _dataContext.Dispose();
            }

            disposed = true;
        }
    }
}