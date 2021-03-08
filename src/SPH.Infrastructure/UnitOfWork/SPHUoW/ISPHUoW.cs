using SPH.Entity.Contexts;
using SPH.Infrastructure.UnitOfWork.Core;

namespace SPH.Infrastructure.UoW
{
    public interface ISPHUoW : IUnitOfWork<SPHContext>
    {
    }
}
