using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SPH.Infrastructure.Abstractions;
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using WeLott.Shared.Exceptions;

namespace SPH.Infrastructure.UnitOfWork.Core
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        protected bool disposed = false;
        protected readonly DbContext dbContext;
        protected IDbContextTransaction transaction;
        protected IsolationLevel? isolationLevel;
        protected ConcurrentDictionary<Type, object> repositories;
        protected readonly bool isInMemoryContext;

        public UnitOfWork(TContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            isInMemoryContext = dbContext.Database.ProviderName.ToLower().Contains("inmemory");
        }

        public void BeginTransaction()
        {
            StartNewTransactionIfNeeded();
        }

        public void Commit()
        {
            dbContext.SaveChanges();

            if (transaction != null && !isInMemoryContext)
            {
                transaction.Commit();
                transaction.Dispose();
                transaction = null;
            }
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (repositories == null)
                repositories = new ConcurrentDictionary<Type, object>();

            var typeOfEntity = typeof(TEntity);
            if (!repositories.ContainsKey(typeOfEntity))
                repositories[typeOfEntity] = new Repository<TEntity>(dbContext);

            return (IRepository<TEntity>)repositories[typeOfEntity];
        }

        public void Rollback()
        {
            if (transaction == null)
                return;

            transaction.Rollback();

            transaction.Dispose();
            transaction = null;
        }

        public bool SaveChanges()
        {
            StartNewTransactionIfNeeded();

            return dbContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            StartNewTransactionIfNeeded();

            int effectedRow = await dbContext.SaveChangesAsync(cancellationToken);
            if (effectedRow <= 0)
                throw new BadRequestException("Unknown specific error has occurred.");

            return effectedRow > 0;
        }

        public void SetIsolationLevel(IsolationLevel isolationLevel)
        {
            this.isolationLevel = isolationLevel;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                if (repositories != null)
                    repositories.Clear();

                if (transaction != null)
                    transaction.Dispose();

                transaction = null;

                dbContext.Dispose();
            }

            disposed = false;
        }

        private void StartNewTransactionIfNeeded()
        {
            if (transaction == null && !isInMemoryContext)
            {
                transaction = isolationLevel.HasValue
                    ? dbContext.Database.BeginTransaction(isolationLevel.GetValueOrDefault())
                    : dbContext.Database.BeginTransaction();
            }
        }
    }
}
