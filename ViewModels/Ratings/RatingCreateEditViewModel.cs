using CourseProject.Models;
using System.ComponentModel;

namespace CourseProject.ViewModels.Ratings
{
    public class RatingCreateEditViewModel
    {
        public int ShoeId { get; set; }

        [DisplayName("Rating:")]
        public string RateString { get; set; }
    }
}
