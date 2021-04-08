using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SportsStore.Models
{
    public interface IProductRepository
    {
        // C r e a t e
        public Product Create(Product p);

        // R e a d
        public IQueryable<Product> GetAllProducts();

        public Product GetProductById(int productID);

        public IQueryable<Product> GetProductsByKeyword(string keyword);

        public IQueryable<string> GetAllCategories();

        // U p d a t e

        public Product UpdateProduct(Product p);

        // D e l e t e
        public bool Delete(int id);
    }
}
