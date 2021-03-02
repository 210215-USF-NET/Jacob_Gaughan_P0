using System;
using Serilog;
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
            //configure logger
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File("../StoreDL/logs/Logs.json")
                .CreateLogger();

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

            IMenu menu = new Menu(new CustomerBL(new StoreRepoDB(context, new StoreMapper())), new LocationBL(new StoreRepoDB(context, new StoreMapper())), new ProductBL(new StoreRepoDB(context, new StoreMapper())), new OrderBL(new StoreRepoDB(context, new StoreMapper())), new InventoryBL(new StoreRepoDB(context, new StoreMapper())));
            menu.Start();
        }
    }
}
