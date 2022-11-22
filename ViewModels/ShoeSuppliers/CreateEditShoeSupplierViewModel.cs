using Microsoft.Build.Framework;

namespace CourseProject.ViewModels.ShoeSuppliers
{
    public class CreateEditShoeSupplierViewModel
    {
        public int Id { get; set; }

        [Required]
        public string SupplierName { get; set; }
    }
}
