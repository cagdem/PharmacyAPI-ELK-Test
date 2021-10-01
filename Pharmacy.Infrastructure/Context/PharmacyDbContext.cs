using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Context
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options)
        {

        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().Property(m => m.UnitPrice)
                .HasColumnType("money");

            modelBuilder.Entity<OrderDetail>().Property(o => o.UnitPrice)
                .HasColumnType("money");

            // migration sırasında uyarı verdiği için özellikle belirttim.
        }

    }
}
