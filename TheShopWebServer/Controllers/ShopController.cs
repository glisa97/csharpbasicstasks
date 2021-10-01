using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using Microsoft.AspNetCore.Http;

namespace TheShopWebServer.Controllers
{
    [ApiController]
    public class ShopController : Controller
    {

        [HttpGet]
        [Route("api/shop/getinventories/{storename}")]
        public List<Inventory> GetInventories(string storename)
        {
            List<Inventory> inventories;
            string connectionStringInv = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStringInv))
            {
                string selectFromDatabase = $"SELECT storename, productname, quantity, date, unitcost FROM shop.inventory WHERE storename = '{storename}'; ";
                inventories = connection.Query<Inventory>(selectFromDatabase).AsList();
                
            }
            return inventories;
            
        }

        [HttpGet]
        [Route("api/shop/getstores/{nameofcity}")]
        public List<Store> GetStores(string nameofcity)
        {
            List<Store> stores;
            string connectionStringcity = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStringcity))
            {
                string selectFromDatabase = $"SELECT nameofcity, storename, address FROM shop.stores WHERE nameofcity = '{nameofcity}'; ";
                stores = connection.Query<Store>(selectFromDatabase).AsList();
                
            }
            return stores;
        }
        
    }
}
