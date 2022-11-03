using CourseProject.Repositories.Abstractions;
using CourseProject.ViewModels.Shoes;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class ShoesController : Controller
    {
        private IShoesRepository shoesRepository;

        public ShoesController(IShoesRepository repository)
        {
            this.shoesRepository = repository;
        }

        public IActionResult AllShoes()
        {
            AllShoesViewModel allShoesViewModel = new AllShoesViewModel();
            allShoesViewModel.Shoes = shoesRepository.GetAll();
            return View(allShoesViewModel);
        }
    }
}
