using System;
using StoreModels;
using StoreBL;

namespace StoreUI
{
    /// <summary>
    /// Menu class for UI
    /// </summary>

    public class Menu : IMenu
    {
        private string userType;

        public void Start()
        {
            Boolean stayMainMenu = true;

            Console.WriteLine("Hello! Welcome to Jake's Ice Creamery! :D");

            do
            {
                //Main Menu prompt
                Console.WriteLine("[0] Shop Products");
                Console.WriteLine("[1] Management");
                Console.WriteLine("[2] Exit");
                Console.WriteLine("Enter a number: ");

                //get user input
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        CustomerInfo();
                        break;
                    case "1":
                        Management();
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

        public void CustomerInfo()
        {
            userType = "Customer";
            bool stayShopProductsMenu = true;

            Console.WriteLine("Are you a returning or a new customer?");

            do
            {
                Console.WriteLine("[0] Returning customer");
                Console.WriteLine("[1] New Customer");
                Console.WriteLine("[2] Go back");
                Console.WriteLine("[3] Exit");
                Console.WriteLine("Enter a number: ");

                //get user input
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        Console.WriteLine("Please enter name: ");
                        Console.ReadLine();
                        //TODO: Check input for matching customer
                        break;
                    case "1":
                        Customer newCustomer = new Customer();
                        Console.WriteLine("Please enter name: ");
                        newCustomer.CustomerName = Console.ReadLine();
                        Console.WriteLine("Please enter email: ");
                        newCustomer.CustomerEmail = Console.ReadLine();

                        Console.WriteLine($"Welcome {newCustomer.CustomerName}!");

                        StartShopping();
                        break;
                    case "2":
                        Console.WriteLine("2");
                        Start();
                        break;
                    case "3":
                        ExitUI();
                        break;
                    default:
                        Console.WriteLine("Not part of menu! Please try again.");
                        continue;
                }
            } while (stayShopProductsMenu);
        }
        public void Management()
        {
            userType = "manager";
            ChooseLocation(userType);
        }

        public void StartShopping(){
            userType = "customer";
            ChooseLocation(userType);
        }

        public void ChooseLocation(string userType)
        {
            if(userType == "customer")
            {
                Console.WriteLine("Start Shopping!");
            }
            else
            {
                Console.WriteLine("Restocking some shelves I see.");
            }

            bool choosingLocation = true;
            string location = "";

            Console.WriteLine("Choose Location");

            do
            {
                Console.WriteLine("[0] Hays, KS (67601)");
                Console.WriteLine("[1] Durango, CO (81302)");
                Console.WriteLine("[2] Go back");
                Console.WriteLine("[3] Exit");

                Console.WriteLine("Enter a number: ");

                //get user input
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        location = "Hays";
                        //Select Hays, KS location
                        GoToLocation(location);
                        break;
                    case "1":
                        location = "Durango";
                        //Select Durango, CO location
                        GoToLocation(location);
                        break;
                    case "2":
                        //Go back to start
                        Start();
                        break;
                    case "3":
                        ExitUI();
                        break;
                    default:
                        Console.WriteLine("Not part of menu! Please try again.");
                        continue;
                }
            } while (choosingLocation);
        }

        public void GoToLocation(string location)
        {
            Console.WriteLine($"Welcome to our {location} store!");
            ExitUI();
        }

        public void ExitUI()
        {
            Console.WriteLine("Goodbye! Please come again! :)");
            System.Environment.Exit(1);
        }
    }
}