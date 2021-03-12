using System.Threading.Tasks;

namespace SPH.HoaHC.Data
{
    public interface IHoaHCDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
