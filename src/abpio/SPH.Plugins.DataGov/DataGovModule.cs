using Microsoft.Extensions.DependencyInjection;
using SPH.Plugins.DataGov.Services;
using System;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace SPH.Plugins.DataGov
{
    public class DataGovModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var transportService = context.ServiceProvider
                .GetRequiredService<ITransportService>();

            var status = transportService.GetCarparkAvailabilityAsync(string.Empty).Result;

            base.OnApplicationInitialization(context);
        }
    }
}
