using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
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
        public IActionResult Categories()
        {
            IQueryable<string> categories = _repository.GetAllCategories();
            IQueryable<string> lCategories = categories.OrderBy(s => s.Length)
                                                           .ThenBy(s => s);
            return View(lCategories);
        }

        public IActionResult Index(int productPage = 1)
        {   //Use home/index/?productPage=2 to display page 2
            ProductListViewModel plvm = new ProductListViewModel();

            plvm.PagingInformation = new PagingInfo();
            plvm.PagingInformation.CurrentPage = productPage;
            plvm.PagingInformation.ItemsPerPage = _pageSize;
            plvm.PagingInformation.TotalItems =
               _repository.GetAllProducts().Count();

            plvm.Products =
               _repository.GetAllProducts()
                          .OrderBy(p => p.ProductId)
                          .Skip((productPage - 1) * _pageSize)
                          .Take(_pageSize);

            return View(plvm);


            //ViewBag.ProductCount = allProducts.Count();
                                           
        }

        public IActionResult Details(int id = 1)
        {   //use /home/details/?id=2 to display id 2
            Product p = _repository.GetProductById(id);
            if (p != null)
            {
                return View(p);
            }
            return RedirectToAction("index");
        }

        public IActionResult Search(string keyword)
        {
            IQueryable<Product> productSearch = _repository.GetProductsByKeyword(keyword);

            ViewBag.Keyword = keyword; //you can call @ViewBag in the HTML

            return View(productSearch);
        }

        // U p d a t e

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product p)
        {
            _repository.Create(p);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product p = _repository.GetProductById(id);
            if (p!= null)
            {
                return View(p);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Product p)
        {
            Product updatedProduct = _repository.UpdateProduct(p);
            return RedirectToAction("Details",new { id = p.ProductId });
        }

        // D e l e t e

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product p = _repository.GetProductById(id);
            if(p != null)
            {
                return View(p);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete2(Product product, int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
