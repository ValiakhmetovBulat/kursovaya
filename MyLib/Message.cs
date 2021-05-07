using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    [Serializable]
    public class Message
    {
    public byte[] Data { get; set; }
    }
    [Serializable]
    public class ComplexMessage
    {
        public Message First { get; set; }
        public Message Second { get; set; }
        public int NumberStatus { get; set; }
    }
}
