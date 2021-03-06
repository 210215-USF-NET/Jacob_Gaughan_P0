using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product AddProduct(Product newProduct);
        decimal GetProductPrice(int productId);
        Product GetProductById(int productId);
    }
}