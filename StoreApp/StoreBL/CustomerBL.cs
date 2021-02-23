using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepository _repo;
        public CustomerBL(ICustomerRepository repo){
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
