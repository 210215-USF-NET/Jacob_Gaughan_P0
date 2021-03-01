using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IInventoryRepository
    {
        List<Inventory> GetInventories();
        void UpdateInventory(Inventory inventory2bupdated);
        int GetQuantity(int prodId, int locId);
        Inventory GetInventoryById(int prodId, int locId);
        Inventory AddInventory(Inventory newInventory);
    }
}