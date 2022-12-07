using CourseProject.Models;
using CourseProject.Repositories.Abstractions;
using CourseProject.ViewModels.Ratings;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class RatingsController : Controller
    {
        private IRatingsRepository ratingsRepository;
        private IShoesRepository shoesRepository;

        public RatingsController(IRatingsRepository ratingsRepository, IShoesRepository shoesRepository)
        {
            this.ratingsRepository = ratingsRepository;
            this.shoesRepository = shoesRepository;
        }

        public IActionResult Rate(int shoeId)
        {

            Console.WriteLine('W');

            var model = new RatingCreateEditViewModel
            {
                ShoeId = shoeId,
                RateString = "0"
            };

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Rate(RatingCreateEditViewModel ratingCreateEditViewModel)
        {

            Console.WriteLine('W');

            Console.WriteLine(string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)));
            var shoe = this.shoesRepository.Get(ratingCreateEditViewModel.ShoeId);

            if (!ModelState.IsValid) return View(new RatingCreateEditViewModel
            {
                ShoeId = ratingCreateEditViewModel.ShoeId,
                RateString = ratingCreateEditViewModel.RateString,
            });

            Rating rating = new Rating
            {
                ShoeId = ratingCreateEditViewModel.ShoeId,
                Rate = Double.Parse(ratingCreateEditViewModel.RateString)
            };

            ratingsRepository.Insert(rating);

            return RedirectToAction("Details", "Shoes", new { ShoeId = ratingCreateEditViewModel.ShoeId });
        }
    }
}
