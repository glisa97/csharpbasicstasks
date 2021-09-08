using System;
using System.Collections.Generic;

namespace TheShop
{
    class Program
    {
        private static int totalPrice;

        static void Main(string[] args)
        {
            List<ItemValueRecord> ListShop1 = new List<ItemValueRecord>();

            ItemValueRecord milk = new ItemValueRecord("Milk",100,1, UnitOfMeasure.L);
            ItemValueRecord sugar = new ItemValueRecord("Sugar", 200,5, UnitOfMeasure.KG);
            ItemValueRecord eggs = new ItemValueRecord("Eggs", 300,3, UnitOfMeasure.PIECE);

            ListShop1.Add(milk);
            ListShop1.Add(sugar);
            ListShop1.Add(eggs);

            foreach (ItemValueRecord item in ListShop1) 
            {
                totalPrice += item.UnitPrice;
                Console.WriteLine(item.Name + "  Price:" + item.UnitPrice + "  Quantity:" + item.Quantity + "  Measure:" + item.Measure);   
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Sum of prices: " + totalPrice);

            RetrieveRecordFields(ListShop1);
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
                    Console.WriteLine(item.Name + "  Price:" + item.UnitPrice + "  Quantity:" + item.Quantity + "  Measure:" + item.Measure);
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
