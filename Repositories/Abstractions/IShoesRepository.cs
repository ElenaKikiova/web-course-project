using CourseProject.Models;

namespace CourseProject.Repositories.Abstractions
{
    public interface IShoesRepository
    {
        void Add(Shoe shoe);
        Shoe Get(int ShoeId);
        IQueryable<Shoe> GetAll();
        void Update(Shoe shoe);
        void Delete(int ShoeId);
    }
}
