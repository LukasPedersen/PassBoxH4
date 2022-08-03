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
        public DbSet<Box> Boxs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
