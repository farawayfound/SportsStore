using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class FakeProductRepository : IProductRepository
    {
        // F i e l d s  &  P r o p e r t i e s

        // C o n s t r u c t o r s

        // M e t h o d s

        public IQueryable<Product> GetAllProducts()
        {
            Product[] products = new Product[3];

            products[0] = new Product
            {
                Name = "Football",
                Price = 25
            };

            products[1] = new Product
            {
                Name = "Surf Board",
                Price = 179
            };

            products[2] = new Product
            {
                Name = "Running Shoes",
                Price = 95
            };

            //IEnumerable<Product> enumProducts = products.AsEnumerable<Product>();

            return products.AsQueryable<Product>();

        }

        public Product GetProductById(int productID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetProductsByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
