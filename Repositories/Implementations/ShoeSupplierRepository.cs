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

        public List<ShoeSupplier> GetAll()
        {
            return shoeSuppliersDbSet.ToList<ShoeSupplier>();
        }

        public void Insert(ShoeSupplier shoeSupplier)
        {
            shoeSuppliersDbSet.Add(shoeSupplier);
            noFakeShoesDbContext.SaveChanges();
        }

        public void Update(ShoeSupplier shoeSupplier)
        {
            ShoeSupplier shoeSupplierInDB = GetById(shoeSupplier.Id);

            if (shoeSupplierInDB != null)
            {
                noFakeShoesDbContext.Entry(shoeSupplierInDB).State = EntityState.Detached;
            }
            noFakeShoesDbContext.Entry(shoeSupplier).State = EntityState.Modified;
            noFakeShoesDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            shoeSuppliersDbSet.Remove(GetById(id));
            noFakeShoesDbContext.SaveChanges();
        }
    }
}
