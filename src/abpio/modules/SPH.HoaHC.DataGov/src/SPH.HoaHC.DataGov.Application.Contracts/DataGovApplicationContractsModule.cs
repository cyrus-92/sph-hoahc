using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace SPH.HoaHC.DataGov
{
    [DependsOn(
        typeof(DataGovDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class DataGovApplicationContractsModule : AbpModule
    {

    }
}
