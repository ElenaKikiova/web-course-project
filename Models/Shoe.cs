﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.Models
{
    public class Shoe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }
        public string Name { get; set; }    
        public float Price { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        public virtual Brand Brand { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Shoe_ShoeSupplier> Shoe_ShoeSuppliers { get; set; }
            = new List<Shoe_ShoeSupplier>();
    }
}
