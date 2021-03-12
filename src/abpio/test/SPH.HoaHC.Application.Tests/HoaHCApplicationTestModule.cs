using Volo.Abp.Modularity;

namespace SPH.HoaHC
{
    [DependsOn(
        typeof(HoaHCApplicationModule),
        typeof(HoaHCDomainTestModule)
        )]
    public class HoaHCApplicationTestModule : AbpModule
    {

    }
}