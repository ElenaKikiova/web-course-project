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

        public Brand Get(int BrandId)
        {
            return this.dbSet.Find(BrandId);
        }

        public IQueryable<Brand> GetAll()
        {
            return this.dbSet;
        }

        public void Add(Brand Brand)
        {
            this.dbSet.Add(Brand);
            this.shoesDbContext.SaveChanges();
        }

        public void Delete(int BrandId)
        {
            Brand brand = this.dbSet.Include(brand => brand.Shoes)
                .FirstOrDefault(brand => brand.Id == BrandId);

            if (brand != null)
            {
                this.dbSet.Remove(brand);
            }
            this.shoesDbContext.SaveChanges();
        }

        public void Update(Brand Brand)
        {
            Brand current = Get(Brand.Id);

            if (current != null)
            {
                this.shoesDbContext.Entry(current).State = EntityState.Detached;
            }

            this.shoesDbContext.Entry(Brand).State = EntityState.Modified;


            this.shoesDbContext.SaveChanges();
        }
    }

}
