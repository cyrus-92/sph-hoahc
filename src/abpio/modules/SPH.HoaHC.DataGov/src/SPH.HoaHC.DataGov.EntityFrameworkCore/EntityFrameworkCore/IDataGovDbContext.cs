using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SPH.HoaHC.DataGov.EntityFrameworkCore
{
    [ConnectionStringName(DataGovDbProperties.ConnectionStringName)]
    public interface IDataGovDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}