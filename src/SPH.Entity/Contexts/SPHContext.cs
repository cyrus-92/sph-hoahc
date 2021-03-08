using Microsoft.EntityFrameworkCore;
using SPH.Entity.Users;
using System;

namespace SPH.Entity.Contexts
{
    public class SPHContext : DbContext
    {
        public SPHContext(DbContextOptions<SPHContext> options) : base(options) { }

        public SPHContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(m =>
            {
                m.HasQueryFilter(x => !x.Deleted);
                m.Property(u => u.CreatedTime).HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
                m.Property(u => u.ModifiedTime).HasConversion(v => v, v => DateTime.SpecifyKind(v.Value, DateTimeKind.Utc));
                m.HasOne(u => u.Creator).WithMany();
                m.HasOne(u => u.Modifier).WithMany();
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
