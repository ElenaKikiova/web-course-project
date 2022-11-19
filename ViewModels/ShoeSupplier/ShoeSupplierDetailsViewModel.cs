using CourseProject.Models;

namespace CourseProject.ViewModels.ShoeSupplier
{
    public class ShoeSupplierDetailsViewModel
    {
        public int ShoeSupplierId { get; set; }

        public string CompanyName { get; set; }

        public List<Shoe_ShoeSupplier> Shoe_ShoeSuppliers { get; set; }
    }
}
