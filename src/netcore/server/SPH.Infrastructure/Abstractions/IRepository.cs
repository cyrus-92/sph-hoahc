using Microsoft.EntityFrameworkCore.Query;
using SPH.Entity.Abstractions.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SPH.Infrastructure.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> FindAll(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true);

        Task<IEnumerable<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            CancellationToken cancellationToken = default);

        IPagedList<TEntity> PagingAll(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            int pageIndex = 1,
            int pageSize = 25,
            int indexFrom = 1);

        Task<IPagedList<TEntity>> PagingAllAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            int pageIndex = 1,
            int pageSize = 25,
            int indexFrom = 1,
            CancellationToken cancellationToken = default);

        TEntity Get(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true);

        Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true,
            CancellationToken cancellationToken = default);

        void Insert(TEntity entity);
        
        void Insert(IEnumerable<TEntity> entities);
        
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        
        Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        
        void Update(TEntity entity);
        
        void Update(IEnumerable<TEntity> entities);
        
        void Delete(TEntity entity);
        
        void Delete(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void Remove(IEnumerable<TEntity> entities);
        
        void Reload(TEntity entity);
        
        Task ReloadAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
