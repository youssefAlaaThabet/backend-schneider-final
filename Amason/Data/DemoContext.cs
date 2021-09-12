using Amason.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amason.Data
{
    public partial class DemoContext : DbContext
    {
        public DbSet<Product> product { get; set; }
        public DbSet<User> user { get; set; }

        public DbSet<Cart> cart { get; set; }
        public DbSet<Shipping> shipping { get; set; }






        public DemoContext() { }
        public DemoContext(DbContextOptions<DemoContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(50).
                IsUnicode(false);
                entity.HasMany(e => e.CartProduct).
                WithOne(e => e.product).
                HasForeignKey(e => e.ProductId);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(50).
                IsUnicode(false);
                entity.HasMany(e => e.CartUser).
                   WithOne(e => e.user).
                    HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.ShippingUser).
                   WithOne(e => e.user).
                    HasForeignKey(e => e.UserId);
            }

            );
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.ToTable("Shipping");
                entity.HasKey(e => e.Id);
            });


            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }




}

