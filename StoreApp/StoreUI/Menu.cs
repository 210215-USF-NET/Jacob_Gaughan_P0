using System;
using StoreModels;
using StoreBL;
using Serilog;
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
            newCustomer.CustomerEmail = Console.ReadLine();

            _customerBL.AddCustomer(newCustomer);

            Console.WriteLine($"New customer added! Welcome {newCustomer.CustomerName}!");
            Log.Information($"New customer added. Details:{newCustomer.ToString()}");

            StartShopping(_customerBL.GetCustomerByName(newCustomer.CustomerName));
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
                    default:
                        Console.WriteLine("Not part of menu! Please try again.");
                        break;
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
                Console.WriteLine($"[{i}] Exit");
                Console.WriteLine("Enter a number: ");

                //get user input
                int userInput = int.Parse(Console.ReadLine());

                if (_locationBL.GetLocationById(userInput) != null)
                {
                    ShopInventory(userInput, custId);
                }
                else if (userInput == i)
                {
                    ExitUI();
                }
                else
                {
                    Console.WriteLine("Not part of menu! Please try again.");
                    continue;
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
                i++;
                Console.WriteLine($"[{j}] Add New Location");
                Console.WriteLine($"[{i}] Exit");
                Console.WriteLine("Enter a number: ");

                //get user input
                int userInput = int.Parse(Console.ReadLine());

                if (_locationBL.GetLocationById(userInput) != null)
                {
                    EditInventory(userInput);
                }
                else if (userInput == j)
                {
                    AddNewLocation();
                    break;
                }
                else if (userInput == i)
                {
                    ExitUI();
                }
                else
                {
                    Console.WriteLine("Not part of menu! Please try again.");
                    continue;
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

            Console.WriteLine($"New location added at {newLocation.Address} {newLocation.City}, {newLocation.State} ({newLocation.Zipcode})!");
            Log.Information($"New location added. Details:{newLocation.ToString()}");
        }
        public void ViewPreviousOrders(int currentCustomerId)
        {
            Console.WriteLine("Sort orders by:");
            Console.WriteLine("[0] (Date) Newest - Oldest");
            Console.WriteLine("[1] (Date) Oldest - Newest");
            Console.WriteLine("[2] (Price) High - Low");
            Console.WriteLine("[3] (Price) Low - High");
            string sortBy = Console.ReadLine();

            switch (sortBy)
            {
                case "0":
                    PrevCustOrdersNewToOld(currentCustomerId);
                    break;
                case "1":
                    PrevCustOrdersOldToNew(currentCustomerId);
                    break;
                case "2":
                    PrevCustOrdersPriceHighToLow(currentCustomerId);
                    break;
                case "3":
                    PrevCustOrdersPriceLowToHigh(currentCustomerId);
                    break;
                default:
                    Console.WriteLine("Not part of menu! Please try again.");
                    break;
            };
        }
        public void PrevCustOrdersNewToOld(int custId)
        {
            bool ordersFound = false;

            foreach (var item in _orderBL.GetOrders())
            {
                if (item.CustomerId == custId)
                {
                    ordersFound = true;
                }
            }

            if (!ordersFound)
            {
                Console.WriteLine("No orders have been placed.");
            }
            else
            {
                foreach (Order order in _orderBL.GetOrders().OrderByDescending(o => o.Date).ToList())
                {
                    if (order.CustomerId == custId)
                    {
                        Console.WriteLine(order.ToString());
                    }
                }
            }
        }
        public void PrevCustOrdersOldToNew(int custId)
        {
            bool ordersFound = false;

            foreach (var item in _orderBL.GetOrders())
            {
                if (item.CustomerId == custId)
                {
                    ordersFound = true;
                }
            }

            if (!ordersFound)
            {
                Console.WriteLine("No orders have been placed.");
            }
            else
            {
                foreach (Order order in _orderBL.GetOrders().OrderBy(o => o.Date).ToList())
                {
                    if (order.CustomerId == custId)
                    {
                        Console.WriteLine(order.ToString());
                    }
                }
            }
        }
        public void PrevCustOrdersPriceHighToLow(int custId)
        {
            bool ordersFound = false;

            foreach (var item in _orderBL.GetOrders())
            {
                if (item.CustomerId == custId)
                {
                    ordersFound = true;
                }
            }

            if (!ordersFound)
            {
                Console.WriteLine("No orders have been placed.");
            }
            else
            {
                foreach (Order order in _orderBL.GetOrders().OrderByDescending(o => o.Total).ToList())
                {
                    if (order.CustomerId == custId)
                    {
                        Console.WriteLine(order.ToString());
                    }
                }
            }
        }
        public void PrevCustOrdersPriceLowToHigh(int custId)
        {
            bool ordersFound = false;

            foreach (var item in _orderBL.GetOrders())
            {
                if (item.CustomerId == custId)
                {
                    ordersFound = true;
                }
            }

            if (!ordersFound)
            {
                Console.WriteLine("No orders have been placed.");
            }
            else
            {
                foreach (Order order in _orderBL.GetOrders().OrderBy(o => o.Total).ToList())
                {
                    if (order.CustomerId == custId)
                    {
                        Console.WriteLine(order.ToString());
                    }
                }
            }
        }
        public void PrevLocOrdersNewToOld(int locId)
        {
            bool ordersFound = false;

            foreach (var item in _orderBL.GetOrders())
            {
                if (item.LocationId == locId)
                {
                    ordersFound = true;
                }
            }

            if (!ordersFound)
            {
                Console.WriteLine("No orders have been placed.");
            }
            else
            {
                foreach (Order order in _orderBL.GetOrders().OrderByDescending(o => o.Date).ToList())
                {
                    if (order.LocationId == locId)
                    {
                        Console.WriteLine(order.ToString());
                    }
                }
            }


        }
        public void PrevLocOrdersOldToNew(int locId)
        {
            bool ordersFound = false;

            foreach (var item in _orderBL.GetOrders())
            {
                if (item.LocationId == locId)
                {
                    ordersFound = true;
                }
            }

            if (!ordersFound)
            {
                Console.WriteLine("No orders have been placed.");
            }
            else
            {
                foreach (Order order in _orderBL.GetOrders().OrderBy(o => o.Date).ToList())
                {
                    if (order.LocationId == locId)
                    {
                        Console.WriteLine(order.ToString());
                    }
                }
            }
        }
        public void PrevLocOrdersPriceHighToLow(int locId)
        {
            bool ordersFound = false;

            foreach (var item in _orderBL.GetOrders())
            {
                if (item.LocationId == locId)
                {
                    ordersFound = true;
                }
            }

            if (!ordersFound)
            {
                Console.WriteLine("No orders have been placed.");
            }
            else
            {
                foreach (Order order in _orderBL.GetOrders().OrderByDescending(o => o.Total).ToList())
                {
                    if (order.LocationId == locId)
                    {
                        Console.WriteLine(order.ToString());
                    }
                }
            }

        }
        public void PrevLocOrdersPriceLowToHigh(int locId)
        {
            bool ordersFound = false;

            foreach (var item in _orderBL.GetOrders())
            {
                if (item.LocationId == locId)
                {
                    ordersFound = true;
                }
            }

            if (!ordersFound)
            {
                Console.WriteLine("No orders have been placed.");
            }
            else
            {
                foreach (Order order in _orderBL.GetOrders().OrderBy(o => o.Total).ToList())
                {
                    if (order.LocationId == locId)
                    {
                        Console.WriteLine(order.ToString());
                    }
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
                            if (_inventoryBL.GetInventoryById(product.ProductID, locId) == null)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine($"[{product.ProductID}] {product.ProductName} {product.ProductPrice}/Pint \t{_inventoryBL.GetQuantity(product.ProductID, locId)} in stock");
                            }
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
            Log.Information($"New order completed. Details:{newOrder.ToString()}");

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
                j = i;
                Console.WriteLine($"[{j}] View order history at Location.");
                i++;
                Console.WriteLine($"[{i}] Exit");
                Console.WriteLine("Enter a number: ");

                //get user input
                int userInput = int.Parse(Console.ReadLine());

                if (_inventoryBL.GetInventoryById(userInput, locId) != null)
                {
                    UpdateProductInventory(userInput, locId);
                    continue;
                }
                else if (userInput == h)
                {
                    AddNewProduct(locId);
                    continue;
                }
                else if (userInput == j)
                {
                    ViewOrdersAtLocation(locId);
                    continue;
                }
                else if (userInput == i)
                {
                    ExitUI();
                }
                else
                {
                    Console.WriteLine("Not part of menu! Please try again.");
                    continue;
                }

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
                    else
                    {
                        Console.WriteLine("Not part of menu! Please try again.");
                        break;
                    }
                }
            } while (stayEditingLocation);
        }
        public void ViewOrdersAtLocation(int locId)
        {
            Console.WriteLine("Sort location orders by:");
            Console.WriteLine("[0] (Date) Newest - Oldest");
            Console.WriteLine("[1] (Date) Oldest - Newest");
            Console.WriteLine("[2] (Price) High - Low");
            Console.WriteLine("[3] (Price) Low - High");
            string sortBy = Console.ReadLine();

            switch (sortBy)
            {
                case "0":
                    PrevLocOrdersNewToOld(locId);
                    break;
                case "1":
                    PrevLocOrdersOldToNew(locId);
                    break;
                case "2":
                    PrevLocOrdersPriceHighToLow(locId);
                    break;
                case "3":
                    PrevLocOrdersPriceLowToHigh(locId);
                    break;
                default:
                    Console.WriteLine("Not part of menu! Please try again.");
                    break;
            };
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

            _productBL.AddProduct(newProduct);

            newInventory.ProductId = _productBL.GetProducts().Last().ProductID;
            newInventory.LocationId = locId;

            _inventoryBL.AddInventory(newInventory);

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