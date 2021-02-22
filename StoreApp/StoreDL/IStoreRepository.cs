using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public interface IStoreRepository
    {
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer newCustomer);
    }
}