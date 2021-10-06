using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheShopWebServer.Services.Interfaces
{
    public interface IStoreService
    {
        void Create(string nameofcity, string storename, string address);
        void Get(string nameofcity);
        void Update(string nameofcity, string storename, string address, string newaddress);
        void Delete(string storename);
    }
}
