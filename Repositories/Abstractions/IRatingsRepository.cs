using CourseProject.Models;

namespace CourseProject.Repositories.Abstractions
{
    public interface IRatingsRepository
    {
        void Insert(Rating rating);

        List<Rating> GetRatings();
    }
}
