using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
namespace StoreDL
{
    public class CustomerMapper : IMapper
    {
        public Model.Customer ParseCustomer(Entity.Customer customer)
        {
            return new Model.Customer
            {
                CustomerName = customer.Name,
                CustomerEmail = customer.Email,
                Id = customer.Id
            };
        }

        public Entity.Customer ParseCustomer(Model.Customer customer)
        {
            //when customer is a new hero, NO id is set
            if(customer.Id == null)
            {
                return new Entity.Customer
                {
                    Name = customer.CustomerName,
                    Email = customer.CustomerEmail
                };
            }
            //for updating and deleting
            return new Entity.Customer
            {
                Name = customer.CustomerName,
                Email = customer.CustomerEmail,
                Id = (int)customer.Id
            };
        }
    }

}