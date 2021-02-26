using Model = StoreModels;
using Entity = StoreDL.Entities;
namespace StoreDL
{
    /// <summary>
    /// To parse entities from DB to models used in BL and vice versa 
    /// </summary>
    public interface IMapper
    {
        Model.Customer ParseCustomer(Entity.Customer customer);
        Entity.Customer ParseCustomer(Model.Customer customer);
    }
}