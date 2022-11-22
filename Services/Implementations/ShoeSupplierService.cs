using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.ShoeSuppliers;

namespace CourseProject.Services.Implementations
{
    public class ShoeSupplierService : IShoeSupplierService
    {
        private readonly IShoeSupplierRepository shoeSupplierRepository;

        public ShoeSupplierService(IShoeSupplierRepository shoeSupplierRepository)
        {
            this.shoeSupplierRepository = shoeSupplierRepository;
        }

        public ShoeSupplierDetailViewModel GetById(int id)
        {
            ShoeSupplier shoeSupplier = shoeSupplierRepository.GetById(id);

            if (shoeSupplier == null) return null;

            return new ShoeSupplierDetailViewModel()
            {
                Id = shoeSupplier.Id,
                SupplierName = shoeSupplier.SupplierName
            };
        }

        public List<ShoeSupplierDetailViewModel> GetAll()
        {
            return shoeSupplierRepository.GetAll().Select(shoeSupplier => new ShoeSupplierDetailViewModel
            {
                Id = shoeSupplier.Id,
                SupplierName = shoeSupplier.SupplierName
            }).ToList();
        }

        public void Insert(CreateEditShoeSupplierViewModel createEditShoeSupplierViewModel)
        {
            var shoeSupplier = new ShoeSupplier()
            {
                SupplierName = createEditShoeSupplierViewModel.SupplierName
            };
            shoeSupplierRepository.Insert(shoeSupplier);
        }

        public void Update(CreateEditShoeSupplierViewModel createEditShoeSupplierViewModel)
        {
            var shoeSupplier = new ShoeSupplier()
            {
                Id = createEditShoeSupplierViewModel.Id,
                SupplierName = createEditShoeSupplierViewModel.SupplierName
            };
            shoeSupplierRepository.Update(shoeSupplier);
        }

        public void Delete(int id)
        {
            shoeSupplierRepository.Delete(id);
        }
    }
}
