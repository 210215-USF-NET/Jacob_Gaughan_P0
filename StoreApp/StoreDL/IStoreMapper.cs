using Model = StoreModels;
using Entity = StoreDL.Entities;
namespace StoreDL
{
    /// <summary>
    /// To parse entities from DB to models used in BL and vice versa 
    /// </summary>
    public interface IStoreMapper
    {
        Model.Customer ParseCustomer(Entity.Customer customer);
        Entity.Customer ParseCustomer(Model.Customer customer);
        Model.Order ParseOrder(Entity.Order order);
        Entity.Order ParseOrder(Model.Order order);
        Model.Location ParseLocation(Entity.Location location);
        Entity.Location ParseLocation(Model.Location location);
        Model.Product ParseProduct(Entity.Product product);
        Entity.Product ParseProduct(Model.Product product);
        Model.Inventory ParseInventory(Entity.Inventory inventory);
        Entity.Inventory ParseInventory(Model.Inventory inventory);
    }
}