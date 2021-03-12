using SPH.HoaHC.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace SPH.HoaHC.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(HoaHCEntityFrameworkCoreDbMigrationsModule),
        typeof(HoaHCApplicationContractsModule)
        )]
    public class HoaHCDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
