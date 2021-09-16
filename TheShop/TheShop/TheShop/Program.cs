using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TheShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Store> ListOfStores = new List<Store>();
            List<Inventory> ListOfInventories = new List<Inventory>();

            
            SelectStores();
            SelectInventory();
            

            Console.WriteLine("------------------");
            Console.WriteLine("ADD NEW STORE");
            Console.WriteLine("------------------");
            Console.WriteLine("Enter city where store is located:");
            string nameofCity = Console.ReadLine();
            Console.WriteLine("Enter name of store:");
            string nameOfStore = Console.ReadLine();
            Console.WriteLine("Enter address of store:");
            string storeAddress = Console.ReadLine();
            

            Store storeAddedByUser = new Store(nameofCity, nameOfStore, storeAddress);
            ListOfStores.Add(storeAddedByUser);

            foreach (Store s in ListOfStores)
            {
                string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    string insertIntoStores = $"INSERT INTO shop.stores(nameofcity, storename, address)VALUES('{s.NameOfCity}','{s.StoreName}','{s.Address}');";
                    connection.Execute(insertIntoStores);
                }
            }
            Console.WriteLine("------------------");
            Console.WriteLine("STORE ADDED!");
            Console.WriteLine("------------------");


            Console.WriteLine("------------------");
            Console.WriteLine("ADD INVENTORY");
            Console.WriteLine("------------------");
            Console.WriteLine("Enter store name:");
            string storename = Console.ReadLine();
            Console.WriteLine("Enter product name:");
            string productname = Console.ReadLine();
            Console.WriteLine("Enter quantity of product:");
            string quantity = Console.ReadLine();

            ItemValueRecord itemOfInventory = new ItemValueRecord(productname, Int32.Parse(quantity));
            Inventory inventory = new Inventory(storename, itemOfInventory);
            ListOfInventories.Add(inventory);

            foreach (Inventory i in ListOfInventories)
            {
                string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    string insertIntoInventory = $"INSERT INTO shop.inventory(storename, productname, quantity)VALUES('{i.StoreName}', '{i.ItemValueRecord.Name}','{i.ItemValueRecord.Quantity}'); ";
                    connection.Execute(insertIntoInventory);
                }
            }
            Console.WriteLine("------------------");
            Console.WriteLine("INVENTORY ADDED!");
            Console.WriteLine("------------------");

            

           
        
    }
        private static void SelectStores()
        {

            Console.WriteLine("Enter name of city to search stores in database:");
            string cityname = Console.ReadLine();


            string connectionStringcity = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStringcity))
            {
                string selectFromDatabase = $"SELECT nameofcity, storename, address FROM shop.stores WHERE nameofcity = '{cityname}'; ";
                List<Store> stores = connection.Query<Store>(selectFromDatabase).AsList();
                foreach (Store s in stores)
                {
                    Console.Write(s.NameOfCity + ",");
                    Console.Write(s.StoreName + ",");
                    Console.Write(s.Address + "\n");
                }

            }
            
        }
        private static void SelectInventory()
        {

            Console.WriteLine("Enter store name to search inventory for that store in database:");
            string storenameForSearch = Console.ReadLine();


            string connectionStringInv = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStringInv))
            {
                string selectFromDatabase = $"SELECT storename, productname, quantity FROM shop.inventory WHERE storename = '{storenameForSearch}'; ";

                IEnumerable<Inventory> inventoryList = connection.Query<Inventory>(selectFromDatabase);
                foreach (Inventory i in inventoryList)
                {
                    Console.Write(i.StoreName + ",");
                    Console.Write(i.Name + ",");
                    Console.Write(i.Quantity + "\n");
                }

            }

        }
    }
}
