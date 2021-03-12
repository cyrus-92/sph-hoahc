using Microsoft.EntityFrameworkCore;
using SPH.Infrastructure.Abstractions;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace SPH.Infrastructure.UnitOfWork.Core
{
    public interface IUnitOfWork : IDisposable
    {
        bool SaveChanges();
        
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
        
        void Rollback();
        
        void Commit();
        
        void BeginTransaction();
        
        void SetIsolationLevel(IsolationLevel isolationLevel);
        
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
    }
}
