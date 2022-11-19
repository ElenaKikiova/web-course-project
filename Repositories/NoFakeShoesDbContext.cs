using CourseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories
{
    public class NoFakeShoesDbContext: DbContext
    {
        public NoFakeShoesDbContext(DbContextOptions<NoFakeShoesDbContext> options): base(options)
        {

        }

        public DbSet<Shoe> Shoes { get; set; }

        public DbSet<ShoeSupplier> Suppliers { get; set; }

    }
}
