using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using CourseProject.ViewModels.Ratings;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class RatingsController : Controller
    {
        private IRatingsRepository ratingsRepository;

        public RatingsController(IRatingsRepository ratingsRepository)
        {
            this.ratingsRepository = ratingsRepository;
        }

        public IActionResult Rate(int shoeId)
        {
            var model = new RatingCreateEditViewModel
            {
                ShoeId = shoeId
            };

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Rate(RatingCreateEditViewModel ratingCreateEditViewModel)
        {
            if (!ModelState.IsValid) return View(ratingCreateEditViewModel);

            Rating rating = new Rating
            {
                ShoeId = ratingCreateEditViewModel.ShoeId,
                Rate = ratingCreateEditViewModel.Rate
            };

            ratingsRepository.Insert(rating);

            return RedirectToAction("Details", "Shoes", new { ShoeId = ratingCreateEditViewModel.ShoeId });
        }
    }
}
