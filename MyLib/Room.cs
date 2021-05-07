using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Room
    {
        public int id { get; set; }
        public string category { get; set; }
        public int price { get; set; }
        public Room() { }
        public Room(string category, int price)
        {
            this.category = category;
            this.price = price;
        }
    }
}
