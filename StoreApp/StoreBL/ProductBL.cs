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

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }
    }
}
