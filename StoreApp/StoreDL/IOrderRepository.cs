using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        Order AddOrder(Order newOrder);
    }
}