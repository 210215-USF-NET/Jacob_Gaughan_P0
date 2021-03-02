using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using StoreModels;
using Serilog;
using System;

namespace StoreDL
{
    public class StoreRepoDB : ICustomerRepository, ILocationRepository, IProductRepository, IOrderRepository, IInventoryRepository
    {
        private Entity.storeDBContext _context;
        private IStoreMapper _mapper;
        public StoreRepoDB(Entity.storeDBContext context, IStoreMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Customer AddCustomer(Model.Customer newCustomer)
        {
            _context.Customers.Add(_mapper.ParseCustomer(newCustomer));
            _context.SaveChanges();
            return newCustomer;
        }
        public List<Model.Customer> GetCustomers()
        {
            return _context.Customers
            .Select(x => _mapper.ParseCustomer(x))
            .ToList();
        }
        public List<Model.Location> GetLocations()
        {
            return _context.Locations
            .Select(x => _mapper.ParseLocation(x))
            .ToList();
        }
        public Location AddLocation(Location newLocation)
        {
            _context.Locations.Add(_mapper.ParseLocation(newLocation));
            _context.SaveChanges();
            return newLocation;
        }
        public Location DeleteLocation(Location location2BDeleted)
        {
            _context.Locations.Remove(_mapper.ParseLocation(location2BDeleted));
            _context.SaveChanges();
            return location2BDeleted;
        }
        public List<Model.Product> GetProducts()
        {
            return _context.Products.Select(x => _mapper.ParseProduct(x)).ToList();
        }
        public Model.Product AddProduct(Product newProduct)
        {
            _context.Products.Add(_mapper.ParseProduct(newProduct));
            _context.SaveChanges();
            return newProduct;
        }
        public List<Model.Order> GetOrders()
        {
            return _context.Orders
            .Select(x => _mapper.ParseOrder(x))
            .ToList();
        }

        public Model.Order AddOrder(Order newOrder)
        {
            _context.Orders.Add(_mapper.ParseOrder(newOrder));
            _context.SaveChanges();
            return newOrder;
        }
        public int GetProductId(int productId)
        {
            return GetProductById(productId).ProductID;
        }
        public Product GetProductById(int productId)
        {
            return _context.Products
            .Select(x => _mapper.ParseProduct(x))
            .ToList()
            .FirstOrDefault(x => x.ProductID == productId);
        }
        public decimal GetProductPrice(int productId)
        {
            return GetProductById(productId).ProductPrice;
        }
        public List<Inventory> GetInventories()
        {
            return _context.Inventories
            .Select(x => _mapper.ParseInventory(x))
            .ToList();
        }
        public Inventory GetInventoryById(int prodId, int locId)
        {
            return _context.Inventories
            .Select(x => _mapper.ParseInventory(x))
            .ToList()
            .FirstOrDefault(x => (x.ProductId == prodId && x.LocationId == locId));
        }
        public int GetQuantity(int prodId, int locId)
        {
            return GetInventoryById(prodId, locId).Quantity;
        }
        //update inventory that already exists
        public void UpdateInventory(Inventory inventory2BUpdated)
        {
            Entity.Inventory oldInventory = _context.Inventories.Find(inventory2BUpdated.Id);
            _context.Entry(oldInventory).CurrentValues.SetValues(_mapper.ParseInventory(inventory2BUpdated));

            _context.SaveChanges();

            //This method clears the change tracker to drop all tracked entities
            _context.ChangeTracker.Clear();
        }
        public Location GetLocationById(int locId)
        {
            return _context.Locations
            .Select(x => _mapper.ParseLocation(x))
            .ToList()
            .FirstOrDefault(x => (x.Id == locId));
        }

        public Inventory AddInventory(Inventory newInventory)
        {
            _context.Inventories.Add(_mapper.ParseInventory(newInventory));
            _context.SaveChanges();
            return newInventory;
        }
    }
}