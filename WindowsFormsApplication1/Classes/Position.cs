using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes
{
    public class Position
    {
        public int id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public Position () { }
        public Position(string name, int salary)
        {
            this.name = name;
            this.salary = salary;
        }
    }
}
