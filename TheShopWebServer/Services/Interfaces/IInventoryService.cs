using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheShopWebServer.Services.Interfaces
{
    public interface IInventoryService
    {
        void Create(string storename, string productname, int quantity, int unitcost);

        void Get(string nameofcity);

        void Update(string storename, string productname, string newquantity);

        void Delete(string storename, string article);
        
    }
}
