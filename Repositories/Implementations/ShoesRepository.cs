using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories.Implementations
{
    public class ShoesRepository : IShoesRepository
    {
        private readonly NoFakeShoesDbContext shoesDbContext;

        private readonly DbSet<Shoe> dbSet;

        public ShoesRepository(NoFakeShoesDbContext context)
        {
            this.shoesDbContext = context;
            this.dbSet = this.shoesDbContext.Set<Shoe>();
        }

        public void Add(Shoe shoe)
        {
            this.dbSet.Add(shoe);
            this.shoesDbContext.SaveChanges();
        }

        public Shoe Get(int ShoeId)
        {
            Shoe shoe = this.dbSet
                .Include(shoe => shoe.Shoe_ShoeSuppliers)
                .Include(shoe => shoe.Brand)
                .FirstOrDefault(shoe => shoe.Id == ShoeId);
            return shoe;
        }

        public IQueryable<Shoe> GetAll()
        {
            return dbSet;
        }


        public void Update(Shoe shoe)
        {
            Shoe current = Get(shoe.Id);

            if (current != null)
            {
                this.shoesDbContext.Entry(current).State = EntityState.Detached;
            }

            this.shoesDbContext.Entry(shoe).State = EntityState.Modified;

            this.shoesDbContext.Shoe_ShoeSuppliers.RemoveRange(current.Shoe_ShoeSuppliers);

            this.shoesDbContext.SaveChanges();

            this.shoesDbContext.Shoe_ShoeSuppliers.AddRange(current.Shoe_ShoeSuppliers);

            this.shoesDbContext.SaveChanges();
        }
        public void Delete(int ShoeId)
        {
            Shoe shoe = this.dbSet.Include(shoe => shoe.Shoe_ShoeSuppliers)
                 .FirstOrDefault(shoe => shoe.Id == ShoeId);

            if (shoe != null)
            {
                this.shoesDbContext.Shoe_ShoeSuppliers.RemoveRange(shoe.Shoe_ShoeSuppliers);
                this.dbSet.Remove(shoe);
            }
            this.shoesDbContext.SaveChanges();
        }

    }
}
