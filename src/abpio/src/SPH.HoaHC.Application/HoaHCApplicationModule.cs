using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using SPH.HoaHC.DataGov;

namespace SPH.HoaHC
{
    [DependsOn(
        typeof(HoaHCDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(HoaHCApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule)
        )]
    [DependsOn(typeof(DataGovApplicationModule))]
    public class HoaHCApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<HoaHCApplicationModule>();
            });
        }
    }
}
