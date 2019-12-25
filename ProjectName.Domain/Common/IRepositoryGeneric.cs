using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectName.Domain.Common
{
    public interface IRepositoryGeneric<C, E> : IDisposable
        where C : IUnitOfWork
        where E : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<E> GetOneAsync(object key);

        Task<List<E>> GetAllAsync(int top = 20, int skip = 0);

        E Insert(E entity);

        void InsertRange(IEnumerable<E> entity);

        void Update(E entity);

        void Delete(object key);
    }
}
