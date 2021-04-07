using System.Linq;

namespace SportsStore.Models
{
    public interface IProductRepository
    {
        public IQueryable<Product> GetAllProducts();

        public Product GetProductById(int productID);

        public IQueryable<Product> GetProductsByKeyword(string keyword);
    }
}
