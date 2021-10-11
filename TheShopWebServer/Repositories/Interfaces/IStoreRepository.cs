using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheShopWebServer.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        List<Store> Select(string nameofcity);
        void Insert(string nameofcity, string storename, string address);
        void Update(string nameofcity, string storename, string address, string newaddress);
        void  Delete(string storename);
    }
}
