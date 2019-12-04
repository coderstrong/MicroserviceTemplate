using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectName.Domain.SeedWork;

namespace ProjectName.Infrastructure.Database
{
    public interface IRepositoryGeneric<C, E> : IDisposable
        where C : IContext
        where E : Entity
    {
        Task<E> GetOneAsync(object key);

        Task<List<E>> GetAllAsync(int top = 20, int skip = 0);

        void Insert(E entity);

        void InsertRange(IEnumerable<E> entity);

        void Update(E entity);

        void Delete(object key);
    }
}
