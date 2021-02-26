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
        Model.Order ParseOrder(Entity.Order Order);
        Entity.Order ParseOrder(Model.Order Order);
        Model.Location ParseLocation(Entity.Location Location);
        Entity.Location ParseLocation(Model.Location Location);
        Model.Product ParseProduct(Entity.Product Product);
        Entity.Product ParseProduct(Model.Product Product);
    }
}