using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.Shoes;
using CourseProject.ViewModels.ShoeSuppliers;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Services.Implementations
{
    public class ShoesService : IShoesService
    {
        private readonly IShoesRepository shoesRepository;

        public ShoesService(IShoesRepository repository)
        {
            this.shoesRepository = repository;
        }

        public ShoeDetailsViewModel Get(int ShoeId)
        {
            var shoeInDatabase = shoesRepository.GetAll()
                .Include(shoe => shoe.Ratings)
                .Include(shoe => shoe.Brand)
                .Include(shoe => shoe.Category)
                .FirstOrDefault(shoe => shoe.Id == ShoeId);

            if (shoeInDatabase == null) return null;

            return new ShoeDetailsViewModel
            {
                Id = shoeInDatabase.Id,
                Name = shoeInDatabase.Name,
                Price = shoeInDatabase.Price,
                BrandId = shoeInDatabase.BrandId,
                CategoryId = shoeInDatabase.CategoryId,
                ImageUrl = shoeInDatabase.ImageUrl,
                Brand = shoeInDatabase.Brand,
                Category = shoeInDatabase.Category,
                Rating = shoeInDatabase.Ratings.Count == 0 ? 0 : Math.Round(shoeInDatabase.Ratings.Select(rating => rating.Rate).Average(), 1),
                RatingsCount = shoeInDatabase.Ratings.Count
            };
        }

        public List<ShoeDetailsViewModel> GetAll()
        {
            return shoesRepository.GetAll()
                .Include(shoe => shoe.Ratings)
                .Include(shoe => shoe.Brand)
                .Select(shoe => new ShoeDetailsViewModel
                {
                    Id = shoe.Id,
                    Name = shoe.Name,
                    Price = shoe.Price,
                    BrandId = shoe.BrandId,
                    CategoryId = shoe.CategoryId,
                    ImageUrl = shoe.ImageUrl,
                    Brand = shoe.Brand,
                    Category = shoe.Category,
                    Rating = Math.Round(shoe.Ratings.Count == 0 ? 0 : shoe.Ratings.Select(rating => rating.Rate).Average(), 1),
                    RatingsCount = shoe.Ratings.Count
                }).ToList();
        }

        public List<SelectableShoesViewModel> GetSelectableShoes()
        {
            return this.shoesRepository.GetAll().Select(shoe => new SelectableShoesViewModel
            {
                Id = shoe.Id,
                Name = shoe.Name,
                Price = shoe.Price,
                ImageUrl = shoe.ImageUrl,
                CategoryId = shoe.CategoryId,
                BrandId = shoe.BrandId,
                IsSelected = false
            }).ToList();
        }

        public void Add(ShoeCreateEditViewModel model)
        {
            var shoe = new Shoe()
            {
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };
            this.shoesRepository.Add(shoe);

        }

        public void Update(ShoeCreateEditViewModel model)
        {
            var shoe = new Shoe()
            {
                Id = model.Id,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Price = model.Price
            };
            this.shoesRepository.Update(shoe);
        }
        public void Delete(int ShoeId)
        {
            this.shoesRepository.Delete(ShoeId);
        }
    }
}
