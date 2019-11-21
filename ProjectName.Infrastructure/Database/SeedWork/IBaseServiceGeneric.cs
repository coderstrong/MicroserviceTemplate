using ProjectName.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectName.Infrastructure.Database
{
    interface IBaseServiceGeneric<T> : IDisposable where T : BaseModel
    {
        Task<T> GetOne(object key);

        Task<List<T>> GetAll(int top = 0, int skip = -1);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
