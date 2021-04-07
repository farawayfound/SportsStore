using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        // F i e l d s  &  P r o p e r t i e s

        private IProductRepository _repository;
        private int _pageSize = 3;

        // C o n s t r u c t o r s
        public HomeController(IProductRepository repository) // Dependency Injection - DI
        {                                                    // Inversion of Control - IOC
            _repository = repository;
        }

        // M e t h o d s
        //public IActionResult Index() 
        //    => View(_repository.GetAllProducts());
        
            //// 1. Go to database and get data out.
            //IQueryable<Product> allProducts = _repository.GetAllProducts();
            //// 2. Send that data to the view
            //return View(allProducts);

        public IActionResult Index(int productPage = 1)
        {
            IQueryable<Product> allProducts = _repository.GetAllProducts();
            IQueryable<Product> someProducts = allProducts.OrderBy(p => p.ProductId)
                                                          .Skip((productPage - 1) * _pageSize)
                                                          .Take(_pageSize);
            return View(someProducts);                                              
        }
    }
}
