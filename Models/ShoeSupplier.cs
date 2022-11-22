namespace CourseProject.Models
{
    public class ShoeSupplier
    {
        public int Id { get; set; }

        public string SupplierName { get; set; }

        public virtual List<Shoe_ShoeSupplier> Shoe_ShoeSuppliers { get; set; }
            = new List<Shoe_ShoeSupplier>();
    }
}
