using Microsoft.Build.Framework;

namespace CourseProject.ViewModels.Categories
{
    public class CreateEditCategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
