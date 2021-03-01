using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
namespace StoreDL
{
    public class StoreMapper : IStoreMapper
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
            //when customer is a new customer, NO id is set
            if(customer.Id == 0)
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

        public Model.Order ParseOrder(Entity.Order order)
        {
            return new Model.Order
            {
                Total = order.Total,
                Date = order.Date,
                CustomerId = order.CustomerId,
                LocationId = order.LocationId,
                Id = order.Id
            };
        }

        public Entity.Order ParseOrder(Model.Order order)
        {
            //when customer has no orders, NO id is set
            if(order.Id == 0)
            {
                return new Entity.Order
                {
                    Total = order.Total,
                    Date = order.Date,
                    CustomerId = order.CustomerId,
                    LocationId = order.LocationId
                };
            }
            //for updating and deleting
            return new Entity.Order
            {
                Total = order.Total,
                Date = order.Date,
                CustomerId = order.CustomerId,
                LocationId = order.LocationId,
                Id = order.Id
            };
        }

        public Model.Location ParseLocation(Entity.Location location)
        {
            return new Model.Location
            {
                Address = location.Address,
                City = location.City,
                State = location.State,
                Zipcode = location.Zipcode,
                Id = location.Id
            };
        }

        public Entity.Location ParseLocation(Model.Location location)
        {
            //when there are no locations, NO id is set
            if(location.Id == 0)
            {
                return new Entity.Location
                {
                    Address = location.Address,
                    City = location.City,
                    State = location.State,
                    Zipcode = location.Zipcode
                };
            }
            //for updating and deleting
            return new Entity.Location
            {
                Address = location.Address,
                City = location.City,
                State = location.State,
                Zipcode = location.Zipcode,
                Id = location.Id
            };
        }

        public Model.Product ParseProduct(Entity.Product product)
        {
            return new Model.Product
            {
                ProductName = product.Name,
                ProductPrice = product.Price,
                ProductID = product.Id,
            };
        }

        public Entity.Product ParseProduct(Model.Product product)
        {
            //when there are no products, NO id is set
            if(product.Id == 0)
            {
                return new Entity.Product
                {
                    Name = product.ProductName,
                    Price = product.ProductPrice,
                };
            }
            //for updating and deleting
            return new Entity.Product
            {
                Name = product.ProductName,
                Price = product.ProductPrice,
                Id = product.ProductID
            };
        }
        public Model.Inventory ParseInventory(Entity.Inventory inventory)
        {
            return new Model.Inventory
            {
                Id = inventory.Id,
                Quantity = inventory.Quantity,
                ProductId = inventory.ProductId,
                LocationId = inventory.LocationId
            };
        }
        public Entity.Inventory ParseInventory(Model.Inventory inventory)
        {
            //when there are no inventories, NO id is set
            if(inventory.Id == 0)
            {
                return new Entity.Inventory
                {
                    Quantity = inventory.Quantity,
                    ProductId = inventory.ProductId,
                    LocationId = inventory.LocationId
                };
            }
            //for updating and deleting
            return new Entity.Inventory
            {
                Id = inventory.Id,
                Quantity = inventory.Quantity,
                ProductId = inventory.ProductId,
                LocationId = inventory.LocationId
            };
        }

    }
}