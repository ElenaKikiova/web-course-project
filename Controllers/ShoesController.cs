using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.Shoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CourseProject.Controllers
{
    public class ShoesController : Controller
    {
        private IShoesService shoesService;
        private IBrandsService brandsService;
        private ICategoriesService categoriesService;

        public ShoesController(IShoesService service, IBrandsService brandsService, ICategoriesService categoriesService)
        {
            this.shoesService = service;
            this.brandsService = brandsService;
            this.categoriesService = categoriesService;
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
            var categories = this.categoriesService.GetAll().ToList();

            if (!ShoeId.HasValue)
            {
                return View(new ShoeCreateEditViewModel()
                {
                    BrandsList = brands,
                    CategoriesList = categories
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
                        BrandsList = brands,
                        CategoriesList = categories
                    });
                }
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(ShoeCreateEditViewModel model)
        {

            var brands = this.brandsService.GetAll().ToList();
            var categories = this.categoriesService.GetAll().ToList();

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Error");
                Console.WriteLine(string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)));
                return View(new ShoeCreateEditViewModel(){
                    Id = model.Id,
                    BrandId = model.BrandId,
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    ImageUrl = model.ImageUrl,
                    Price = model.Price,
                    BrandsList = brands,
                    CategoriesList = categories
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
