using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirsoftLogger.Models;
using Microsoft.EntityFrameworkCore;

namespace AirsoftLogger.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>()
                .HasKey(c => new { c.Date, c.SiteCode  });
        }

        public DbSet<Site> Sites { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Events> Events { get; set; }
    }
}
