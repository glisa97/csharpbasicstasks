using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheShopWebServer.Repositories.Interfaces;
using TheShopWebServer.Services.Interfaces;

namespace TheShopWebServer.Services.Implementations
{
    public class StoreService : IStoreService
    {
        private IStoreRepository storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            this.storeRepository = storeRepository;
        }
        public void Create(string nameofcity, string storename, string address) {
            this.storeRepository.Insert(nameofcity, storename, address);
        }
        public List<Store> Get(string nameofcity) {
            return this.storeRepository.Select(nameofcity);
        }
        public void Post(string nameofcity, string storename, string address, string newaddress) {
            this.storeRepository.Update(nameofcity,storename,address,address);
        }
        public void Delete(string storename) {
            this.storeRepository.Delete(storename);
        }
    }
}
