using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories
{
    public class AddInventoryUseCase : IAddInventoryUseCase
    {
        private readonly IInventoryRepository iventoryRepository;

        public AddInventoryUseCase(IInventoryRepository iventoryRepository)
        {
            this.iventoryRepository = iventoryRepository;
        }
        public async Task ExecuteAsync(Inventory inventory)
        {
            await this.iventoryRepository.AddInventoryAsync(inventory);
        }
    }
}
