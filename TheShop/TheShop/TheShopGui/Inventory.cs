using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShopGui
{
    class Inventory
    {
        public string StoreName;
        public ItemValueRecord ItemValueRecord { get; set; }

        public Inventory(string storename,ItemValueRecord itemValueRecord)
        {
            StoreName = storename;
            ItemValueRecord = itemValueRecord;
        }
        
    }
}
