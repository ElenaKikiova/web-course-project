using CourseProject.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class ShoeSupplierController : Controller
    {
        private IShoeSupplierService shoeSupplierService;

        public ShoeSupplierController(IShoeSupplierService shoeSupplierService)
        {
            this.shoeSupplierService = shoeSupplierService;
        }

        public IActionResult List()
        {
            return View(shoeSupplierService.GetAll());
        }

        public IActionResult Details(int shoeSupplierId)
        {
            var ShoeSupplier = shoeSupplierService.GetById(shoeSupplierId);
            return View(shoeSupplierId);
        }
    }
}
