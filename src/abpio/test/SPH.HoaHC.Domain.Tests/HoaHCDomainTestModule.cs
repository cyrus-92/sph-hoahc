using SPH.HoaHC.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SPH.HoaHC
{
    [DependsOn(
        typeof(HoaHCEntityFrameworkCoreTestModule)
        )]
    public class HoaHCDomainTestModule : AbpModule
    {

    }
}