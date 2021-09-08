using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TheShop
{
    public class Program
    {
        private static int totalPrice;

        static void Main(string[] args)
        {
            List<ItemValueRecord> ListShop1 = new List<ItemValueRecord>();

            ItemValueRecord milk = new ItemValueRecord(1,"Milk","100 din",1, UnitOfMeasure.L.ToString());
            ItemValueRecord sugar = new ItemValueRecord(2,"Sugar", "200 din",5, UnitOfMeasure.KG.ToString());
            ItemValueRecord eggs = new ItemValueRecord(3,"Eggs", "300 din",3, UnitOfMeasure.PIECE.ToString());

            ListShop1.Add(milk);
            ListShop1.Add(sugar);
            ListShop1.Add(eggs);
            int id = 1;

            foreach (ItemValueRecord item in ListShop1) 
            {
                
                totalPrice += Convert.ToInt32(item.UnitCost.Split(' ').First());
                Console.WriteLine(item.Name + "  Price:" + item.UnitCost + "  Quantity:" + item.Quantity);

                string connectionString = "Server=127.0.0.1;Port=5432;Database=shopdb;User Id=postgres;Password=postgres;";
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    string selectProductByName = $"SELECT * FROM shop.product where name = '{item.Name}'";
                    ItemValueRecord itemValueRecord = connection.Query<ItemValueRecord>(selectProductByName).Single();

                    itemValueRecord.Quantity = item.Quantity;
                    itemValueRecord.Date = DateTime.Today.ToString("yyyy-MM-dd");

                    string insertrecordInInventory = $"INSERT INTO shop.inventory(id, productid, amount, date)VALUES ({id}, {itemValueRecord.Id}, {itemValueRecord.Quantity}, '{itemValueRecord.Date}');";
                    connection.Execute(insertrecordInInventory);
                    id++;
                }
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Sum of prices: " + totalPrice);

            RetrieveRecordFields(ListShop1);

            

        }


        public static void RetrieveRecordFields(List<ItemValueRecord> list)
        {
            Console.WriteLine("Retrieve item by name:");
            string chosenItemName = Console.ReadLine();
            foreach (ItemValueRecord item in list)
            {
                if (item.Name == chosenItemName)
                {
                    Console.WriteLine(item.Name + "  Price:" + item.UnitCost + "  Quantity:" + item.Quantity);
                }
            }
        }
        //public static void ChangeTheQuantity(List<ItemValueRecord> list)
        //{
        //    Console.WriteLine("Retrieve item by name:");
        //    string chosenItemName = Console.ReadLine();
        //    foreach (ItemValueRecord item in list)
        //    {
        //        if (item.Name == chosenItemName)
        //        {
        //            Console.WriteLine(item.Name + "  Price:" + item.UnitPrice + "  Quantity:" + item.Quantity + "  Measure:" + item.Measure);
        //        }
        //    }
        //}
    }
}
