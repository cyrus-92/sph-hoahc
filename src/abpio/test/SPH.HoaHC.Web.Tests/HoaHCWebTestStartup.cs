using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace SPH.HoaHC
{
    public class HoaHCWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<HoaHCWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}