using System;
using StoreModels;
using StoreBL;
using StoreDL;
using StoreDL.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace StoreUI
{
    class Program
    {
        /// <summary>
        /// This is the main method, its the starting point of your application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //get the config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //setting up db connection
            string connectionString = configuration.GetConnectionString("StoreDB");
            DbContextOptions<storeDBContext> options = new DbContextOptionsBuilder<storeDBContext>()
            .UseSqlServer(connectionString)
            .Options;

            //using statement used to dispose of the context when its no longer used 
            using var context = new storeDBContext(options);

            IMenu menu = new Menu2(new CustomerBL(new CustomerRepoDB(context, new CustomerMapper())));
            menu.Start();
        }
    }
}
