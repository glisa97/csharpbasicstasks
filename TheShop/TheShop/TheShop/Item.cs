using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public abstract class Item : IItem
    {
        public string Name { get; set; }
        public UnitOfMeasure Measure { get; set; }

        public Item(string name,UnitOfMeasure measure)
        {
            Name = name;
            Measure = measure;
            
        }

    }
}
