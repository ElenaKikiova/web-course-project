using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.Shoes;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class ShoesController : Controller
    {
        private IShoesService shoesService;

        public ShoesController(IShoesService service)
        {
            this.shoesService = service;
        }

        public IActionResult AllShoes()
        {
            var list = this.shoesService.GetAll();
            return View(list);
        }
    }
}
