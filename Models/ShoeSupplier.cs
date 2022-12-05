using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.Models
{
    public class ShoeSupplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SupplierName { get; set; }
        
        public virtual ICollection<Shoe_ShoeSupplier> Shoe_ShoeSuppliers { get; set; }
            = new List<Shoe_ShoeSupplier>();
    }
}
