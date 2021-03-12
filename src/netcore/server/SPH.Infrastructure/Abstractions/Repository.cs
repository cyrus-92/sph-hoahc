using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SPH.Entity.Abstractions.Audits;
using SPH.Entity.Abstractions.Paginations;

namespace SPH.Infrastructure.Abstractions
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            dbSet = this.dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> FindAll(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
            => Query(predicate, orderBy, include, disableTracking).ToList();

        public async Task<IEnumerable<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> predicate = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, 
            bool disableTracking = true, 
            CancellationToken cancellationToken = default)
            => await Query(predicate, orderBy, include, disableTracking).ToListAsync(cancellationToken);

        public IPagedList<TEntity> PagingAll(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            int pageIndex = 1,
            int pageSize = 25,
            int indexFrom = 1)
            => Query(predicate, orderBy, include, disableTracking).ToPagedList(pageIndex, pageSize, indexFrom);

        public async Task<IPagedList<TEntity>> PagingAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            int pageIndex = 1,
            int pageSize = 25,
            int indexFrom = 1,
            CancellationToken cancellationToken = default)
            => await Query(predicate, orderBy, include, disableTracking).ToPagedListAsync(pageIndex, pageSize, indexFrom, cancellationToken);

        public TEntity Get(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
            => Query(predicate, orderBy, include, disableTracking).FirstOrDefault();

        public async Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            CancellationToken cancellationToken = default)
            => await Query(predicate, orderBy, include, disableTracking).FirstOrDefaultAsync(cancellationToken);

        public void Insert(TEntity entity)
        {
            if (entity is ICreationAuditEntity creationAuditEntity)
                creationAuditEntity.CreatedTime = DateTime.UtcNow;

            dbSet.Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is ICreationAuditEntity creationAuditEntity)
                    creationAuditEntity.CreatedTime = DateTime.UtcNow;
            }

            dbSet.AddRange(entities);
        }

        public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if (entity is ICreationAuditEntity creationAuditEntity)
                creationAuditEntity.CreatedTime = DateTime.UtcNow;

            await dbSet.AddAsync(entity, cancellationToken);
        }

        public async Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                if (entity is ICreationAuditEntity creationAuditEntity)
                    creationAuditEntity.CreatedTime = DateTime.UtcNow;
            }

            await dbSet.AddRangeAsync(entities, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            if (entity is IModificationAuditEntity modificationAuditEntity)
                modificationAuditEntity.ModifiedTime = DateTime.UtcNow;

            dbSet.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is IModificationAuditEntity modificationAuditEntity)
                    modificationAuditEntity.ModifiedTime = DateTime.UtcNow;
            }

            dbSet.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
            => dbSet.Remove(entity);

        public void Delete(IEnumerable<TEntity> entities)
            => dbSet.RemoveRange(entities);

        public void Remove(TEntity entity)
        {
            if (entity is IDeletionAuditEntity deletionAuditEntity)
                deletionAuditEntity.Deleted = true;

            dbSet.Update(entity);
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is IDeletionAuditEntity deletionAuditEntity)
                    deletionAuditEntity.Deleted = true;
            }

            dbSet.UpdateRange(entities);
        }

        public void Reload(TEntity entity)
            => dbContext.Entry(entity).Reload();

        public async Task ReloadAsync(TEntity entity, CancellationToken cancellationToken = default)
            => await dbContext.Entry(entity).ReloadAsync(cancellationToken);

        #region [Private Methods]
        private IQueryable<TEntity> Query(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = dbSet;

            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }
        #endregion
    }
}
