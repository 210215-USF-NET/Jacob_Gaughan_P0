using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace StoreDL
{
    public class CustomerRepoDB : ICustomerRepository
    {
        private Entity.storeDBContext _context;
        private IMapper _mapper;
        public CustomerRepoDB(Entity.storeDBContext context, IMapper mapper)
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
    }
}