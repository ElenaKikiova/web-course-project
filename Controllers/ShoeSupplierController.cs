using CourseProject.Repositories.Abstractions;
using CourseProject.ViewModels.ShoeSuppliers;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Controllers
{
    public class ShoeSupplierController : Controller
    {
        private IShoeSupplierRepository shoeSupplierRepository;

        public ShoeSupplierController(IShoeSupplierRepository shoeSupplierRepository)
        {
            this.shoeSupplierRepository = shoeSupplierRepository;
        }

        public IActionResult ListAllShoeSuppliers()
        {
            var allShoeSuppliersViewModel = new AllShoeSuppliersViewModel();
            allShoeSuppliersViewModel.ShoeSuppliers = shoeSupplierRepository.GetAll(); 
            return View(allShoeSuppliersViewModel);
        }
    }
}
