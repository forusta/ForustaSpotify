using ForustaSpotify.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForustaSpotify.DataAccess.Repositories.Base
{
    /// <summary>
    /// Base repository for CRUD operations
    /// </summary>
    public interface IBaseRepository
    {
        /// <summary>
        /// Retrieves collection of database entities
        /// </summary>
        /// <typeparam name="TEntity">Object ob BaseEntity</typeparam>
        /// <param name="filter">Data filtering expression</param>
        /// <param name="includedProperties">String of entity's properties chain. To get navigation properties</param>
        /// <param name="orderBy">Data ordering expression</param>
        /// <param name="skip">Amount of skipped entities</param>
        /// <param name="take">Amount of taken entities</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns table query's result</returns>
        Task<ICollection<TEntity>> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includedProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            CancellationToken cancellationToken = default)
            where TEntity : class, IBaseEntity;

        /// <summary>
        /// Retrieves single database entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="filter"></param>
        /// <param name="includedProperties"></param>
        /// <param name="orderBy"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TEntity> GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includedProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            CancellationToken cancellationToken = default)
            where TEntity : class, IBaseEntity;

        /// <summary>
        /// Marks entity added to database
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Add<TEntity>(TEntity entity)
            where TEntity : class, IBaseEntity;

        /// <summary>
        /// Marks entity updated to database
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Update<TEntity>(TEntity entity)
            where TEntity : class, IBaseEntity;

        /// <summary>
        /// Marks entity deleted to database
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Delete<TEntity>(TEntity entity)
            where TEntity : class, IBaseEntity;

        /// <summary>
        /// Marks entity deleted to dataabase by its ID
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        void DeleteById<TEntity>(object id)
            where TEntity : class, IBaseEntity;

        /// <summary>
        /// Saves any changes to database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Save(CancellationToken cancellationToken = default);
    }
}
