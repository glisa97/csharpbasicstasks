using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheShopWebServer.Repositories.Interfaces;
using TheShopWebServer.Services.Interfaces;

namespace TheShopWebServer.Services.Implementations
{
    public class InventoryService : IInventoryService
    {
        private IInventoryRepository inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
        }
        public void Create(string storename, string productname, int quantity, int unitcost)
        {
            this.inventoryRepository.Insert(storename, productname, quantity, unitcost);
        }
        public List<Inventory> Get(string nameofcity)
        {
           return this.inventoryRepository.Select(nameofcity);
            
        }
        public void Post(string storename, string productname, string newquantity)
        {
            this.inventoryRepository.Update(storename, productname, newquantity);
        }
        public void Delete(string storename, string article)
        {
            this.inventoryRepository.Delete(storename, article);
        }

        
    }
}
