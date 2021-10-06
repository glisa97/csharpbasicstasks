using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShopWebServer
{
    public class ItemValueRecord : Item
    {

        public int Quantity { get; set; }
        public string Date { get; set; }

        public ItemValueRecord(int id, string name, string unitCost) : base(id, name, unitCost)
        {

        }
        public ItemValueRecord(int id, string name, string unitCost, int quantity, string measure) : base(id, name, measure)
        {

            UnitCost = unitCost;
            Quantity = quantity;


        }
        public ItemValueRecord(string name, int quantity) : base(name)
        {
            Name = name;
            Quantity = quantity;

        }

        public ItemValueRecord()
        {


        }

    }
}
