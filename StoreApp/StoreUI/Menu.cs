using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;
using System.Linq;

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
        private IOrderBL _orderBL;
        private IInventoryBL _inventoryBL;
        public Menu(ICustomerBL customerBL, ILocationBL locationBL, IProductBL productBL, IOrderBL orderBL, IInventoryBL inventoryBL)
        {
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _orderBL = orderBL;
            _inventoryBL = inventoryBL;
        }
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
                        ChooseLocation();
                        break;
                    case "3":
                        ExitUI();
                        break;
                    case "4":
                        foreach (var item in _customerBL.GetCustomers())
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    default:
                        Console.WriteLine("Not part of menu! Please try again.");
                        continue;
                }

            } while (stayMainMenu);
        }

        public void AddNewCustomer()
        {
            //create new customer
            Customer newCustomer = new Customer();
            Console.WriteLine("Please enter customers name: ");
            newCustomer.CustomerName = Console.ReadLine();
            Console.WriteLine("Please enter email: ");
            newCustomer.CustomerEmail = Console.ReadLine(); ;

            _customerBL.AddCustomer(newCustomer);

            Console.WriteLine($"New customer added! Welcome {newCustomer.CustomerName}!");

            StartShopping(newCustomer);
        }
        public void SearchCustomers()
        {
            //get users input for first and last name
            Console.WriteLine("Please enter customers name: ");
            string userInputName = Console.ReadLine();

            //Gets all customers & compares to input
            foreach (var item in _customerBL.GetCustomers())
            {
                if (item.CustomerName.ToLower() == userInputName.ToLower())
                {
                    Console.WriteLine($"\nCustomer found! Welcome {item.CustomerName}!");
                    Console.WriteLine(item.ToString());
                    StartShopping(item);
                }
            }
            Console.WriteLine($"Customer {userInputName} was not found.");
            Start();
        }
        public void StartShopping(Customer currentCustomer)
        {
            bool stayCustomerMenu = true;

            Console.WriteLine($"\nCustomer {currentCustomer.CustomerName}'s menu:");

            do
            {
                //Customer Menu prompt
                Console.WriteLine("[0] View previous orders");
                Console.WriteLine("[1] View locations");
                Console.WriteLine("[2] Exit");
                Console.WriteLine("Enter a number: ");

                //get user input
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        ViewPreviousOrders(currentCustomer.Id);
                        break;
                    case "1":
                        ChooseLocation(currentCustomer.Id);
                        break;
                    case "2":
                        ExitUI();
                        break;
                    case "3":
                        ExitUI();
                        break;
                    default:
                        Console.WriteLine("Not part of menu! Please try again.");
                        continue;
                }

            } while (stayCustomerMenu);
        }
        public void ChooseLocation(int custId)
        {
            bool stayChooseLocation = true;

            Console.WriteLine("\nChoose a location.");
            do
            {
                //display locations
                int i = 1;
                foreach (var item in _locationBL.GetLocations())
                {
                    Console.WriteLine($"[{item.Id}] {item.Address} {item.City}, {item.State} ({item.Zipcode})");
                    i++;
                }
                i++;
                Console.WriteLine($"[{i}] Exit");
                Console.WriteLine("Enter a number: ");

                //get user input
                int userInput = int.Parse(Console.ReadLine());

                foreach (var item in _locationBL.GetLocations())
                {
                    if (userInput == item.Id)
                    {
                        ShopInventory(item.Id, custId);
                    }
                    else if (userInput == i)
                    {
                        ExitUI();
                    }
                }
            } while (stayChooseLocation);
        }
        public void ChooseLocation()
        {
            bool stayChooseLocation = true;

            Console.WriteLine("\nChoose a location.");
            do
            {
                //display locations
                int i = 1;
                int j;
                foreach (var item in _locationBL.GetLocations())
                {
                    Console.WriteLine($"[{item.Id}] {item.Address} {item.City}, {item.State} ({item.Zipcode})");
                    i++;
                }
                j = i;
                Console.WriteLine($"[{j}] Add New Location");
                i++;
                Console.WriteLine($"[{i}] Exit");
                Console.WriteLine("Enter a number: ");

                //get user input
                int userInput = int.Parse(Console.ReadLine());

                foreach (var item in _locationBL.GetLocations())
                {
                    if (userInput == item.Id)
                    {
                        EditInventory(item.Id);
                    }
                    else if (userInput == j)
                    {
                        AddNewLocation();
                        continue;
                    }
                    else if (userInput == i)
                    {
                        ExitUI();
                    }
                }
            } while (stayChooseLocation);
        }
        public void AddNewLocation()
        {
            //create new Location
            Location newLocation = new Location();
            Console.WriteLine("Enter locations address number and street:");
            newLocation.Address = Console.ReadLine();
            Console.WriteLine("Enter locations city:");
            newLocation.City = Console.ReadLine();
            Console.WriteLine("Enter locations state:");
            newLocation.State = Console.ReadLine();
            Console.WriteLine("Enter locations zipcode:");
            newLocation.Zipcode = Console.ReadLine();

            _locationBL.AddLocation(newLocation);

            Console.WriteLine($"New Location added at {newLocation.Address} {newLocation.City}, {newLocation.State} ({newLocation.Zipcode})!");
        }
        public void ViewPreviousOrders(int currentCustomerId)
        {
            bool ordersFound = false;

            foreach (var item in _orderBL.GetOrders())
            {
                if (item.CustomerId == currentCustomerId)
                {
                    Console.WriteLine(item.ToString());
                    ordersFound = true;
                }
            }

            if (!ordersFound)
            {
                Console.WriteLine("No orders have been placed.");
            }

            Console.WriteLine("Sort orders by:");
            Console.WriteLine("[0] Newest - Oldest");
            Console.WriteLine("[1] Oldest - Newest");
            string sortBy = Console.ReadLine();

            switch (sortBy)
            {
                case "0":
                    PrevOrdersNewToOld(currentCustomerId);
                    break;
                case "1":
                    PrevOrdersOldToNew(currentCustomerId);
                    break;
            };
        }
        public void PrevOrdersNewToOld(int custId)
        {
            foreach (Order order in _orderBL.GetOrders().OrderByDescending(o => o.Date).ToList())
            {
                if (order.CustomerId == custId)
                {
                    Console.WriteLine(order.ToString());
                }
            }
        }
        public void PrevOrdersOldToNew(int custId)
        {
            foreach (Order order in _orderBL.GetOrders().OrderBy(o => o.Date).ToList())
            {
                if (order.CustomerId == custId)
                {
                    Console.WriteLine(order.ToString());
                }
            }
        }
        public void ShopInventory(int locId, int custId)
        {
            bool stillShopping = true;
            decimal runningTotal = 0.00m;
            do
            {
                Console.WriteLine("Which product you would like to purchase?");

                foreach (var item in _locationBL.GetLocations())
                {
                    if (item.Id == locId)
                    {
                        foreach (var product in _productBL.GetProducts())
                        {
                            //removed "\t{_inventoryBL.GetQuantity(product.ProductID, locId)}" in stock because it was ruining everything
                            Console.WriteLine($"[{product.ProductID}] {product.ProductName} {product.ProductPrice}/Pint");
                        }
                    }
                }
                Console.WriteLine("Enter a number:");
                int userInputKind = int.Parse(Console.ReadLine());

                Console.WriteLine("How many pints would you like?");
                int userInputPints = int.Parse(Console.ReadLine());

                if (userInputPints <= _inventoryBL.GetQuantity(userInputKind, locId))
                {
                    Inventory updatedInventory = new Inventory();
                    updatedInventory.Quantity = _inventoryBL.GetQuantity(userInputKind, locId) - userInputPints;
                    _inventoryBL.UpdateInventory(_inventoryBL.GetInventoryById(userInputKind, locId), updatedInventory);
                    runningTotal += (_productBL.GetProductPrice(userInputKind) * (decimal)userInputPints);
                }
                else
                {
                    Console.WriteLine("Sorry we do not have that in stock.");
                }

                runningTotal = runningTotal + _productBL.GetProductPrice(userInputKind);

                bool isCustomerStillShopping = true;
                do
                {
                    Console.WriteLine("Would you like to keep shopping?");
                    Console.WriteLine("[0] Yes, browse more products.");
                    Console.WriteLine("[1] No, Checkout.");

                    string inputKeepShopping = Console.ReadLine();

                    switch (inputKeepShopping)
                    {
                        case "0":
                            isCustomerStillShopping = false;
                            break;
                        case "1":
                            CheckoutItems(runningTotal, locId, custId);
                            break;
                        default:
                            Console.WriteLine("Not part of menu! Please try again.");
                            break;
                    }
                } while (isCustomerStillShopping);

            } while (stillShopping);

        }
        public void CheckoutItems(decimal total, int locId, int custId)
        {
            DateTime now = DateTime.Now;
            Order newOrder = new Order();
            newOrder.Total = total;
            newOrder.Date = now;
            newOrder.LocationId = locId;
            newOrder.CustomerId = custId;

            _orderBL.AddOrder(newOrder);

            Console.WriteLine($"Purchase complete! \n\t Date: {newOrder.Date} \n\t Total: ${newOrder.Total} \n");

            Console.WriteLine($"Thank you for shopping at Jake's Ice Creamery!");
            ExitUI();
        }

        public void EditInventory(int locId)
        {
            bool stayEditingLocation = true;
            Location currentLocation = _locationBL.GetLocationById(locId);
            do
            {
                Console.WriteLine($"You are editing location {currentLocation.Address} {currentLocation.City}, {currentLocation.State} ({currentLocation.Zipcode})");
                //display products at particular location
                int i = 1;
                int j, h;
                foreach (var item in _inventoryBL.GetInventories())
                {
                    if (item.LocationId == locId)
                    {
                        Console.WriteLine($"[{item.Id}] {_productBL.GetProductById(item.ProductId).ProductName}\tQuantity: {item.Quantity} pints");
                    }
                    i++;
                }
                h = i++;
                Console.WriteLine($"[{h}] Add new product");
                j = i++;
                Console.WriteLine($"[{j}] View order history at Location.");
                i++;
                Console.WriteLine($"[{i}] Exit");
                Console.WriteLine("Enter a number: ");

                //get user input
                int userInput = int.Parse(Console.ReadLine());

                foreach (var item in _inventoryBL.GetInventories())
                {
                    if (userInput == item.Id)
                    {
                        UpdateProductInventory(item.ProductId, item.LocationId);
                    }
                    else if (userInput == h)
                    {
                        AddNewProduct(locId);
                        break;
                    }
                    else if (userInput == j)
                    {
                        ViewOrdersAtLocation(locId);
                        break;
                    }
                    else if (userInput == i)
                    {
                        ExitUI();
                    }
                }
            } while (stayEditingLocation);
        }
        public void ViewOrdersAtLocation(int locId)
        {
            foreach (var item in _orderBL.GetOrders())
            {
                if (item.LocationId == locId)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        public void AddNewProduct(int locId)
        {
            //create new product & inventory for that product
            Product newProduct = new Product();
            Inventory newInventory = new Inventory();
            Console.WriteLine("Please enter product name: ");
            newProduct.ProductName = Console.ReadLine();
            Console.WriteLine("Please enter price of product per pint: ");
            newProduct.ProductPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please enter quantity of product in pints: ");
            newInventory.Quantity = int.Parse(Console.ReadLine());
            newInventory.LocationId = locId;
            newInventory.ProductId = newProduct.ProductID;

            _productBL.AddProduct(newProduct);
            //_inventoryBL.AddInventory(newInventory); TODO: FIND OUT WHY THIS IS BROKEN

            Console.WriteLine($"{newProduct.ProductName} added to products!");
        }
        public void UpdateProductInventory(int prodId, int locId)
        {
            Console.WriteLine("Enter the number of product(by pint) you want to add.");
            int addedQuantity = int.Parse(Console.ReadLine());

            Inventory updatedInventory = new Inventory();
            updatedInventory.Quantity = _inventoryBL.GetQuantity(prodId, locId) + addedQuantity;
            _inventoryBL.UpdateInventory(_inventoryBL.GetInventoryById(prodId, locId), updatedInventory);

            Console.WriteLine("Product Quantity Updated!");
        }
        public void ExitUI()
        {
            Console.WriteLine("Goodbye! Please come again!");
            Console.WriteLine("\t\t_____\t_____\t\t\n\t\t|   |\t|   |\t\t\n\t\t|___|\t|___|\t\t\n\n\t   *** \t\t\t***\n\t     ***\t      ***\n\t\t***\t   ***\n\t\t    ******");
            System.Environment.Exit(1);
        }
    }
}