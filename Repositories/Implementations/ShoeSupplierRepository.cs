using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories.Implementations
{
    public class ShoeSupplierRepository : IShoeSupplierRepository
    {
        private readonly NoFakeShoesDbContext noFakeShoesDbContext;

        private readonly DbSet<ShoeSupplier> shoeSuppliersDbSet;

        public ShoeSupplierRepository(NoFakeShoesDbContext noFakeShoesDbContext)
        {
            this.noFakeShoesDbContext = noFakeShoesDbContext;
            shoeSuppliersDbSet = noFakeShoesDbContext.Set<ShoeSupplier>();
        }

        public ShoeSupplier GetById(int id)
        {
            return shoeSuppliersDbSet.Find(id);
        }

        public IQueryable<ShoeSupplier> GetAll()
        {
            return shoeSuppliersDbSet;
        }

        public void Insert(ShoeSupplier shoeSupplier)
        {
            shoeSuppliersDbSet.Add(shoeSupplier);
            noFakeShoesDbContext.SaveChanges();
        }

        public void Update(ShoeSupplier shoeSupplier)
        {
            ShoeSupplier shoeSupplierInDB = GetShoeSupplierWithShoes(shoeSupplier.Id);

            if (shoeSupplierInDB != null) noFakeShoesDbContext.Entry(shoeSupplierInDB).State = EntityState.Detached;

            noFakeShoesDbContext.Entry(shoeSupplier).State = EntityState.Modified;

            noFakeShoesDbContext.Shoe_ShoeSuppliers.RemoveRange(shoeSupplierInDB.Shoe_ShoeSuppliers);
            noFakeShoesDbContext.SaveChanges();

            noFakeShoesDbContext.Shoe_ShoeSuppliers.AddRange(shoeSupplier.Shoe_ShoeSuppliers);
            noFakeShoesDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            ShoeSupplier shoeSupplierInDB = shoeSuppliersDbSet
                .Include(shoeSupplier => shoeSupplier.Shoe_ShoeSuppliers)
                .FirstOrDefault(shoeSupplier => shoeSupplier.Id == id);

            noFakeShoesDbContext.Shoe_ShoeSuppliers.RemoveRange(shoeSupplierInDB.Shoe_ShoeSuppliers);
            shoeSuppliersDbSet.Remove(shoeSupplierInDB);
            noFakeShoesDbContext.SaveChanges();
        }

        private ShoeSupplier GetShoeSupplierWithShoes(int id)
        {
            return shoeSuppliersDbSet.Include(shoeSupplier => shoeSupplier.Shoe_ShoeSuppliers)
                .FirstOrDefault(shoeSupplier => shoeSupplier.Id == id);
        }
    }
}
