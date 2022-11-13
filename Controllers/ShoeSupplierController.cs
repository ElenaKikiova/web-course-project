using CourseProject.Repositories.Abstractions;
using CourseProject.ViewModels.ShoeSupplier;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class ShoeSupplierController : Controller
    {
        private IShoeSupplierRepository shoeSupplierRepository;

        public ShoeSupplierController(IShoeSupplierRepository shoeSupplierRepository)
        {
            this.shoeSupplierRepository= shoeSupplierRepository;
        }

        public IActionResult List()
        {
            var shoeSupplierViewModel = new ShoeSupplierViewModel();
            shoeSupplierViewModel.ShoeSuppliers = shoeSupplierRepository.GetAll();
            return View(shoeSupplierViewModel    );
        }
    }
}
