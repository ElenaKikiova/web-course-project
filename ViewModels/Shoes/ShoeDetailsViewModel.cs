using CourseProject.Models;

namespace CourseProject.ViewModels.Shoes
{
    public class ShoeDetailsViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public double Rating { get; set; }
    }
}

