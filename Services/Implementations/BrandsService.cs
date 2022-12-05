using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.Shoes;
using CourseProject.ViewModels.Brands;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Services.Implementations
{
    public class BrandsService : IBrandsService
    {
        private readonly IBrandsRepository brandsRepository;

        public BrandsService(IBrandsRepository brandsRepository)
        {
            this.brandsRepository = brandsRepository;
        }

        public List<BrandDetailViewModel> GetAll()
        {
            /*return this.brandsRepository.GetAll()
                 .Include(brand => brand.Shoes)
                 .Select(brand => new BrandDetailViewModel
                 {
                     Id = brand.Id,
                     BrandName = brand.BrandName,
                     Shoes = brand.Shoes.ToList()
                 }).ToList();*/

            return this.brandsRepository.GetAll()
                 .Select(brand => new BrandDetailViewModel
                 {
                     Id = brand.Id,
                     BrandName = brand.BrandName,
                     Shoes = brand.Shoes.ToList()
                 }).ToList();
        }

        public BrandDetailViewModel Get(int BrandId)
        {
            var brand = brandsRepository.GetAll()
                .Include(b => b.Shoes)
                .FirstOrDefault(b => b.Id == BrandId);

            var viewModel = new BrandDetailViewModel
            {
                Id = brand.Id,
                BrandName = brand.BrandName,
                Shoes = brand.Shoes.ToList<Shoe>()
            };


            return viewModel;
        }

        public void Add(CreateEditBrandViewModel createEditBrandViewModel)
        {
            var brand = new Brand()
            {
                Id = createEditBrandViewModel.Id,
                BrandName = createEditBrandViewModel.BrandName
            };

            brandsRepository.Add(brand);
        }

        public void Update(CreateEditBrandViewModel createEditBrandViewModel)
        {
            var brand = new Brand()
            {
                Id = createEditBrandViewModel.Id,
                BrandName = createEditBrandViewModel.BrandName
            };
            brandsRepository.Update(brand);
        }

        public void Delete(int id)
        {
            brandsRepository.Delete(id);
        }
    }
}
