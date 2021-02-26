using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
using System;
using StoreDL;
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

        public Model.Order ParseOrder(Entity.Order order)
        {
            return new Model.Order
            {
                Total = order.Total,
                Date = order.Date,
                Id = order.Id
            };
        }

        public Entity.Order ParseOrder(Model.Order order)
        {
            //when customer has no orders, NO id is set
            if(order.Id == null)
            {
                return new Entity.Order
                {
                    Customer = order.Customer.Id,
                    Total = order.Total,
                    Date = order.Date,
                };
            }
            //for updating and deleting
            return new Entity.Order
            {
                Customer = order.Customer.Id,
                Total = order.Total,
                Date = order.Date,
                Id = (int)order.Id
            };
        }

        public Model.Location ParseLocation(Entity.Location location)
        {
            return new Model.Location
            {
                City = location.City,
                State = location.State,
                Zipcode = location.Zipcode,
                LocationID = location.Id
            };
        }

        public Entity.Location ParseLocation(Model.Location location)
        {
            //when there are no locations, NO id is set
            if(location == null)
            {
                return new Entity.Location
                {
                    City = location.City,
                    State = location.State,
                    Zipcode = location.Zipcode
                };
            }
            //for updating and deleting
            return new Entity.Location
            {
                City = location.City,
                State = location.State,
                Zipcode = location.Zipcode,
                Id = (int)location.LocationID
            };
        }

        public Model.Product ParseProduct(Entity.Product product)
        {
            return new Model.Product
            {
                ProductName = product.Name,
                ProductPrice = product.Price,
                ProductID = product.Id
            };
        }

        public Entity.Product ParseProduct(Model.Product product)
        {
            //when there are no products, NO id is set
            if(product == null)
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
    }
}