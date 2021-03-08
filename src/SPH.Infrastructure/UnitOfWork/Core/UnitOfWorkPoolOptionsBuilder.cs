using Microsoft.EntityFrameworkCore;
using SPH.Infrastructure.UnitOfWork.Core;

namespace Microsoft.Extensions.DependencyInjection
{
    public class UnitOfWorkPoolOptionsBuilder
    {
        public UnitOfWorkPoolOptions Options { get; } = new UnitOfWorkPoolOptions();

        /// <summary>
        /// Registers the name by which a Unit of Work for the given DbContext will be retrievable
        /// </summary>
        /// <typeparam name="T">DbContext for which a Unit of Work will be added</typeparam>
        /// <param name="key">The key by which a Unit of Work for the DbContext will be retrievable in client code</param>
        public void AddUnitOfWork<TContext>(string key) where TContext : DbContext
        {
            Options.RegisteredUoWs.Add(key, typeof(IUnitOfWork<TContext>));
        }
    }
}
