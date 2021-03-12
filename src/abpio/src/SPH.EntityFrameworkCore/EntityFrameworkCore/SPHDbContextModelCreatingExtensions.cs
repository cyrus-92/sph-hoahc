using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace SPH.EntityFrameworkCore
{
    public static class SPHDbContextModelCreatingExtensions
    {
        public static void ConfigureSPH(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(SPHConsts.DbTablePrefix + "YourEntities", SPHConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}