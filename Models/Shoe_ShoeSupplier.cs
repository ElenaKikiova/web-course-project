namespace CourseProject.Models
{
    public class Shoe_ShoeSupplier
    {
        public int Id { get; set; }

        public int ShoeId { get; set; }

        public int ShoeSupplierId { get; set; }

        public Shoe Shoe { get; set; }

        public ShoeSupplier ShoeSupplier { get; set; }
    }
}
