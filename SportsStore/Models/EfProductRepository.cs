using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EfProductRepository : IProductRepository
    {
        // F i e l d s  &  P r o p e r t i e s

        private AppDbContext _context;

        // C o n s t r u c t o r s
        public EfProductRepository(AppDbContext context)
        {
            _context = context;
        }

        // M e t h o d s


        //  C r e a t e


        //  R e a d
        public IQueryable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetProductById(int productId)
        {
            /*Product p = _context.Products
                                .Where(p => p.ProductId == productId)
                                .FirstOrDefault();*/
            Product p = _context.Products.Find(productId);
            return p;
        }

        public IQueryable<Product> GetProductsByKeyword(string keyword)
        {
            IQueryable<Product> products = _context.Products
                                                   .Where(p => p.Name.Contains(keyword));
            return products;
        }

        //  U p d a t e


        //  D e l e t e
    }
}
