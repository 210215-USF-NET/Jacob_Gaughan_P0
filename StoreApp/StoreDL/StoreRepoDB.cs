using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace StoreDL
{
    public class StoreRepoDB : ICustomerRepository, ILocationRepository, IProductRepository
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

        public Customer GetCustomerByName(string name)
        {
            return _context.Customers.Include("Orders").AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList().FirstOrDefault(x => x.CustomerName == name);
        }

        public List<Model.Customer> GetCustomers()
        {
            return _context.Customers.Include("Orders").AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList();
        }

        public List<Model.Location> GetLocations()
        {
            return _context.Locations.Select(x => _mapper.ParseLocation(x)).ToList();
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
    }
}