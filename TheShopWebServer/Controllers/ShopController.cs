using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using Microsoft.AspNetCore.Http;
using TheShopWebServer.Services.Implementations;
using TheShopWebServer.Repositories.Implementations;

namespace TheShopWebServer.Controllers
{
    [ApiController]
    public class ShopController : Controller
    {

        [HttpGet]
        [Route("api/shop/getstores")]
        public List<Store> GetStores(string nameofcity)
        {
            //List<Store> stores;
            //string connectionStringcity = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            //using (NpgsqlConnection connection = new NpgsqlConnection(connectionStringcity))
            //{
            //    string selectFromDatabase = $"SELECT nameofcity, storename, address FROM shop.stores WHERE nameofcity = '{nameofcity}'; ";
            //    stores = connection.Query<Store>(selectFromDatabase).AsList();

            //}
            StoreService storeService = new StoreService(new StoreRepository());
            return storeService.Get(nameofcity);
            
        }
        [HttpPost]
        [Route("api/shop/poststores")]
        public void Insertstores(string nameofcity, string storename, string address)
        {
            //Store addNewStoreTemp = new Store(nameofcity, storename, address);


            //    string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            //    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            //    {
            //        string insertIntoStores = $"INSERT INTO shop.stores(nameofcity, storename, address)VALUES('{nameofcity}','{storename}','{address}');";
            //        connection.Execute(insertIntoStores);
            //    }
            StoreService storeService = new StoreService(new StoreRepository());
            storeService.Create(nameofcity,storename,address);

        }

        [HttpPut]
        [Route("api/shop/changestoreaddress")]
        public void Changestoreaddress(string nameofcity, string storename, string address, string newaddress)
        {

            //string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            //{
            //    string updatestoreaddress = $"UPDATE shop.stores SET address = '{newaddress}' WHERE nameofcity='{nameofcity}' and storename='{storename}' and address='{address}';";
            //    connection.Execute(updatestoreaddress);
            //}
            StoreService storeService = new StoreService(new StoreRepository());
            storeService.Post(nameofcity,storename,address,newaddress);

        }
        [HttpDelete]
        [Route("api/shop/deletestore")]
        public void DeleteStore(string storename)
        {

            //string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            //{
            //    string deletestorefromstores = $"DELETE FROM shop.stores WHERE storename = '{storename}';";
            //    string deletestorefrominventories = $"DELETE FROM shop.inventory WHERE storename = '{storename}';";
            //    connection.Execute(deletestorefromstores);
            //    connection.Execute(deletestorefrominventories);
            //}
            StoreService storeService = new StoreService(new StoreRepository());
            storeService.Delete(storename);

        }

        [HttpGet]
        [Route("api/shop/getinventories")]
        public List<Inventory> GetInventories(string storename)
        {
            //List<Inventory> inventories;
            //string connectionStringInv = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            //using (NpgsqlConnection connection = new NpgsqlConnection(connectionStringInv))
            //{
            //    string selectFromDatabase = $"SELECT storename, productname, quantity, date, unitcost FROM shop.inventory WHERE storename = '{storename}'; ";
            //    inventories = connection.Query<Inventory>(selectFromDatabase).AsList();

            //}
            //return inventories;
            
            InventoryService inventoryService = new InventoryService(new InventoryRepository());
            return inventoryService.Get(storename);

        }

        [HttpPost]
        [Route("api/shop/postinventories")]
        public void InsertInventories(string storename, string productname, int quantity, int unitcost)
        {
            //Inventory inventory = new Inventory(storename, productname, quantity, DateTime.Now, unitcost);

            //string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            //{
            //    string insertIntoInventory = $"INSERT INTO shop.inventory(storename, productname, quantity, date, unitcost)VALUES('{storename}', '{productname}', '{quantity}','{DateTime.Now}', '{unitcost}');";
            //    connection.Execute(insertIntoInventory);
            //}
            InventoryService inventoryService = new InventoryService(new InventoryRepository());
            inventoryService.Create(storename,productname,quantity,unitcost);

        }
        [HttpPut]
        [Route("api/shop/changequantity")]
        public void UpdateQuantity(string storename, string productname, string newquantity)
        {

            //string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            //{
            //    string updatequantity = $"UPDATE shop.inventory SET quantity ='{newquantity}' WHERE storename = '{storename}' and productname='{productname}';";
            //    connection.Execute(updatequantity);
            //}

            InventoryService inventoryService = new InventoryService(new InventoryRepository());
            inventoryService.Post(storename, productname, newquantity);
        }

        [HttpDelete]
        [Route("api/shop/deletearticle")]
        public void DeleteArticle(string storename, string article)
        {

            //string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            //{

            //    string deletestorefrominventories = $"DELETE FROM shop.inventory WHERE storename = '{storename}' and productname= '{article}';";
            //    connection.Execute(deletestorefrominventories);
            //}
            InventoryService inventoryService = new InventoryService(new InventoryRepository());
            inventoryService.Delete(storename, article);

        }
    }
}
