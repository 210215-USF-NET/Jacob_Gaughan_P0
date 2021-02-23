using System.Collections.Generic;
using StoreModels;
using System.IO;
using System.Text.Json;
using System;

namespace StoreDL
{
    public class CustomerRepoFile : ICustomerRepository
    {
        private string jsonString;
        private string filePath = "../StoreDL/FileStorage/CustomerFiles.json";
        public Customer AddCustomer(Customer newCustomer)
        {
            List<Customer> customersFromFile = GetCustomers();
            customersFromFile.Add(newCustomer);
            jsonString = JsonSerializer.Serialize(customersFromFile);
            File.WriteAllText(filePath, jsonString);
            return newCustomer;
        }

        public List<Customer> GetCustomers()
        {
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                return new List<Customer>();
            }
            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }
    }
}