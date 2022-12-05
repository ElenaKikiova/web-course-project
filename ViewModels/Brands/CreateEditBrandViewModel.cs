using CourseProject.ViewModels.Shoes;
using Microsoft.Build.Framework;

namespace CourseProject.ViewModels.Brands
{
    public class CreateEditBrandViewModel
    {
        public int Id { get; set; }

        [Required]
        public string BrandName { get; set; }

        public List<SelectableShoesViewModel> Shoes { get; set; }
    }
}
