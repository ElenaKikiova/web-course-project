using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories.Implementations
{
    public class BrandsRepository : IBrandsRepository
    {

        private readonly NoFakeShoesDbContext shoesDbContext;
        private readonly DbSet<Brand> dbSet;

        public BrandsRepository(NoFakeShoesDbContext context)
        {
            this.shoesDbContext = context;
            this.dbSet = this.shoesDbContext.Set<Brand>();
        }

        public IQueryable<Brand> GetAll() { 
            return this.dbSet;
        }

        public void Add(Brand Brand)
        {
            this.dbSet.Add(Brand);
            this.shoesDbContext.SaveChanges();
        }

        public void Delete(int ShoeId)
        {
            throw new NotImplementedException();
        }

        public Brand Get(int BrandId)
        {
            return this.dbSet.Find(BrandId);
        }

        public void Update(Shoe shoe)
        {
            throw new NotImplementedException();
        }
    }
}
