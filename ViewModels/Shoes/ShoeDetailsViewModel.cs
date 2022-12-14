using CourseProject.Models;
using Microsoft.AspNetCore.Components;

namespace CourseProject.ViewModels.Shoes
{
    public class ShoeDetailsViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public double Rating { get; set; }

        public int RatingsCount { get; set; }


    }
}

