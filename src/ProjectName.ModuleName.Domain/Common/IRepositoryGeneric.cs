using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectName.ModuleName.Domain.Common
{
    public interface IRepositoryGeneric<C, E> : IDisposable
        where C : IUnitOfWork
        where E : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Get row by primary key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<E> GetOneAsync(object key);

        /// <summary>
        /// Get data from Database
        /// </summary>
        /// <param name="filter">Condiction filter</param>
        /// <param name="orderBy">Sort Data result</param>
        /// <param name="includeProperties">Properties include use comma Ex: "UserInfo,Address"</param>
        /// <returns></returns>
        Task<List<E>> GetAllAsync(Expression<Func<E, bool>> filter = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null,
            string includeProperties = "", Pagination paging = null);

        /// <summary>
        ///  Get data from Database and auto mapper to Model M
        /// </summary>
        /// <typeparam name="M"></typeparam>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="top"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        /// <exception cref="">Miss config Automapper</exception>
        Task<List<M>> GetAllAsync<M>(Expression<Func<E, bool>> filter = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null,
            string includeProperties = "", Pagination paging = null);

        /// <summary>
        ///  Get IQueryable from Entity
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="top"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        IQueryable<E> GetQueryable(Expression<Func<E, bool>> filter = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null,
            string includeProperties = "", Pagination paging = null);

        /// <summary>
        /// Insert data to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        E Insert(E entity);

        /// <summary>
        /// Insert range to database
        /// </summary>
        /// <param name="entity"></param>
        void InsertRange(IEnumerable<E> entity);

        /// <summary>
        /// Update data to database
        /// </summary>
        /// <param name="entity"></param>
        void Update(E entity);

        /// <summary>
        /// Delete data to database
        /// </summary>
        /// <param name="key"></param>
        void Delete(object key);
    }
}
