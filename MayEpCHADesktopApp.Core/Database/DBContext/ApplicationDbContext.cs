using MayEpCHADesktopApp.Core.Database.ModelDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayEpCHADesktopApp.Core.Database.DBContext
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite(@"Data Source= DBMOLDINGMACHINE.db");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
    public class ApplicationDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<EventMachine> EventMachines { get; set; }
        public DbSet<HistoryCofiguration> HistoryCofigurations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DBMOLDINGMACHINE.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventMachine>()
                        .HasKey(s => s.Id);
            modelBuilder.Entity<Configuration>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Configuration>()
                .HasKey(s => s.Id);
            
            base.OnModelCreating(modelBuilder)
                ;
        }

    }
}
