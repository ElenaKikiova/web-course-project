using CourseProject.Models;
using System.ComponentModel;

namespace CourseProject.ViewModels.Categories
{
    public class CategoryDetailViewModel
    {
        [DisplayName("Category ID: ")]
        public int Id { get; set; }

        [DisplayName("Category name: ")]
        public string CategoryName { get; set; }

        public List<Shoe> Shoes;
    }
}
