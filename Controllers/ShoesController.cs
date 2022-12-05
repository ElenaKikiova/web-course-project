using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.Shoes;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class ShoesController : Controller
    {
        private IShoesService shoesService;
        private IBrandsService brandsService;

        public ShoesController(IShoesService service, IBrandsService brandsService)
        {
            this.shoesService = service;
            this.brandsService = brandsService;
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

            var brands = this.brandsService.GetAll().ToList();

            if (!ShoeId.HasValue)
            {
                return View(new ShoeCreateEditViewModel()
                {
                    BrandsList = brands
                });
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
                        Name = model.Name,
                        CategoryId = model.CategoryId,
                        ImageUrl = model.ImageUrl,
                        Price = model.Price,
                        BrandsList = brands
                    });
                }
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(ShoeCreateEditViewModel model)
        {

            var brands = this.brandsService.GetAll().ToList();

            if (!ModelState.IsValid)
            {
                Console.WriteLine("errororr");
                return View(new ShoeCreateEditViewModel(){
                    Id = model.Id,
                    BrandId = model.BrandId,
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price,
                    BrandsList = brands
                });
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
