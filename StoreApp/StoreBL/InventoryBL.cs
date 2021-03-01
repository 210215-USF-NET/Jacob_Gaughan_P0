using System.Collections.Generic;
using StoreModels;
using StoreDL;

namespace StoreBL
{
    public class InventoryBL : IInventoryBL
    {
        private IInventoryRepository _repo;
        public InventoryBL(IInventoryRepository repo){
            _repo = repo;
        }
        public int GetQuantity(int prodId, int locId)
        {
            return _repo.GetQuantity(prodId, locId);
        }
        public List<Inventory> GetInventories()
        {
            return _repo.GetInventories();
        }
        public Inventory GetInventoryById(int prodId, int locId)
        {
            return _repo.GetInventoryById(prodId, locId);
        }
        public void UpdateInventory(Inventory inventory2Bupdated, Inventory updatedInventory)
        {
            inventory2Bupdated.Quantity = updatedInventory.Quantity;

            _repo.UpdateInventory(inventory2Bupdated);
        }
        public void AddInventory(Inventory newInventory)
        {
            _repo.AddInventory(newInventory);
        }
    }
}