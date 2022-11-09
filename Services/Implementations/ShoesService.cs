using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.Shoes;

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

            Console.WriteLine(shoe);

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
