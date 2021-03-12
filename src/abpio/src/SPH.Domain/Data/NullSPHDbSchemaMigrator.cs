using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SPH.Data
{
    /* This is used if database provider does't define
     * ISPHDbSchemaMigrator implementation.
     */
    public class NullSPHDbSchemaMigrator : ISPHDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}