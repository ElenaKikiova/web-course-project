using CourseProject.ViewModels.ShoeSuppliers;

namespace CourseProject.Services.Abstractions
{
    public interface IShoeSupplierService
    {
        ShoeSupplierDetailViewModel GetById(int id);

        List<ShoeSupplierDetailViewModel> GetAll();

        CreateEditShoeSupplierViewModel GetShoe(int id);

        void Insert(CreateEditShoeSupplierViewModel createEditShoeSupplierViewModel);

        void Update(CreateEditShoeSupplierViewModel createEditShoeSupplierViewModel);

        void Delete(int id);
    }
}
