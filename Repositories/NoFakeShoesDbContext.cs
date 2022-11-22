using CourseProject.Models;
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
            modelBuilder.Entity<Shoe_ShoeSupplier>()
                .HasOne(shoe_ShoeSupplier => shoe_ShoeSupplier.Shoe)
                .WithMany(shoe => shoe.Shoe_ShoeSuppliers)
                .HasForeignKey(shoe_ShoeSupplier => shoe_ShoeSupplier.ShoeId);

            modelBuilder.Entity<Shoe_ShoeSupplier>()
                .HasOne(shoe_ShoeSupplier => shoe_ShoeSupplier.ShoeSupplier)
                .WithMany(shoeSupplier => shoeSupplier.Shoe_ShoeSuppliers)
                .HasForeignKey(shoe_ShoeSupplier => shoe_ShoeSupplier.ShoeSupplierId);
        }

        public DbSet<Shoe> Shoes { get; set; }

        public DbSet<ShoeSupplier> ShoeSuppliers { get; set; }

        public DbSet<Shoe_ShoeSupplier> Shoe_ShoeSuppliers { get; set; }
    }
}
