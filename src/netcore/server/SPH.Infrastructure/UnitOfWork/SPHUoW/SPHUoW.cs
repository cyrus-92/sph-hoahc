using SPH.Entity.Contexts;
using SPH.Infrastructure.UnitOfWork.Core;

namespace SPH.Infrastructure.UoW
{
    public class SPHUoW : BaseUnitOfWork<SPHContext>, ISPHUoW
    {
        public SPHUoW(IUnitOfWorkPool unitOfWorkPool) : base(unitOfWorkPool)
        {
            UnitOfWork = unitOfWorkPool.Get(nameof(SPHContext));
        }
    }
}
