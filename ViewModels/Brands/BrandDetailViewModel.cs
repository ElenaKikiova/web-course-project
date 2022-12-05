using CourseProject.Models;
using CourseProject.ViewModels.Shoes;
using System.ComponentModel;

namespace CourseProject.ViewModels.Brands
{
    public class BrandDetailViewModel
    {
        [DisplayName("Brand ID: ")]
        public int Id { get; set; }

        [DisplayName("Brand name: ")]
        public string BrandName { get; set; }

        public List<Shoe> Shoes;
    }
}
