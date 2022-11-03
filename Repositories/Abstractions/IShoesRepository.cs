using CourseProject.Models;

namespace CourseProject.Repositories.Abstractions
{
    public interface IShoesRepository
    {
        void Add(Shoe shoe);
        Shoe Get(int ShoeId);
        List<Shoe> GetAll();
        void Update(Shoe shoe);
        void Delete(int ShoeId);
    }
}
