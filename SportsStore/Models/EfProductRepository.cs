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
        public IQueryable<Product> GetAllProducts()
        {
            return _context.Products;
        }
    }
}
