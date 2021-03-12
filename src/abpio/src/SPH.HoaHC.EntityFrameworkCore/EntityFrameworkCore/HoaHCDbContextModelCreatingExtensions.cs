using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace SPH.HoaHC.EntityFrameworkCore
{
    public static class HoaHCDbContextModelCreatingExtensions
    {
        public static void ConfigureHoaHC(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(HoaHCConsts.DbTablePrefix + "YourEntities", HoaHCConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}