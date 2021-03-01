using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IProductBL
    {
        List<Product> GetProducts();
        void AddProduct(Product newProduct);
        decimal GetProductPrice(int productId);
        Product GetProductById(int productId);
    }
}