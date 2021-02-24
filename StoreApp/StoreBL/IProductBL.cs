using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IProductBL
    {
        List<Product> GetProducts();
        void AddProduct(Product newProduct);
    }
}