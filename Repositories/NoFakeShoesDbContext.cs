using CourseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories
{
    public class NoFakeShoesDbContext: DbContext
    {
        public NoFakeShoesDbContext(DbContextOptions<NoFakeShoesDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shoe_ShoeSupplier>()
                .HasOne(shoe_shoeSupplier => shoe_shoeSupplier.Shoe)
                .WithMany(shoe => shoe.Shoe_ShoeSuppliers)
                .HasForeignKey(shoe_shoeSupplier => shoe_shoeSupplier.ShoeId);

            modelBuilder.Entity<Shoe_ShoeSupplier>()
                .HasOne(shoe_shoeSupplier => shoe_shoeSupplier.ShoeSupplier)
                .WithMany(shoeSupplier => shoeSupplier.Shoe_ShoeSuppliers)
                .HasForeignKey(shoe_shoeSupplier => shoe_shoeSupplier.ShoeSupplierId);
        }

        public DbSet<Shoe> Shoes { get; set; }

        public DbSet<ShoeSupplier> Suppliers { get; set; }

        public DbSet<Shoe_ShoeSupplier> Shoe_ShoeSupplier { get; set; }
    }
}
