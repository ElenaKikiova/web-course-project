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
        public IActionResult Details(int ShoeId)
        {
            var model = this.shoesService.Get(ShoeId);
            return View(model);
        }

        public IActionResult Edit(int? ShoeId)
        {
            if (!ShoeId.HasValue)
            {
                return View(new ShoeCreateEditViewModel());
            }
            else
            {
                var model = this.shoesService.Get(ShoeId.Value);

                if (model == null)
                {
                    return RedirectToAction("AllShoes");
                }
                else
                {

                    return View(new ShoeCreateEditViewModel()
                    {
                        Id = ShoeId.Value,
                        BrandId = model.BrandId,
                        Brand = model.Brand,
                        Name = model.Name,
                        CategoryId = model.CategoryId,
                        ImageUrl = model.ImageUrl,
                        Price = model.Price
                    });
                }
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(ShoeCreateEditViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id == 0)
            {
                this.shoesService.Add(model);
            }
            else
            {
                this.shoesService.Update(model);
            }
            return RedirectToAction("AllShoes");
        }

        public IActionResult Delete(int ShoeId)
        {
            this.shoesService.Delete(ShoeId);
            return RedirectToAction("AllShoes");
        }
    }
}
