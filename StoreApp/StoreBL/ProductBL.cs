using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class ProductBL : IProductBL
    {
        private IProductRepository _repo;
        public ProductBL(IProductRepository repo){
            _repo = repo;
        }
        public void AddProduct(Product newProduct)
        {
            _repo.AddProduct(newProduct);
        }

        public decimal GetProductPrice(int productId)
        {
            return _repo.GetProductPrice(productId);
        }
        public Product GetProductById(int productId)
        {
            return _repo.GetProductById(productId);
        }

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }
    }
}
