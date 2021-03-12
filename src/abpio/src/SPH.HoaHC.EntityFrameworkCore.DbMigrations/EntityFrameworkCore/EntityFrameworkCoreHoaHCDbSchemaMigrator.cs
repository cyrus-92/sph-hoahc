using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SPH.HoaHC.Data;
using Volo.Abp.DependencyInjection;

namespace SPH.HoaHC.EntityFrameworkCore
{
    public class EntityFrameworkCoreHoaHCDbSchemaMigrator
        : IHoaHCDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreHoaHCDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the HoaHCMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<HoaHCMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}