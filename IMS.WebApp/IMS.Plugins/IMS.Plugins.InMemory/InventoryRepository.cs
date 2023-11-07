using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;
        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory() { InventoryId = 1, IventoryName =" Bike Seat", Quantity = 10, Price = 2 },
                new Inventory() { InventoryId = 2, IventoryName =" Bike Body", Quantity = 10, Price = 15 },
                new Inventory() { InventoryId = 3, IventoryName =" Bike Wheels", Quantity = 20, Price = 8 },
                new Inventory() { InventoryId = 4, IventoryName =" Bike Pedels", Quantity = 20, Price = 1 },
            };
        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if (_inventories.Any(x => x.IventoryName.Equals(inventory.IventoryName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;
            var maxId = _inventories.Max(x => x.InventoryId);
            inventory.InventoryId = maxId + 1;
            _inventories.Add(inventory);
            return Task.CompletedTask;
        }

        public Task<bool> ExistAsync(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public async Task<Inventory> GetInventoriesByIdAsync(int inventoryId)
        {
            var inv = _inventories.First(x => x.InventoryId == inventoryId);
            var newInv = new Inventory
            {
                InventoryId = inv.InventoryId,
                IventoryName = inv.IventoryName,
                Quantity = inv.Quantity,
                Price = inv.Price
            };

            return await Task.FromResult(newInv);
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

            return _inventories.Where(x => x.IventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {

            var inv = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
            if(inv != null)
            {
                inv.IventoryName = inventory.IventoryName;
                inv.Price = inventory.Price;
                inv.Quantity = inventory.Quantity;
            }
            return Task.CompletedTask;
        }
    }
}
