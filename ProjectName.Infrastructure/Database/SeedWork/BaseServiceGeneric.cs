using Microsoft.EntityFrameworkCore;
using ProjectName.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectName.Bussiness.Services
{
    public class BaseServiceGeneric<C, E> : Disposable, IBaseServiceGeneric<C, E>
        where C : DbContext, IContext, IDisposable
        where E : BaseModel
    {
        protected readonly IUnitOfWorkGeneric<C> _unitOfWork;

        public BaseServiceGeneric(IUnitOfWorkGeneric<C> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(object key)
        {
            var entity = _unitOfWork.Repository<E>().Find(key);
            if (entity != null)
                _unitOfWork.Repository<E>().Remove(entity);
        }

        public async Task<List<E>> GetAllAsync(int top = 0, int skip = 20)
        {
            if (top > 0)
            {
                return await _unitOfWork.Repository<E>().OrderBy(x => x.Id).Skip(skip).Take(top).AsNoTracking().ToListAsync();
            }
            else
            {
                return await _unitOfWork.Repository<E>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<E> GetOneAsync(object key)
        {
            return await _unitOfWork.Repository<E>().FindAsync(key);
        }

        public void Insert(E entity)
        {
            _unitOfWork.Repository<E>().Add(entity);
        }

        public void InsertRange(IEnumerable<E> entitys)
        {
            _unitOfWork.Repository<E>().AddRange(entitys);
        }

        public void Update(E entity)
        {
            _unitOfWork.Repository<E>().Update(entity);
        }
    }
}