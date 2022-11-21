using CourseProject.Models;

namespace CourseProject.Repositories.Abstractions
{
    public interface IShoe_ShoeSupplierRepository
    {
        Shoe_ShoeSupplier GetById(int id);

        List<Shoe_ShoeSupplier> GetAll();

        void Insert(Shoe_ShoeSupplier shoeSupplier);

        void Update(Shoe_ShoeSupplier shoeSupplier);

        void Delete(int id);
    }
}
