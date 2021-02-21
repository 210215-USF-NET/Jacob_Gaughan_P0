using System;
using StoreModels;

namespace StoreUI
{
    /// <summary>
    /// Menu class for UI
    /// </summary>

    public class Menu : IMenu
    {
        public void Start()
        {
            Boolean stayMainMenu = true;

                //Main Menu prompt
                Console.WriteLine("Hello!  Welcome to Jake's Ice Creamery");
                Console.WriteLine("[0] Shop Products");
                Console.WriteLine("[1] Management");
                Console.WriteLine("[2] Exit");

            do
            {
                Console.WriteLine("Enter a number: ");
                try
                {
                    //get user input
                    int userInput = int.Parse(Console.ReadLine());
                    stayMainMenu = SelectOption(userInput);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number!");
                    continue;
                }
            }while(stayMainMenu);
        }

        public bool SelectOption(int userInput)
        {
            switch (userInput)
            {
                case 0:
                    ShopProducts();
                    break;
                case 1:
                    Console.WriteLine("1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    ExitUI();
                    return false;
                default:
                    Console.WriteLine("Not part of menu! Please try again.");
                    break;
            }
            return true;
        }

        public void ShopProducts()
        {
            bool stayShopProductsMenu = true;

            Console.WriteLine("Are you a new or returning customer?");
            Console.WriteLine("[0] Returning customer");
            Console.WriteLine("[1] New Customer");
            Console.WriteLine("[2] Go back");
            Console.WriteLine("[3] Exit");

            do
            {
                Console.WriteLine("Enter a number: ");
                try
                {
                    //get user input
                    int userInput = int.Parse(Console.ReadLine());

                    switch (userInput)
                    {
                        case 0:
                            Console.WriteLine("Please enter email: ");
                            Console.ReadLine();
                            //TODO: Check input for matching customer
                            break;
                        case 1:
                            Customer newCustomer = new Customer();
                            Console.WriteLine("Please enter name: ");
                            newCustomer.CustomerName = Console.ReadLine();
                            Console.WriteLine("Please enter email: ");
                            newCustomer.CustomerEmail = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("2");
                            Start();
                            break;
                        case 3:
                            ExitUI();
                            break;
                        default:
                            Console.WriteLine("Not part of menu! Please try again.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Try again!");
                    continue;
                }
            }while(stayShopProductsMenu);
        }

        public void ExitUI()
        {
            Console.WriteLine("Goodbye! Please come again! :)");
            System.Environment.Exit(1);
        }
    }
}