using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SPH.HoaHC.DataGov
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(DataGovDomainSharedModule)
    )]
    public class DataGovDomainModule : AbpModule
    {

    }
}
