using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface ICustomerBL
    {
        List<Customer> GetCustomers();
        void AddCustomer(Customer newCustomer);
        Customer GetCustomerByName(string name);
    }
}