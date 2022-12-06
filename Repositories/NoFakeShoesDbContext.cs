using CourseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories
{
    public class NoFakeShoesDbContext : DbContext
    {
        public NoFakeShoesDbContext(DbContextOptions<NoFakeShoesDbContext> options) : base(options)
        {

        }

        public DbSet<Shoe> Shoes { get; set; }

        public DbSet<ShoeSupplier> ShoeSuppliers { get; set; }

        public DbSet<Shoe_ShoeSupplier> Shoe_ShoeSuppliers { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Shoe>()
                .HasMany(shoe => shoe.Shoe_ShoeSuppliers)
                .WithOne()
                .HasForeignKey(shoe_ShoeSupplier => shoe_ShoeSupplier.ShoeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Brand>()
                .HasMany(brand => brand.Shoes)
                .WithOne(shoe => shoe.Brand)
                .HasForeignKey(shoe => shoe.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasMany(category => category.Shoes)
                .WithOne(shoe => shoe.Category)
                .HasForeignKey(shoe => shoe.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShoeSupplier>()
                .HasMany(shoeSupplier => shoeSupplier.Shoe_ShoeSuppliers)
                .WithOne()
                .HasForeignKey(shoe_ShoeSupplier => shoe_ShoeSupplier.ShoeSupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shoe_ShoeSupplier>()
                .HasOne(shoe_ShoeSupplier => shoe_ShoeSupplier.Shoe)
                .WithMany(shoe => shoe.Shoe_ShoeSuppliers);

            modelBuilder.Entity<Shoe_ShoeSupplier>()
                .HasOne(shoe_ShoeSupplier => shoe_ShoeSupplier.ShoeSupplier)
                .WithMany(shoeSupplier => shoeSupplier.Shoe_ShoeSuppliers);

            modelBuilder.Entity<Shoe>()
                .HasMany(shoe => shoe.Ratings)
                .WithOne()
                .HasForeignKey(rating => rating.ShoeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rating>()
                .HasOne(rating => rating.Shoe)
                .WithMany(shoe => shoe.Ratings);
        }

    }
}
