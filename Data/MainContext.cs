using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Satish.Models;
using Satish.Data;

namespace Satish.Data
{
    public class MainContext : DbContext
    {   
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Cart { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartProduct>()
                .HasKey(t => new { t.CartId, t.ProductId });

            modelBuilder.Entity<CartProduct>()
                .HasOne(pt => pt.Cart)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(pt => pt.CartId);

            modelBuilder.Entity<CartProduct>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(pt => pt.ProductId);
        }

        public DbSet<Satish.Models.CartProduct> CartProduct { get; set; }

    }
   

}

