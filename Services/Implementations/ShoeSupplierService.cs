using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.Shoes;
using CourseProject.ViewModels.ShoeSuppliers;
using Microsoft.EntityFrameworkCore;

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
            var shoeSupplierInDB = shoeSupplierRepository.GetAll()
                .Include(shoeSupplier => shoeSupplier.Shoe_ShoeSuppliers)
                .ThenInclude(shoe_ShoeSupplier => shoe_ShoeSupplier.Shoe)
                .FirstOrDefault(shoeSupplier => shoeSupplier.Id == id);

            if (shoeSupplierInDB == null) return null;

            return new ShoeSupplierDetailViewModel
            {
                Id = shoeSupplierInDB.Id,
                SupplierName = shoeSupplierInDB.SupplierName,
                Shoes = shoeSupplierInDB.Shoe_ShoeSuppliers.Select(shoe_ShoeSupplier => new ShoeDetailsViewModel
                {
                    Id = shoe_ShoeSupplier.Shoe.Id,
                    CategoryId = shoe_ShoeSupplier.Shoe.CategoryId,
                    BrandId = shoe_ShoeSupplier.Shoe.BrandId,
                    ImageUrl = shoe_ShoeSupplier.Shoe.ImageUrl,
                    Name = shoe_ShoeSupplier.Shoe.Name,
                    Price = shoe_ShoeSupplier.Shoe.Price
                }).ToList()
            };
        }

        public List<ShoeSupplierDetailViewModel> GetAll()
        {
            return shoeSupplierRepository.GetAll()
                 .Include(shoeSupplier => shoeSupplier.Shoe_ShoeSuppliers)
                 .ThenInclude(shoe_ShoeSupplier => shoe_ShoeSupplier.Shoe)
                 .Select(shoeSupplier => new ShoeSupplierDetailViewModel
                 {
                     Id = shoeSupplier.Id,
                     SupplierName = shoeSupplier.SupplierName,
                     Shoes = shoeSupplier.Shoe_ShoeSuppliers.Select(shoe_ShoeSupplier => new ShoeDetailsViewModel
                     {
                         Id = shoe_ShoeSupplier.Shoe.Id,
                         CategoryId = shoe_ShoeSupplier.Shoe.CategoryId,
                         BrandId = shoe_ShoeSupplier.Shoe.BrandId,
                         ImageUrl = shoe_ShoeSupplier.Shoe.ImageUrl,
                         Name = shoe_ShoeSupplier.Shoe.Name,
                         Price = shoe_ShoeSupplier.Shoe.Price
                     }).ToList()
                 }).ToList();
        }

        public CreateEditShoeSupplierViewModel GetShoeSupplierCreateEdit(int id)
        {
            var shoeSupplier = shoeSupplierRepository.GetAll()
                .Include(s => s.Shoe_ShoeSuppliers)
                .ThenInclude(shoe_shoeSupplier => shoe_shoeSupplier.Shoe)
                .FirstOrDefault(s => s.Id == id);

            return new CreateEditShoeSupplierViewModel
            {
                Id = shoeSupplier.Id,
                SupplierName = shoeSupplier.SupplierName,
            };
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
