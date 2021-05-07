using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Service
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public Service() { }
        public Service(string name, int price, string description)
        {
            this.name = name;
            this.price = price;
            this.description = description;
        }
    }
}
