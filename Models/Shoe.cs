namespace CourseProject.Models
{
    public class Shoe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public string ImageUrl { get; set; }
        public string Name { get; set; }    
        public float Price { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        public virtual ICollection<Shoe_ShoeSupplier> Shoe_ShoeSuppliers { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<Shoe_ShoeSupplier> Shoe_ShoeSuppliers { get; set; }
            = new List<Shoe_ShoeSupplier>();
    }
}
