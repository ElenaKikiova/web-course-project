﻿using CourseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories
{
    public class NoFakeShoesDbContext : DbContext
    {
        public NoFakeShoesDbContext(DbContextOptions<NoFakeShoesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shoe>()
                .HasMany(shoe => shoe.Shoe_ShoeSuppliers)
                .WithOne()
                .HasForeignKey(shoe_ShoeSupplier => shoe_ShoeSupplier.ShoeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShoeSupplier>()
                .HasMany(shoeSupplier => shoeSupplier.Shoe_ShoeSuppliers)
                .WithOne()
                .HasForeignKey(shoe_ShoeSupplier => shoe_ShoeSupplier.ShoeSupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shoe_ShoeSupplier>()
                .HasOne(shoe_shoeSupplier => shoe_shoeSupplier.Shoe)
                .WithMany(shoe => shoe.Shoe_ShoeSuppliers);

            modelBuilder.Entity<Shoe_ShoeSupplier>()
                .HasOne(shoe_shoeSupplier => shoe_shoeSupplier.ShoeSupplier)
                .WithMany(shoeSupplier => shoeSupplier.Shoe_ShoeSuppliers);
        }

        public DbSet<Shoe> Shoes { get; set; }

        public DbSet<ShoeSupplier> ShoeSuppliers { get; set; }

        public DbSet<Shoe_ShoeSupplier> Shoe_ShoeSuppliers { get; set; }
    }
}
