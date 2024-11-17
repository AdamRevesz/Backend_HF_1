using Backend_HF_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_HF_1.Database
{
    public class DunaLevelDbContext : DbContext
    {
        public DbSet<DunaLevel> WaterLevels { get; set; }
        public DbSet<MonthlyStatistics> MonthlyStatistics { get; set; }

        public DunaLevelDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DunaLevel>()
                .Property(d => d.Date)
                .IsRequired();

            modelBuilder.Entity<DunaLevel>()
                .Property(d => d.WaterLevel)
                .IsRequired();
        }
    }
}
