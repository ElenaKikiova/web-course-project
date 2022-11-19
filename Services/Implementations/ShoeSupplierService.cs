using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.ShoeSupplier;

namespace CourseProject.Services.Implementations
{
    public class ShoeSupplierService : IShoeSupplierService
    {
        private readonly IShoeSupplierRepository shoeSupplierRepostory;

        public ShoeSupplierService(IShoeSupplierRepository shoeSupplierRepostory)
        {
            this.shoeSupplierRepostory = shoeSupplierRepostory;
        }

        public List<ShoeSupplierDetailsViewModel> GetAll()
        {
            return shoeSupplierRepostory.GetAll().Select(shoeSupplier => new ShoeSupplierDetailsViewModel
            {
                ShoeSupplierId = shoeSupplier.Id,
                CompanyName = shoeSupplier.CompanyName,
                Shoe_ShoeSuppliers = shoeSupplier.Shoe_ShoeSuppliers
            }).ToList();
        }

        public ShoeSupplierDetailsViewModel GetById(int ShoeSupplierId)
        {
            var shoeSupplier = shoeSupplierRepostory.GetById(ShoeSupplierId);

            if (shoeSupplier == null) return null;

            return new ShoeSupplierDetailsViewModel
            {
                ShoeSupplierId = shoeSupplier.Id,
                CompanyName = shoeSupplier.CompanyName
            };
        }

        public void Insert(ShoeSupplierCreateEditViewModel shoeSupplierCreateEditViewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(ShoeSupplierCreateEditViewModel shoeSupplierCreateEditViewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int shoeSupplierId)
        {
            throw new NotImplementedException();
        }
    }
}
