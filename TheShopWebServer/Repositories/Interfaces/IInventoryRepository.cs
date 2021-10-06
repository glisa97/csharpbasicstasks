using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Dapper;

namespace TheShopWebServer.Repositories.Interfaces
{
    public interface IInventoryRepository
    {
        void Get(string nameofcity);
        void Post(string storename, string productname, int quantity, int unitcost);
        void Put(string storename, string productname, string newquantity);
        void Delete(string storename, string article);
    }
}
