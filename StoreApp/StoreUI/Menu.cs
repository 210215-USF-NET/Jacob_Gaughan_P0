using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;

namespace StoreUI
{
    /// <summary>
    /// Menu class for UI
    /// </summary>

    public class Menu : IMenu
    {
        private ICustomerBL _customerBL;
        public Menu(ICustomerBL customerBL)
        {
            _customerBL = customerBL;
        }

        private string userType;

        public void Start()
        {
            bool stayMainMenu = true;

            Console.WriteLine("Hello! Welcome to Jake's Ice Creamery! :D");

            do
            {
                //Main Menu prompt
                Console.WriteLine("[0] Add Customer");
                Console.WriteLine("[1] Search Customer");
                Console.WriteLine("[2] Management");
                Console.WriteLine("[3] Exit");
                Console.WriteLine("Enter a number: ");

                //get user input
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        AddNewCustomer();
                        break;
                    case "1":
                        SearchCustomers();
                        break;
                    case "2":
                        userType = "manager";
                        break;
                    default:
                        Console.WriteLine("Not part of menu! Please try again.");
                        continue;
                }

            } while (stayMainMenu);
        }

        public void AddNewCustomer(){
            //create new customer
            Customer newCustomer = new Customer();
            Console.WriteLine("Please enter first name: ");
            newCustomer.CustomerFirstName = Console.ReadLine().ToLower();
            Console.WriteLine("Please enter last name: ");
            newCustomer.CustomerLastName = Console.ReadLine().ToLower();
            Console.WriteLine("Please enter email: ");
            newCustomer.CustomerEmail = Console.ReadLine().ToLower();
            
            _customerBL.AddCustomer(newCustomer);

            Console.WriteLine($"New customer added! Welcome {newCustomer.CustomerFirstName}!");

            StartShopping(newCustomer.PrevOrders);
        }
        public void SearchCustomers(){
            //get users input for first and last name
            Console.WriteLine("Please enter first name: ");
            string userInputFirst = Console.ReadLine().ToLower();
            Console.WriteLine("Please enter last name: ");
            string userInputLast = Console.ReadLine().ToLower();

            //Gets all customers & compares to input
            foreach (var item in _customerBL.GetCustomers())
            {
                if(item.CustomerFirstName == userInputFirst && item.CustomerLastName == userInputLast){
                    Console.WriteLine($"Customer found! Welcome {item.CustomerFirstName}!");
                    StartShopping(item.PrevOrders);
                }
            }
        }
        public void StartShopping(string prevOrders){
            bool stayMainMenu = true;

            Console.WriteLine("Hello! Welcome to Jake's Ice Creamery! :D");

            do
            {
                //Customer Menu prompt
                Console.WriteLine("[0] View previous orders");
                Console.WriteLine("[1] Place an order");
                Console.WriteLine("[2] Exit");
                Console.WriteLine("Enter a number: ");

                //get user input
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        ViewPreviousOrders(prevOrders);
                        break;
                    case "1":
                        ChooseLocation("customer");
                        break;
                    case "2":
                        ExitUI();
                        break;
                    default:
                        Console.WriteLine("Not part of menu! Please try again.");
                        continue;
                }

            } while (stayMainMenu);
        }
        public void ChooseLocation(string userType)
        {
            Console.WriteLine("choosing location");
        }

        public void ViewPreviousOrders(string prevOrders){

            if(prevOrders == null || prevOrders == ""){
                Console.WriteLine($"You have not placed any orders.");
            }
            else
            {
                //Print out all previous orders
                Console.WriteLine($"Your previous orders: \n {prevOrders}");
            }
            Console.WriteLine($"Enter any key to continue:");
            Console.ReadLine();
        }

        public void ExitUI()
        {
            Console.WriteLine("Goodbye! Please come again! :)");
            System.Environment.Exit(1);
        }
    }
}