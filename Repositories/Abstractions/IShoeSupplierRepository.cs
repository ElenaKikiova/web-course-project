using CourseProject.Models;

namespace CourseProject.Repositories.Abstractions
{
    public interface IShoeSupplierRepository
    {
        void Insert(ShoeSupplier shoeSupplier);

        ShoeSupplier GetById(int id);

        List<ShoeSupplier> GetAll();

        void Update(ShoeSupplier shoeSupplier);

        void Delete(int id);
    }
}
