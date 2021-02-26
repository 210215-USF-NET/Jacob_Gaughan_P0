using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IDataRepository
    {
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer newCustomer);
        Customer GetCustomerByName(string name);
    }
}