using System.Linq;

namespace SportsStore.Models
{
    public interface IProductRepository
    {
        public IQueryable<Product> GetAllProducts();
    }
}
