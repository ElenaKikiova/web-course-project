using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.Shoes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult Details(int ShoeId)
        {
            var model = this.shoesService.Get(ShoeId);
            return View(model);
        }

        public IActionResult Edit(int ShoeId)
        {
            var model = this.shoesService.Get(ShoeId);
            return View(model);
        }

        public IActionResult Delete(int ShoeId)
        {
            this.shoesService.Delete(ShoeId);
            return RedirectToAction("List");
        }
    }
}
