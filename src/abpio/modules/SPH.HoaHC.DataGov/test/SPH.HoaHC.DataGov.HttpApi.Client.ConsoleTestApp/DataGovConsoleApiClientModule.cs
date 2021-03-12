using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace SPH.HoaHC.DataGov
{
    [DependsOn(
        typeof(DataGovHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class DataGovConsoleApiClientModule : AbpModule
    {
        
    }
}
