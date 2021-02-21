using System;
using System.Text.RegularExpressions;

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
            IMenu menu = new Menu();
            menu.Start();
        }
    }
}
