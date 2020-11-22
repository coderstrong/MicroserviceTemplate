using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.ModuleName.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Guid OperationId();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
