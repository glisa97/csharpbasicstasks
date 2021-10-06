using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheShopWebServer.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        void Get(string nameofcity);
        void Post(string nameofcity, string storename, string address);
        void Put(string nameofcity, string storename, string address, string newaddress);
        void  Delete(string storename);
    }
}
