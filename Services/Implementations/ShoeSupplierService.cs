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

        private readonly IShoesRepository shoesRepository;

        public ShoeSupplierService(IShoeSupplierRepository shoeSupplierRepository, IShoesRepository shoesRepository)
        {
            this.shoeSupplierRepository = shoeSupplierRepository;
            this.shoesRepository = shoesRepository;
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

        public CreateEditShoeSupplierViewModel GetShoe(int id)
        {
            var shoeSupplier = shoeSupplierRepository.GetAll()
                .Include(s => s.Shoe_ShoeSuppliers)
                .ThenInclude(shoe_shoeSupplier => shoe_shoeSupplier.Shoe)
                .FirstOrDefault(s => s.Id == id);

            var viewModel = new CreateEditShoeSupplierViewModel
            {
                Id = shoeSupplier.Id,
                SupplierName = shoeSupplier.SupplierName,
            };

            List<Shoe> shoes = shoesRepository.GetAll().ToList();

            viewModel.Shoes = shoes.Select(shoe => new SelectableShoesViewModel
            {
                Id = shoe.Id,
                CategoryId = shoe.CategoryId,
                BrandId = shoe.BrandId,
                ImageUrl = shoe.ImageUrl,
                Name = shoe.Name,
                Price = shoe.Price,
                IsSelected = shoeSupplier.Shoe_ShoeSuppliers
                .Select(shoe_shoeSupplier => shoe_shoeSupplier.ShoeId)
                .Contains(shoe.Id)
            }).ToList();

            return viewModel;
        }

        public void Insert(CreateEditShoeSupplierViewModel createEditShoeSupplierViewModel)
        {
            var shoeSupplier = new ShoeSupplier()
            {
                Id = createEditShoeSupplierViewModel.Id,
                SupplierName = createEditShoeSupplierViewModel.SupplierName
            };

            shoeSupplierRepository.Insert(shoeSupplier);

            var createdShoeSupplier = shoeSupplierRepository.GetAll()
                .FirstOrDefault(shoeSupplier => shoeSupplier.SupplierName == createEditShoeSupplierViewModel.SupplierName);

            createdShoeSupplier.Shoe_ShoeSuppliers = createEditShoeSupplierViewModel.Shoes
                .Where(shoe => shoe.IsSelected)
                .Select(shoe => new Shoe_ShoeSupplier
                {
                    ShoeId = shoe.Id,
                    ShoeSupplierId = createdShoeSupplier.Id
                }).ToList();

            shoeSupplierRepository.Update(createdShoeSupplier);
        }

        public void Update(CreateEditShoeSupplierViewModel createEditShoeSupplierViewModel)
        {
            var shoeSupplier = new ShoeSupplier()
            {
                Id = createEditShoeSupplierViewModel.Id,
                SupplierName = createEditShoeSupplierViewModel.SupplierName,
                Shoe_ShoeSuppliers = createEditShoeSupplierViewModel.Shoes
                .Where(shoe => shoe.IsSelected)
                .Select(shoe => new Shoe_ShoeSupplier
                {
                    ShoeId = shoe.Id,
                    ShoeSupplierId = createEditShoeSupplierViewModel.Id
                }).ToList()
            };
            shoeSupplierRepository.Update(shoeSupplier);
        }

        public void Delete(int id)
        {
            shoeSupplierRepository.Delete(id);
        }
    }
}
