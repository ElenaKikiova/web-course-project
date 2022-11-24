using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.ShoeSuppliers;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class ShoeSupplierController : Controller
    {
        private readonly IShoeSupplierService shoeSupplierService;

        private readonly IShoesService shoesService;

        public ShoeSupplierController(IShoeSupplierService shoeSupplierService, IShoesService shoesService)
        {
            this.shoeSupplierService = shoeSupplierService;
            this.shoesService = shoesService;
        }

        public IActionResult ListAllShoeSuppliers()
        {
            var shoeSupplierDetailList = shoeSupplierService.GetAll();
            return View(shoeSupplierDetailList);
        }

        public IActionResult ShoeSupplierDetails(int id)
        {
            var shoeSupplierDetail = shoeSupplierService.GetById(id);
            return View(shoeSupplierDetail);
        }

        public IActionResult EditShoeSupplier(int? id)
        {
            if (!id.HasValue) return View(new CreateEditShoeSupplierViewModel
            {
                Shoes = shoesService.GetSelectableShoes()
            });

            CreateEditShoeSupplierViewModel model = shoeSupplierService.GetShoe(id.Value);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditShoeSupplier(CreateEditShoeSupplierViewModel viewModel)
        {
            if (ModelState.IsValid) return View(viewModel);

            if (viewModel.Id == 0) shoeSupplierService.Insert(viewModel);
            else shoeSupplierService.Update(viewModel);

            return RedirectToAction("ListAllShoeSuppliers");
        }

        public IActionResult DeleteShoeSupplier(int id)
        {
            shoeSupplierService.Delete(id);
            return RedirectToAction("ListAllShoeSuppliers");
        }
    }
}
