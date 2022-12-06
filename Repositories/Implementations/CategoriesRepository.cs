using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories.Implementations
{
    public class CategoriesRepository : ICategoriesRepository
    {

        private readonly NoFakeShoesDbContext shoesDbContext;
        private readonly DbSet<Category> dbSet;

        public CategoriesRepository(NoFakeShoesDbContext context)
        {
            this.shoesDbContext = context;
            this.dbSet = this.shoesDbContext.Set<Category>();
        }

        public Category Get(int CategoryId)
        {
            return this.dbSet.Find(CategoryId);
        }

        public IQueryable<Category> GetAll()
        {
            return this.dbSet;
        }

        public void Add(Category Category)
        {
            this.dbSet.Add(Category);
            this.shoesDbContext.SaveChanges();
        }

        public void Delete(int CategoryId)
        {
            Category category = this.dbSet.Include(category => category.Shoes)
                .FirstOrDefault(category => category.Id == CategoryId);

            if (category != null)
            {
                this.dbSet.Remove(category);
            }
            this.shoesDbContext.SaveChanges();
        }

        public void Update(Category Category)
        {
            Category current = Get(Category.Id);

            if (current != null)
            {
                this.shoesDbContext.Entry(current).State = EntityState.Detached;
            }

            this.shoesDbContext.Entry(Category).State = EntityState.Modified;


            this.shoesDbContext.SaveChanges();
        }
    }

}
