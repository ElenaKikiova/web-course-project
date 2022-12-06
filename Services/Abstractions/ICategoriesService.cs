using CourseProject.ViewModels.Categories;

namespace CourseProject.Services.Abstractions
{
    public interface ICategoriesService
    {
        CategoryDetailViewModel Get(int id);

        List<CategoryDetailViewModel> GetAll();

        void Add(CreateEditCategoryViewModel createEditCategoryViewModel);

        void Update(CreateEditCategoryViewModel createEditCategoryViewModel);

        void Delete(int id);
    }
}
