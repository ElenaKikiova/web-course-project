    namespace CourseProject.Models
{
    public class ShoeSupplier
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public List<Shoe_ShoeSupplier> Shoe_ShoeSuppliers { get; set; }
    }
}
