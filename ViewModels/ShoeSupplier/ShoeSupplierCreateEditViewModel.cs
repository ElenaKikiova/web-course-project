using Microsoft.Build.Framework;

namespace CourseProject.ViewModels.ShoeSupplier
{
    public class ShoeSupplierCreateEditViewModel
    {
        public int ShoeSupplierId { get; set; }

        [Required]
        public string CompanyName { get; set; }
    }
}
