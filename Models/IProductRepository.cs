using System.Collections.Generic;

namespace ShopBridge.Models
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetAllProducts();
        Product Add(Product productAdd);
        Product Update(Product productUpdate);
        Product Delete(int id);
    }
}
