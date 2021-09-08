using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public class ItemValueRecord : Item
    {
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public ItemValueRecord(string name,int unitPrice, int quantity, UnitOfMeasure measure) :base(name,measure)
        {
            
            UnitPrice = unitPrice;
            Quantity = quantity;
            

        }
        
    }
}
