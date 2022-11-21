using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CourseProject.Repositories.Implementations
{
    public class Shoe_ShoeSupplierRepository : IShoe_ShoeSupplierRepository
    {
        private readonly NoFakeShoesDbContext noFakeShoesDbContext;

        private readonly DbSet<Shoe_ShoeSupplier> shoe_ShoeSupplierDbSet;

        public Shoe_ShoeSupplierRepository(NoFakeShoesDbContext noFakeShoesDbContext)
        {
            this.noFakeShoesDbContext = noFakeShoesDbContext;
            shoe_ShoeSupplierDbSet = noFakeShoesDbContext.Set<Shoe_ShoeSupplier>();
        }

        public Shoe_ShoeSupplier GetById(int id)
        {
            return noFakeShoesDbContext.Shoe_ShoeSuppliers
                 .Include(shoe_ShoeSupplier => shoe_ShoeSupplier.ShoeSupplier)
                 .Include(shoe_ShoeSupplier => shoe_ShoeSupplier.Shoe)
                 .SingleOrDefault(shoe_ShoeSupplier => shoe_ShoeSupplier.Id == id);
        }

        public List<Shoe_ShoeSupplier> GetAll()
        {
            return noFakeShoesDbContext.Shoe_ShoeSuppliers
                .Include(shoe_ShoeSupplier => shoe_ShoeSupplier.ShoeSupplier)
                .Include(shoe_ShoeSupplier => shoe_ShoeSupplier.Shoe)
                .ToList();
        }

        public void Insert(Shoe_ShoeSupplier shoe_shoeSupplier)
        {
            shoe_ShoeSupplierDbSet.Add(shoe_shoeSupplier);
            noFakeShoesDbContext.SaveChanges();
        }

        public void Update(Shoe_ShoeSupplier shoe_shoeSupplier)
        {
            Shoe_ShoeSupplier shoe_shoeSupplierInDB = GetById(shoe_shoeSupplier.Id);

            if (shoe_shoeSupplierInDB != null)
            {
                noFakeShoesDbContext.Entry(shoe_shoeSupplierInDB).State = EntityState.Detached;
            }
            noFakeShoesDbContext.Entry(shoe_shoeSupplierInDB).State = EntityState.Modified;
            noFakeShoesDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            shoe_ShoeSupplierDbSet.Remove(GetById(id));
            noFakeShoesDbContext.SaveChanges();
        }
    }
}
