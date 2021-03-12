using Volo.Abp.Modularity;

namespace SPH.HoaHC.DataGov
{
    [DependsOn(
        typeof(DataGovApplicationModule),
        typeof(DataGovDomainTestModule)
        )]
    public class DataGovApplicationTestModule : AbpModule
    {

    }
}
