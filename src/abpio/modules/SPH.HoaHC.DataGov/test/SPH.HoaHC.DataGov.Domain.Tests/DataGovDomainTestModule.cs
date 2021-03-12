using SPH.HoaHC.DataGov.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SPH.HoaHC.DataGov
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(DataGovEntityFrameworkCoreTestModule)
        )]
    public class DataGovDomainTestModule : AbpModule
    {
        
    }
}
