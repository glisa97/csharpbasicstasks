using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    class Inventory : ItemValueRecord
    {
        public string StoreName { get; set; }
      
        public ItemValueRecord ItemValueRecord { get; set; }

        public Inventory(string storename, ItemValueRecord itemValueRecord)
        {
            StoreName = storename;
            ItemValueRecord = itemValueRecord;
            
        }
       
        public Inventory()
        {
            

        }


    }
}
