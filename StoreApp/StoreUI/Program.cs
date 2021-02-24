using System;
using StoreModels;
using StoreBL;
using StoreDL;

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
            //call method that starts main user interface
            IMenu menu = new Menu(
                new CustomerBL(new CustomerRepoFile()),
                new LocationBL(new LocationRepoFile()),
                new ProductBL(new ProductRepoFile())
                );
            menu.Start();
        }
    }
}
