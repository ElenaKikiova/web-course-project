using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Repositories.Implementations
{
    public class RatingsRepository : IRatingsRepository
    {
        private readonly NoFakeShoesDbContext noFakeShoesDbContext;

        private readonly DbSet<Rating> ratings;

        public RatingsRepository(NoFakeShoesDbContext noFakeShoesDbContext)
        {
            this.noFakeShoesDbContext = noFakeShoesDbContext;
            ratings = noFakeShoesDbContext.Ratings;
        }

        public List<Rating> GetRatings()
        {
            return ratings.ToList();
        }

        public void Insert(Rating rating)
        {
            ratings.Add(rating);
            noFakeShoesDbContext.SaveChanges();
        }
    }
}
