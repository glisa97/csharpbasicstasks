using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShopWebServer
{
    public class Inventory 
    {
        public string StoreName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime? Date { get; set; }
        public string UnitCost { get; set; }


        public Inventory(string storename, string productname,int quantity, DateTime date, string unitCost)
        {
            StoreName = storename;
            ProductName = productname;
            Date = date;
            UnitCost = unitCost;
        }

        public Inventory()
        {


        }


    }
}
