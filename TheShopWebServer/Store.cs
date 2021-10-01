using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TheShopWebServer
{
    public class Store
    {
        public string NameOfCity { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        

        public Store(string nameOfCity, string storeName, string address)
        {
            NameOfCity = nameOfCity;
            StoreName = storeName;
            Address = address;
            
        }
        
    }
}
