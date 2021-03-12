using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace SPH.EntityFrameworkCore
{
    [DependsOn(
        typeof(SPHEntityFrameworkCoreModule)
        )]
    public class SPHEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SPHMigrationsDbContext>();
        }
    }
}
