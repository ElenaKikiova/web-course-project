namespace CourseProject.Models
{
    public class Shoe
    {
        public int Id { get; set; } 
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public string ImageUrl { get; set; }
        public string Name { get; set; }    
        public float Price { get; set; }

        public int DiscountId { get; set; }

        public Discount ShoeDiscount { get; set; }

        public virtual ICollection<Shoe_ShoeSupplier> Shoe_ShoeSuppliers { get; set; }
            = new List<Shoe_ShoeSupplier>();
    }
}
