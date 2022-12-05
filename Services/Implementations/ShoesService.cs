using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.Shoes;
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

        public List<ShoeDetailsViewModel> GetAll()
        {
            return this.shoesRepository.GetAll().Select(shoe => new ShoeDetailsViewModel
            {
                Id = shoe.Id,
                Name = shoe.Name,
                Price = shoe.Price,
                ImageUrl = shoe.ImageUrl,
                CategoryId = shoe.CategoryId,
                BrandId = shoe.BrandId,
            }).ToList();
        }

        public ShoeDetailsViewModel Get(int ShoeId)
        {
            Shoe shoe = this.shoesRepository.Get(ShoeId);
             

            if (shoe == null)
            {
                return null;
            }

            ShoeDetailsViewModel shoeDetails = new ShoeDetailsViewModel
            {
                Id= shoe.Id,
                Name= shoe.Name,
                Price= shoe.Price,
                BrandId= shoe.BrandId,
                CategoryId= shoe.CategoryId,
                ImageUrl= shoe.ImageUrl
            };
            return shoeDetails;
        } 

        public ShoeDetailsViewModel GetShoeWithRelations(int ShoeId)
        {
            var shoeInDatabase =  shoesRepository.GetShoeQueryable()
                .Include(shoe => shoe.Ratings)
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
                Rating = shoeInDatabase.Ratings.Count == 0 ? 0 : shoeInDatabase.Ratings.Select(rating => rating.Rate).Average()
            };
        }

        public List<ShoeDetailsViewModel> GetAllShoesWithRelations(int ShoeId)
        {
            return shoesRepository.GetShoeQueryable()
                .Include(shoe => shoe.Ratings)
                .Select(shoe => new ShoeDetailsViewModel
                {
                    Id = shoe.Id,
                    Name = shoe.Name,
                    Price = shoe.Price,
                    BrandId = shoe.BrandId,
                    CategoryId = shoe.CategoryId,
                    ImageUrl = shoe.ImageUrl,
                    Rating = shoe.Ratings.Count == 0 ? 0 : shoe.Ratings.Select(rating => rating.Rate).Average()
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
