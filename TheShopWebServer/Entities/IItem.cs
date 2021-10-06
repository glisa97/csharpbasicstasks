using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TheShopWebServer
{
    public interface IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitCost { get; set; }

    }
}
