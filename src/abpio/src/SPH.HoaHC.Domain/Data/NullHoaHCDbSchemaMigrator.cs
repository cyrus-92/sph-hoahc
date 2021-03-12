using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SPH.HoaHC.Data
{
    /* This is used if database provider does't define
     * IHoaHCDbSchemaMigrator implementation.
     */
    public class NullHoaHCDbSchemaMigrator : IHoaHCDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}