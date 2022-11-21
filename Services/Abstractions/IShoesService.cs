using CourseProject.ViewModels.Shoes;

namespace CourseProject.Services.Abstractions
{
    public interface IShoesService
    {
        List<ShoeDetailsViewModel> GetAll();
        ShoeDetailsViewModel Get(int ShoeId);
        void Add(ShoeCreateEditViewModel model);
        void Update(ShoeCreateEditViewModel model);
        void Delete(int ShoeId);
    }
}
