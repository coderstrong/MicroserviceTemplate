using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    public interface IRepositoryGeneric<C, E> : IDisposable
        where C : IContext
        where E : BaseModel
    {
        Task<E> GetOneAsync(object key);

        Task<List<E>> GetAllAsync(int top = 20, int skip = 0);

        void Insert(E entity);

        void InsertRange(IEnumerable<E> entity);

        void Update(E entity);

        void Delete(object key);
    }
}