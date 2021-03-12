using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace SPH.HoaHC.EntityFrameworkCore
{
    [DependsOn(
        typeof(HoaHCEntityFrameworkCoreModule)
        )]
    public class HoaHCEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HoaHCMigrationsDbContext>();
        }
    }
}
