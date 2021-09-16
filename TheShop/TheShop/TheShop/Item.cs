using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public abstract class Item : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitCost { get; set; }

        public Item(int id, string name,string unitcost)
        {
            Id = id;
            Name = name;
            UnitCost = unitcost;
        }
        public Item(string name)
        {

            Name = name;

        }

        public Item()
        {


        }
    }
}
