using System.Threading.Tasks;

namespace SPH.Data
{
    public interface ISPHDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
