using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectName.Infrastructure.Database
{
    public class BaseServiceGeneric<T> : Disposable, IBaseServiceGeneric<T> where T : BaseModel
    {
        private IUnitOfWorkGeneric<ProfileContext> _unitOfWork;
        public BaseServiceGeneric(IUnitOfWorkGeneric<ProfileContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(T entity)
        {
            _unitOfWork.Repository<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll(int top = 0, int skip = 20)
        {
            if (top > 0)
            {
                return await _unitOfWork.Repository<T>().OrderBy(x => x.Id).Skip(skip).Take(top).ToListAsync();
            }
            else
            {
                return await _unitOfWork.Repository<T>().ToListAsync();
            }

        }

        public async Task<T> GetOne(object key)
        {
            return await _unitOfWork.Repository<T>().FindAsync(key);
        }

        public void Insert(T entity)
        {
            _unitOfWork.Repository<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _unitOfWork.Repository<T>().Update(entity);
        }
    }
}
