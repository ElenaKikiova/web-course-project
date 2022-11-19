using CourseProject.ViewModels.ShoeSupplier;

namespace CourseProject.Services.Abstractions
{
    public interface IShoeSupplierService
    {
        ShoeSupplierDetailsViewModel GetById(int ShoeSupplierId);

        List<ShoeSupplierDetailsViewModel> GetAll();

        void Insert(ShoeSupplierCreateEditViewModel shoeSupplierCreateEditViewModel);

        void Update(ShoeSupplierCreateEditViewModel shoeSupplierCreateEditViewModel);

        void Delete(int shoeSupplierId);
    }
}
