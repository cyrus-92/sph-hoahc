using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SPH.HoaHC.DataGov.EntityFrameworkCore
{
    [DependsOn(
        typeof(DataGovDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class DataGovEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DataGovDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}