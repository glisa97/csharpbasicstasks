using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShopGui
{
    class Store
    {
        public string NameOfCity { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public Inventory Inventory { get; set; }

        public Store(string nameOfCity, string storeName, string address, Inventory inventory)
        {
            NameOfCity = nameOfCity;
            StoreName = storeName;
            Address = address;
            Inventory = inventory;
        }
        public Store(string nameOfCity, string storeName, string address)
        {
            NameOfCity = nameOfCity;
            StoreName = storeName;
            Address = address;
            
        }
    }
}
