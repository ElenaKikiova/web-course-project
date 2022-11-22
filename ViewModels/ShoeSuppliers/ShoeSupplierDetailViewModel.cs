using System.ComponentModel;

namespace CourseProject.ViewModels.ShoeSuppliers
{
    public class ShoeSupplierDetailViewModel
    {
        [DisplayName("Shoe Supplier ID: ")]
        public int Id { get; set; }

        [DisplayName("Supplier: ")]
        public string SupplierName { get; set; }
    }
}
