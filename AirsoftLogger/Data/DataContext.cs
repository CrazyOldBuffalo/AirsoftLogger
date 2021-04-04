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

        public DbSet<Site> Sites { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Events> Events { get; set; }
    }
}
