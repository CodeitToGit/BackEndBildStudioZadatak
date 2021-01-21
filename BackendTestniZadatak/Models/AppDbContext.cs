using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTestniZadatak.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<DeviceFeature> DeviceFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                 modelBuilder.Entity<DeviceType>()
                 .HasMany(x => x.Features)
                 .WithOne(x => x.DeviceType);
                 //.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
