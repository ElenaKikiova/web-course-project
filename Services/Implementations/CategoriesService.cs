using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Services.Implementations
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public List<CategoryDetailViewModel> GetAll()
        {

            return this.categoriesRepository.GetAll()
                 .Select(category => new CategoryDetailViewModel
                 {
                     Id = category.Id,
                     CategoryName = category.CategoryName,
                     Shoes = category.Shoes.ToList()
                 }).ToList();
        }

        public CategoryDetailViewModel Get(int CategoryId)
        {
            var category = categoriesRepository.GetAll()
                .Include(b => b.Shoes)
                .FirstOrDefault(b => b.Id == CategoryId);

            var viewModel = new CategoryDetailViewModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Shoes = category.Shoes.ToList<Shoe>()
            };


            return viewModel;
        }

        public void Add(CreateEditCategoryViewModel createEditCategoryViewModel)
        {
            var category = new Category()
            {
                Id = createEditCategoryViewModel.Id,
                CategoryName = createEditCategoryViewModel.CategoryName
            };

            categoriesRepository.Add(category);
        }

        public void Update(CreateEditCategoryViewModel createEditCategoryViewModel)
        {
            var category = new Category()
            {
                Id = createEditCategoryViewModel.Id,
                CategoryName = createEditCategoryViewModel.CategoryName
            };
            categoriesRepository.Update(category);
        }

        public void Delete(int id)
        {
            categoriesRepository.Delete(id);
        }
    }
}
