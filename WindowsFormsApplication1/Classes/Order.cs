using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Order
    {
        public int id { get; set; }
        public DateTime dateOfArriving { get; set; }
        public DateTime dateOfLeaving { get; set; }
        public int clientId { get; set; }
        public int roomId { get; set; }
        public int serviceId { get; set; }
        public int totalPrice { get; set; }
        public bool isPaid { get; set; }
        public Order() { }
        public Order (DateTime dateOfArriving, DateTime dateOfLiving, int clientId, int roomId, int serviceId, int totalPrice, bool isPaid)
        {
            this.dateOfArriving = dateOfArriving;
            this.dateOfLeaving = dateOfLiving;
            this.clientId = clientId;
            this.roomId = roomId;
            this.serviceId = serviceId;
            this.totalPrice = totalPrice;
            this.isPaid = isPaid;
        }
    }
}
