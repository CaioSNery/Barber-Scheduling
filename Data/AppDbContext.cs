using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barber.Models;
using Microsoft.EntityFrameworkCore;

namespace Barber.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Scheduling> Schedulings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}