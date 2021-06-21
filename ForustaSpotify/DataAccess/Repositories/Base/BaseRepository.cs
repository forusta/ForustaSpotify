using ForustaSpotify.Data.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForustaSpotify.DataAccess.Repositories.Base
{
    public class BaseRepository<TContext> : IBaseRepository
        where TContext : DbContext
    {
        protected readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        protected virtual IQueryable<TEntity> PrepareQueryable<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includedProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
            where TEntity : class, IBaseEntity
        {
            includedProperties = includedProperties ?? string.Empty;

            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includedProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public async virtual Task<ICollection<TEntity>> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includedProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            CancellationToken cancellationToken = default)
            where TEntity : class, IBaseEntity
        {
            return await PrepareQueryable(filter, includedProperties, orderBy, skip, take)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public async virtual Task<TEntity> GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includedProperties = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            CancellationToken cancellationToken = default)
            where TEntity : class, IBaseEntity
        {
            var items = await PrepareQueryable(filter, includedProperties, orderBy, skip, take)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            if (items.Any())
            {
                return items.First();
            }

            return default(TEntity);
        }

        public virtual void Add<TEntity>(TEntity entity)
            where TEntity: class, IBaseEntity
        {
            entity.CreatedDate = DateTime.Now;

            _context.Set<TEntity>().Add(entity);
        }

        public virtual void Update<TEntity>(TEntity entity)
            where TEntity: class, IBaseEntity
        {
            _context.Update<TEntity>(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity)
            where TEntity : class, IBaseEntity
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual void DeleteById<TEntity>(object id)
            where TEntity : class, IBaseEntity
        {
            TEntity entity = _context.Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual async Task Save(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
