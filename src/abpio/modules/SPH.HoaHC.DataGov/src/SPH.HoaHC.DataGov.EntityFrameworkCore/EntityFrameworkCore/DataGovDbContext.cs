using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SPH.HoaHC.DataGov.EntityFrameworkCore
{
    [ConnectionStringName(DataGovDbProperties.ConnectionStringName)]
    public class DataGovDbContext : AbpDbContext<DataGovDbContext>, IDataGovDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public DataGovDbContext(DbContextOptions<DataGovDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureDataGov();
        }
    }
}