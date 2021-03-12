using Localization.Resources.AbpUi;
using SPH.HoaHC.DataGov.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace SPH.HoaHC.DataGov
{
    [DependsOn(
        typeof(DataGovApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class DataGovHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(DataGovHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<DataGovResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
