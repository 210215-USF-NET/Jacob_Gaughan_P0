using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IInventoryBL
    {
        List<Inventory> GetInventories();
        void UpdateInventory(Inventory inventory2Bupdated, Inventory updatedInventory);
        int GetQuantity(int prodId, int locId);
        Inventory GetInventoryById(int prodId, int locId);
        void AddInventory(Inventory newInventory);
    }
}