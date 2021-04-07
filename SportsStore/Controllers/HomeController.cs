using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        // F i e l d s  &  P r o p e r t i e s

        private IProductRepository _repository;

        // C o n s t r u c t o r s
        public HomeController(IProductRepository repository) // Dependency Injection - DI
        {                                                    // Inversion of Control - IOC
            _repository = repository;
        }

        // M e t h o d s
        public IActionResult Index()
        {
            //// 1. Go to database and get data out.
            //IQueryable<Product> allProducts = _repository.GetAllProducts();
            //// 2. Send that data to the view
            //return View(allProducts);

            return View(_repository.GetAllProducts());
        }
    }
}
