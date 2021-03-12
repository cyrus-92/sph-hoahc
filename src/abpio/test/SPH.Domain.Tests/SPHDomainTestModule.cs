using SPH.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SPH
{
    [DependsOn(
        typeof(SPHEntityFrameworkCoreTestModule)
        )]
    public class SPHDomainTestModule : AbpModule
    {

    }
}