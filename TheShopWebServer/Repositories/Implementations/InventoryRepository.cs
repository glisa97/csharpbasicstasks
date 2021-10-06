using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using TheShopWebServer.Repositories.Interfaces;

namespace TheShopWebServer.Repositories.Implementations
{
    public class InventoryRepository : IInventoryRepository
    {
        public void Get(string nameofcity)
        {
            List<Inventory> inventories;
            string connectionStringInv = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStringInv))
            {
                string selectFromDatabase = $"SELECT storename, productname, quantity, date, unitcost FROM shop.inventory WHERE storename = '{nameofcity}'; ";
                inventories = connection.Query<Inventory>(selectFromDatabase).AsList();

            }

        }
        public void Post(string storename, string productname, int quantity, int unitcost)
        {
            Inventory inventory = new Inventory(storename, productname, quantity, DateTime.Now, unitcost);

            string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string insertIntoInventory = $"INSERT INTO shop.inventory(storename, productname, quantity, date, unitcost)VALUES('{storename}', '{productname}', '{quantity}','{DateTime.Now}', '{unitcost}');";
                connection.Execute(insertIntoInventory);
            }
        }
        public void Put(string storename, string productname, string newquantity)
        {
            string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string updatequantity = $"UPDATE shop.inventory SET quantity ='{newquantity}' WHERE storename = '{storename}' and productname='{productname}';";
                connection.Execute(updatequantity);
            }
        }
        public void Delete(string storename, string article)
        {
            string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {

                string deletestorefrominventories = $"DELETE FROM shop.inventory WHERE storename = '{storename}' and productname= '{article}';";
                connection.Execute(deletestorefrominventories);
            }
        }
    }
}
