using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer
{
    public class PassBoxContext : DbContext
    {
        public PassBoxContext(DbContextOptions<PassBoxContext> options)
       : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Username = "Lukas",
                Password = "Test"
            });

            modelBuilder.Entity<Password>().HasData(new Password
            {
                Website = "Test site.com",
                Username = "bob",
                Pass = "Test",
            }); ;
        }
    }
}
