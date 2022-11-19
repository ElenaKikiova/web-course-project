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
                ShoeSupplierId = shoeSupplier.ShoeSupplierId,
                CompanyName = shoeSupplier.CompanyName
            }).ToList();
        }

        public ShoeSupplierDetailsViewModel GetById(int ShoeSupplierId)
        {
            var shoeSupplier = shoeSupplierRepostory.GetById(ShoeSupplierId);

            if (shoeSupplier == null) return null;

            return new ShoeSupplierDetailsViewModel
            {
                ShoeSupplierId = shoeSupplier.ShoeSupplierId,
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
