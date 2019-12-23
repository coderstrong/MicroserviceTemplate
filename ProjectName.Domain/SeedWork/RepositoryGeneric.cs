using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProjectName.Domain.SeedWork
{
    public class RepositoryGeneric<C, E> : Disposable, IRepositoryGeneric<C, E>
        where C : DbContext, IUnitOfWork
        where E : Entity
    {
        private readonly ILogger<RepositoryGeneric<C, E>> _logger;
        private readonly C _context;

        public RepositoryGeneric(C context, ILogger<RepositoryGeneric<C, E>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public void Delete(object key)
        {
            var entity = _context.Repository<E>().Find(key);
            if (entity != null)
                _context.Repository<E>().Remove(entity);
        }

        public async Task<List<E>> GetAllAsync(int top = 20, int skip = 0)
        {
            if (top > 0)
            {
                return await _context.Repository<E>().OrderBy(x => x.Id).Skip(skip).Take(top).AsNoTracking().ToListAsync();
            }
            else
            {
                return await _context.Repository<E>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<E> GetOneAsync(object key)
        {
            return await _context.Repository<E>().FindAsync(key);
        }

        public void Insert(E entity)
        {
            _context.Repository<E>().Add(entity);
        }

        public void InsertRange(IEnumerable<E> entitys)
        {
            _context.Repository<E>().AddRange(entitys);
        }

        public void Update(E entity)
        {
            _context.Repository<E>().Update(entity);
        }
    }
}
