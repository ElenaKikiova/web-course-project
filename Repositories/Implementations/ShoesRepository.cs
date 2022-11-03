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

        public List<Shoe> GetAll()
        {
            return this.dbSet.ToList<Shoe>();
        }

        public void Update(Shoe shoe)
        {
            Shoe current = Get(shoe.Id);

            if(current != null)
            {
                this.shoesDbContext.Entry(current).State = EntityState.Detached;
            }

            this.shoesDbContext.Entry(current).State = EntityState.Modified;
            this.shoesDbContext.SaveChanges();
        }
        public void Delete(int ShoeId)
        {
            this.dbSet.Remove(Get(ShoeId));
            this.shoesDbContext.SaveChanges();
        }

    }
}
