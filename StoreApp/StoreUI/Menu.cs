using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;
using System.Collections;

namespace StoreUI
{
    /// <summary>
    /// Menu class for UI
    /// </summary>

    public class Menu : IMenu
    {
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private IProductBL _productBL;
        public Menu(ICustomerBL customerBL, ILocationBL locationBL, IProductBL productBL)
        {
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
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

            //     switch (userInput)
            //     {
            //         case "0":
            //             userType = "customer";
            //             AddNewCustomer();
            //             break;
            //         case "1":
            //             userType = "customer";
            //             SearchCustomers();
            //             break;
            //         case "2":
            //             userType = "manager";
            //             ChooseLocation();
            //             break;
            //         default:
            //             Console.WriteLine("Not part of menu! Please try again.");
            //             continue;
            //     }

            } while (stayMainMenu);
        }

//         public void AddNewCustomer()
//         {
//             //create new customer
//             Customer newCustomer = new Customer();
//             Console.WriteLine("Please enter first name: ");
//             newCustomer.CustomerFirstName = Console.ReadLine().ToLower();
//             Console.WriteLine("Please enter last name: ");
//             newCustomer.CustomerLastName = Console.ReadLine().ToLower();
//             Console.WriteLine("Please enter email: ");
//             newCustomer.CustomerEmail = Console.ReadLine().ToLower();

//             _customerBL.AddCustomer(newCustomer);

//             Console.WriteLine($"New customer added! Welcome {newCustomer.CustomerFirstName}!");

//             StartShopping(newCustomer.PrevOrders);
//         }
//         public void SearchCustomers()
//         {
//             //get users input for first and last name
//             Console.WriteLine("Please enter first name: ");
//             string userInputFirst = Console.ReadLine().ToLower();
//             Console.WriteLine("Please enter last name: ");
//             string userInputLast = Console.ReadLine().ToLower();

//             //Gets all customers & compares to input
//             foreach (var item in _customerBL.GetCustomers())
//             {
//                 if (item.CustomerFirstName == userInputFirst && item.CustomerLastName == userInputLast)
//                 {
//                     Console.WriteLine($"Customer found! Welcome {item.CustomerFirstName}!");
//                     StartShopping(item.PrevOrders);
//                 }
//             }
//             Console.WriteLine($"Customer {userInputFirst} {userInputLast} was not found.");
//             Start();
//         }
//         public void StartShopping(string prevOrders)
//         {
//             bool stayMainMenu = true;

//             Console.WriteLine("Customer menu:");

//             do
//             {
//                 //Customer Menu prompt
//                 Console.WriteLine("[0] View previous orders");
//                 Console.WriteLine("[1] View locations");
//                 Console.WriteLine("[2] Exit");
//                 Console.WriteLine("Enter a number: ");

//                 //get user input
//                 string userInput = Console.ReadLine();

//                 switch (userInput)
//                 {
//                     case "0":
//                         ViewPreviousOrders(prevOrders);
//                         break;
//                     case "1":
//                         ChooseLocation();
//                         break;
//                     case "2":
//                         ExitUI();
//                         break;
//                     default:
//                         Console.WriteLine("Not part of menu! Please try again.");
//                         continue;
//                 }

//             } while (stayMainMenu);
//         }
//         public void ChooseLocation()
//         {
//             bool stayChooseLocation = true;

//             Console.WriteLine("Choose a location.");
//             do
//             {
//                 //display locations
//                 int i = 0;
//                 foreach (var item in _locationBL.GetLocations())
//                 {
//                     Console.WriteLine($"[{item.LocationID}] {item.City}, {item.State} ({item.Zipcode})");
//                     i++;
//                 }
//                 Console.WriteLine($"[{i}] Exit");
//                 Console.WriteLine("Enter a number: ");

//                 //get user input
//                 int userInput = int.Parse(Console.ReadLine());

//                 foreach (var item in _locationBL.GetLocations())
//                 {
//                     if (userInput == item.LocationID)
//                     {
//                         if (userType == "customer")
//                         {
//                             ShopInventory(item.LocationID);
//                         }
//                         else if (userType == "manager")
//                         {
//                             EditInventory(item.LocationID);
//                         }
//                     }
//                     else if (userInput == i)
//                     {
//                         ExitUI();
//                     }
//                 }
//             } while (stayChooseLocation);
//         }

//         public void ViewPreviousOrders(string prevOrders)
//         {

//             if (prevOrders == null || prevOrders == "")
//             {
//                 Console.WriteLine($"You have not placed any orders.");
//             }
//             else
//             {
//                 //Print out all previous orders
//                 Console.WriteLine($"Your previous orders: \n {prevOrders}");
//             }
//             Console.WriteLine("Enter any key to continue:");
//             Console.ReadLine();
//         }

//         public void ShopInventory(int id)
//         {
//             List<int> productIDs = new List<int>();
//             List<string> productNames = new List<string>();
//             foreach (var item in _productBL.GetProducts())
//             {
//                 if (item.LocationID == id)
//                 {
//                     Console.WriteLine($"[{item.ProductID}] {item.ProductName} ${item.ProductPrice}");
//                     productIDs.Add(item.ProductID);
//                     productNames.Add(item.ProductName);
//                 }
//             }

//             bool stillShopping = true;

//             do
//             {
//                 foreach (var item in _productBL.GetProducts())
//                 {
//                     if (item.LocationID == id)
//                     {
//                         Console.WriteLine($"[{item.ProductID}] {item.ProductName} ${item.ProductPrice}");
//                         productIDs.Add(item.ProductID);
//                         productNames.Add(item.ProductName);
//                     }
//                 }
//                 Console.WriteLine("Enter number of item you want to purchase.");
//                 int userInput = int.Parse(Console.ReadLine());

//                 if (userInput >= productIDs[0] && userInput < productIDs[productIDs.Count])
//                 {
//                     Console.WriteLine($"{productNames[userInput]} was added to your cart.");
//                     //TODO Add to cart method
//                 }
//                 else
//                 {
//                     Console.WriteLine("Please enter a valid product number.");
//                 }

//                 bool isCustomerStillShopping = true;
//                 do
//                 {
//                     Console.WriteLine("Would you like to keep shopping?");
//                     Console.WriteLine("[0] Yes");
//                     Console.WriteLine("[1] No");
//                     Console.WriteLine("[2] Back to locations");

//                     string inputKeepShopping = Console.ReadLine();

//                     switch (inputKeepShopping)
//                     {
//                         case "0":
//                             isCustomerStillShopping = false;
//                             break;
//                         case "1":
//                             isCustomerStillShopping = false;
//                             break;
//                         case "2":
//                             ChooseLocation();
//                             break;
//                         default:
//                             Console.WriteLine("Not part of menu! Please try again.");
//                             break;
//                     }
//                 } while (isCustomerStillShopping);

//             } while (stillShopping);

//         }

//         public void EditInventory(int id)
//         {
//             _locationBL.GetLocations();
//             Console.WriteLine($"You are editing. {_locationBL}");
//         }

//         public void ExitUI()
//         {
//             Console.WriteLine("Goodbye! Please come again! :)");
//             System.Environment.Exit(1);
//         }
    }
}