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
            return this.dbSet.Find(ShoeId);
        }

        public IQueryable<Shoe> GetAll()
        {
            return dbSet;
        }

        public void Update(Shoe shoe)
        {
            Shoe current = Get(shoe.Id);

            if(current != null)
            {
                this.shoesDbContext.Entry(current).State = EntityState.Detached;
            }

            this.shoesDbContext.Entry(shoe).State = EntityState.Modified;
            this.shoesDbContext.SaveChanges();
        }
        public void Delete(int ShoeId)
        {
            Shoe shoe = Get(ShoeId);
            if (shoe != null)
            {
                this.dbSet.Remove(shoe);
            }
            this.shoesDbContext.SaveChanges();
        }

    }
}
