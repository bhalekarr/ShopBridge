using ShopBridge.Data;
using System.Collections.Generic;

namespace ShopBridge.Models
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public SqlProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Product Add(Product productAdd)
        {
            _context.Products.Add(productAdd);
            _context.SaveChanges();
            return productAdd;
        }

        public Product Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public Product Update(Product productUpdate)
        {
            var product = _context.Products.Attach(productUpdate);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return productUpdate;
        }
    }
}
