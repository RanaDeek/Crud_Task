using Crud_Task.Module;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Task.Context
{
    internal class CrudDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Training_DB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(E => {
                E.Property(e => e.Price).HasDefaultValue(40);
                E.Property(e => e.Name).HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<Order>(O => {
                O.Property(o => o.CreatedAt).HasComputedColumnSql("GETDATE()");
                O.Property(o => o.Address).HasColumnType("varchar(30)");
            });

        }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products_crud { get; set; }
    }
}
