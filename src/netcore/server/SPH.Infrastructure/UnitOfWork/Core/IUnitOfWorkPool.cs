using System.Collections.Generic;

namespace SPH.Infrastructure.UnitOfWork.Core
{
    public interface IUnitOfWorkPool
    {
        IEnumerable<string> RegisteredUoWKeys { get; }

        IUnitOfWork Get(string key);

        IEnumerable<IUnitOfWork> GetAll();
    }
}
