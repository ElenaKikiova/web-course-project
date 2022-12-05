using CourseProject.Models;
using CourseProject.ViewModels.Brands;
using Microsoft.Build.Framework;

namespace CourseProject.ViewModels.Shoes
{
    public class ShoeCreateEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int BrandId { get; set; 

        public Brand Brand { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public List<BrandDetailViewModel> BrandsList { get; set; }
    }
}
