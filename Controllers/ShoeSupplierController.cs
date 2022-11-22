using CourseProject.Services.Abstractions;
using CourseProject.ViewModels.ShoeSuppliers;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class ShoeSupplierController : Controller
    {
        private readonly IShoeSupplierService shoeSupplierService;

        public ShoeSupplierController(IShoeSupplierService shoeSupplierService)
        {
            this.shoeSupplierService = shoeSupplierService;
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
            if (!id.HasValue) return View(new CreateEditShoeSupplierViewModel());

            var shoeSupplierDetailViewModel = shoeSupplierService.GetById(id.Value);

            if (shoeSupplierDetailViewModel == null) return RedirectToAction("ListAllShoeSuppliers");

            return View(new CreateEditShoeSupplierViewModel()
            {
                Id = shoeSupplierDetailViewModel.Id,
                SupplierName = shoeSupplierDetailViewModel.SupplierName,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditShoeSupplier(CreateEditShoeSupplierViewModel createEditShoeSupplierViewModel)
        {
            if (!ModelState.IsValid) return View(createEditShoeSupplierViewModel);

            if (createEditShoeSupplierViewModel.Id == 0) shoeSupplierService.Insert(createEditShoeSupplierViewModel);
            else shoeSupplierService.Update(createEditShoeSupplierViewModel);

            return RedirectToAction("ListAllShoeSuppliers");
        }

        public IActionResult DeleteShoeSupplier(int id)
        {
            shoeSupplierService.Delete(id);
            return RedirectToAction("ListAllShoeSuppliers");
        }
    }
}
