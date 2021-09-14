using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShopGui
{
    class City
    {
        public string Name { get; set; }

        public List<Store> Stores = new List<Store>();
        public City(string name, List<Store> stores)
        {
            Name = name;
            Stores = stores;
        }
    }
}
