using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimchaFund.Data
{
    public class SimchaDonorContext : DbContext
    {
        private string _connectionString;

        public SimchaDonorContext(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        public DbSet<Simcha> Simcha { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Depsit> Deposit { get; set; }
        public DbSet<SimchaDonor> SimchaDonor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
                        
            modelBuilder.Entity<SimchaDonor>()
                .HasKey(sd => new { sd.DonorId, sd.SimchaId });

            modelBuilder.Entity<SimchaDonor>()
                .HasOne(sd => sd.Donor)
                .WithMany(d => d.SimchaDonors)
                .HasForeignKey(d => d.DonorId);

            modelBuilder.Entity<SimchaDonor>()
                .HasOne(sd => sd.Simchas)
                .WithMany(s => s.SimchaDonors)
                .HasForeignKey(s => s.SimchaId);
        }
    }
}
