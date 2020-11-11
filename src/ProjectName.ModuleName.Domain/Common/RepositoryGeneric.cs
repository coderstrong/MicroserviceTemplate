using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProjectName.ModuleName.Domain.Common
{
    public class RepositoryGeneric<C, E> : Disposable, IRepositoryGeneric<C, E>
        where C : DbContext, IUnitOfWork
        where E : Entity
    {
        private readonly ILogger<RepositoryGeneric<C, E>> _logger;
        private readonly C _context;
        private readonly IMapper _mapper;

        public RepositoryGeneric(C context, ILogger<RepositoryGeneric<C, E>> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
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

        public async Task<List<E>> GetAllAsync(
           Expression<Func<E, bool>> filter = null,
           Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null,
           string includeProperties = "", Pagination paging = null)
        {
            IQueryable<E> query = _context.Repository<E>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);

                if (paging != null)
                {
                    paging.TotalItem = query.Count();
                    query = query.Skip(paging.Skip).Take(paging.PageSize);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<List<M>> GetAllAsync<M>(
            Expression<Func<E, bool>> filter = null,
            Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null,
            string includeProperties = "", Pagination paging = null)
        {
            IQueryable<E> query = _context.Repository<E>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
                if (paging != null)
                {
                    paging.TotalItem = query.Count();
                    query = query.Skip(paging.Skip).Take(paging.PageSize);
                }
            }

            return await query.AsNoTracking().ProjectTo<M>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<E> GetOneAsync(object key)
        {
            return await _context.Repository<E>().FindAsync(key);
        }

        public IQueryable<E> GetQueryable(Expression<Func<E, bool>> filter = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null, string includeProperties = "", Pagination paging = null)
        {
            IQueryable<E> query = _context.Repository<E>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
                if (paging != null)
                {
                    paging.TotalItem = query.Count();
                    query = query.Skip(paging.Skip).Take(paging.PageSize);
                }
            }

            return query.AsNoTracking();
        }

        public E Insert(E entity)
        {
            return _context.Repository<E>().Add(entity).Entity;
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