using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class AppBL : IAppBL
    {
        private IStoreRepository _repo;
        public AppBL(IStoreRepository repo){
            _repo = repo;
        }
        public void AddCustomer(Customer newCustomer)
        {
            // TODO add Business Logic
            _repo.AddCustomer(newCustomer);
        }

        public List<Customer> GetCustomers()
        {
            // TODO add Business Logic
            return _repo.GetCustomers();
        }
    }
}
