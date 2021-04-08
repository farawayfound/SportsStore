using Microsoft.AspNetCore.Mvc;
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
        public Product Create(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
            return p;
        }


        //  R e a d

        public IQueryable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public IQueryable<string> GetAllCategories()
        {
            IQueryable<string> categories = _context.Products
                                                    .Select(p => p.Category)
                                                    .Distinct();
                                                    //.OrderBy(c => c);
            return categories;
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

        public Product UpdateProduct(Product p) //Use as template for updating item in database
        {
            Product productToUpdate = _context.Products.Find(p.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Category = p.Category;
                productToUpdate.Description = p.Description;
                productToUpdate.Name = p.Name;
                productToUpdate.Price = p.Price;
                _context.SaveChanges();
            }
            return productToUpdate;
        }

        //  D e l e t e
        public bool Delete(int id)
        {
            Product productToDelete = GetProductById(id); //Calling another method in the same class
            if (productToDelete == null)
            {
                return false;
            }
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
