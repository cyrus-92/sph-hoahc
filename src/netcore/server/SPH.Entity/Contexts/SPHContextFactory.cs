using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace SPH.Entity.Contexts
{
    public class SPHContextFactory : IDesignTimeDbContextFactory<SPHContext>
    {
        public SPHContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<SPHContext>();
            optionBuilder.UseMySql(@"Server=localhost; Port=3306; Database=sph_hoahc; Uid=root; Pwd=root; SslMode=Preferred;", opts =>
            {
                opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                opts.ServerVersion(new Version(5, 7, 17), ServerType.MySql);
            });

            return new SPHContext(optionBuilder.Options);
        }
    }
}
