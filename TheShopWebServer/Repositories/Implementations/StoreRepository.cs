using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheShopWebServer.Repositories.Interfaces;

namespace TheShopWebServer.Repositories.Implementations
{
    public class StoreRepository : IStoreRepository
    {
        public List<Store> Select(string nameofcity) {
            List<Store> stores;
            string connectionStringcity = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStringcity))
            {
                string selectFromDatabase = $"SELECT nameofcity, storename, address FROM shop.stores WHERE nameofcity = '{nameofcity}'; ";
                stores = connection.Query<Store>(selectFromDatabase).AsList();

            }
            return stores;
            
        }
        public void Insert(string nameofcity, string storename, string address) {
            Store addNewStoreTemp = new Store(nameofcity, storename,address);


            string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string insertIntoStores = $"INSERT INTO shop.stores(nameofcity, storename, address)VALUES('{nameofcity}','{storename}','{address}');";
                connection.Execute(insertIntoStores);
            }
        }
        public void Update(string nameofcity, string storename, string address, string newaddress) {
            string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string updatestoreaddress = $"UPDATE shop.stores SET address = '{newaddress}' WHERE nameofcity='{nameofcity}' and storename='{storename}' and address='{address}';";
                connection.Execute(updatestoreaddress);
            }
        }
        public void Delete(string storename) {
            string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string deletestorefromstores = $"DELETE FROM shop.stores WHERE storename = '{storename}';";
                string deletestorefrominventories = $"DELETE FROM shop.inventory WHERE storename = '{storename}';";
                connection.Execute(deletestorefromstores);
                connection.Execute(deletestorefrominventories);
            }
        }
    }
}
