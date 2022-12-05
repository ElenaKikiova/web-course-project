using CourseProject.Repositories.Abstractions;
using CourseProject.Services.Abstractions;
using CourseProject.Services.Implementations;
using CourseProject.ViewModels.Brands;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CourseProject.Controllers
{
    public class BrandsController : Controller
    {
        private IBrandsService brandsService;

        public BrandsController(IBrandsService service)
        {
            this.brandsService = service;
        }

        public IActionResult ListAllBrands()
        {
            var list = this.brandsService.GetAll();
            return View(list);
        }
        public IActionResult Details(int BrandId)
        {
            var model = this.brandsService.Get(BrandId);
            return View(model);
        }

        public IActionResult Edit(int? BrandId)
        {
            Console.WriteLine('e');
            if (!BrandId.HasValue)
            {
                Console.WriteLine(BrandId);
                return View(new CreateEditBrandViewModel());
            }
            else
            {
                var model = this.brandsService.Get(BrandId.Value);

                if (model == null)
                {
                    return RedirectToAction("ListAllBrands");
                }
                else
                {

                    return View(new CreateEditBrandViewModel()
                    {
                        Id = BrandId.Value,
                        BrandName = model.BrandName
                    });
                }
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(CreateEditBrandViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
                Console.WriteLine('p');
            }

            if (model.Id == 0)
            {
                this.brandsService.Add(model);
            }
            else
            {
                this.brandsService.Update(model);
            }
            return RedirectToAction("ListAllBrands");
        }

        public IActionResult Delete(int BrandId)
        {
            this.brandsService.Delete(BrandId);
            return RedirectToAction("ListAllBrands");
        }
    }
}
