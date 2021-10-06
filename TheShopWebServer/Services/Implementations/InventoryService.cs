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
            this.inventoryRepository.Post(storename, productname, quantity, unitcost);
        }
        public void Get(string nameofcity)
        {
            this.inventoryRepository.Get(nameofcity);
        }
        public void Update(string storename, string productname, string newquantity)
        {
            this.inventoryRepository.Put(storename, productname, newquantity);
        }
        public void Delete(string storename, string article)
        {
            this.inventoryRepository.Delete(storename, article);
        }
    }
}
