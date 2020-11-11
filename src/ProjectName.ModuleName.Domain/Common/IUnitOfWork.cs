using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectName.ModuleName.Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Guid OperationId();

        DbSet<T> Repository<T>() where T : Entity;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
