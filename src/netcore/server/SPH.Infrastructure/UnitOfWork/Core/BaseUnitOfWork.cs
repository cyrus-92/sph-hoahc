using Microsoft.EntityFrameworkCore;
using SPH.Infrastructure.Abstractions;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace SPH.Infrastructure.UnitOfWork.Core
{
    public abstract class BaseUnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        public BaseUnitOfWork(IUnitOfWorkPool unitOfWorkPool)
        {
            if (unitOfWorkPool == null)
            {
                throw new System.ArgumentNullException(nameof(unitOfWorkPool));
            }
        }

        public void BeginTransaction()
        {
            UnitOfWork.BeginTransaction();
        }

        public void Commit()
        {
            UnitOfWork.Commit();
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return UnitOfWork.GetRepository<TEntity>();
        }

        public void Rollback()
        {
            UnitOfWork.Rollback();
        }

        public bool SaveChanges()
        {
            return UnitOfWork.SaveChanges();
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public void SetIsolationLevel(IsolationLevel isolationLevel)
        {
            UnitOfWork.SetIsolationLevel(isolationLevel);
        }
    }
}
