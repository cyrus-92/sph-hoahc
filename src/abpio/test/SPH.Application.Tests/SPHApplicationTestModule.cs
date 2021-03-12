using Volo.Abp.Modularity;

namespace SPH
{
    [DependsOn(
        typeof(SPHApplicationModule),
        typeof(SPHDomainTestModule)
        )]
    public class SPHApplicationTestModule : AbpModule
    {

    }
}