using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    class Inventory
    {
        public ItemValueRecord ItemValueRecord { get; set; }

        public Inventory(ItemValueRecord itemValueRecord)
        {
            ItemValueRecord = itemValueRecord;
        }
    }
}
