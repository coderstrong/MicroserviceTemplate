using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    public class UnitOfWorkGeneric<T> : IUnitOfWorkGeneric<T> where T : DbContext, IContext, IDisposable
    {
        private bool disposed = false;

        private readonly T _dataContext;
        private readonly ILogger<UnitOfWorkGeneric<T>> _logger;

        public UnitOfWorkGeneric(T dataContext, ILogger<UnitOfWorkGeneric<T>> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
            _logger.LogInformation(_dataContext.OperationId.ToString());
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

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            return await _dataContext.SaveChangesAsync(cancellationToken);
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