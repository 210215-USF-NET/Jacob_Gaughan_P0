﻿using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IAppBL
    {
        List<Customer> GetCustomers();
        void AddCustomer(Customer newCustomer);
    }
}