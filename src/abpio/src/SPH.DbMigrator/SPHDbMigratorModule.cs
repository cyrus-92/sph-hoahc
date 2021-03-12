using SPH.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace SPH.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(SPHEntityFrameworkCoreDbMigrationsModule),
        typeof(SPHApplicationContractsModule)
        )]
    public class SPHDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
