using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace SPH.HoaHC.DataGov
{
    [DependsOn(
        typeof(DataGovApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class DataGovHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "DataGov";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(DataGovApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
