using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public interface IItem
    {
        public string Name { get; set; }
        public UnitOfMeasure Measure { get; set; }
        
    }
}
