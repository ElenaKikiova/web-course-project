namespace CourseProject.Models
{
    public class Discount
    {
        public int Id { get; set; }

        public double DiscountPercentage { get; set; }

        public virtual ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();
    }
}
