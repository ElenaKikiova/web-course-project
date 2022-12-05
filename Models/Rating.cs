using Microsoft.Build.Framework;

namespace CourseProject.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        public double Rate { get; set; }

        public int ShoeId { get; set; }

        public virtual Shoe Shoe { get; set; }
    }
}
