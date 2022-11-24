using CourseProject.Models;
using CourseProject.ViewModels.ShoeSuppliers;

namespace CourseProject.Repositories.Abstractions
{
    public interface IShoeSupplierRepository
    {
        ShoeSupplier GetById(int id);

        IQueryable<ShoeSupplier> GetAll();

        void Insert(ShoeSupplier shoeSupplier);

        void Update(ShoeSupplier shoeSupplier);

        void Delete(int id);
    }
}
