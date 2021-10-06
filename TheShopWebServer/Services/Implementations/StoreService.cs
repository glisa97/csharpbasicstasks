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
            this.storeRepository.Post(nameofcity, storename, address);
        }
        public void Get(string nameofcity) {
            this.storeRepository.Get(nameofcity);
        }
        public void Update(string nameofcity, string storename, string address, string newaddress) {
            this.storeRepository.Post(nameofcity,storename,address);
        }
        public void Delete(string storename) {
            this.storeRepository.Delete(storename);
        }
    }
}
