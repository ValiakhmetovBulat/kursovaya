using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1.Forms
{
    public partial class OrderHistory : Form
    {
        public bool needToOpenPreviousForm = true;
        int RoomKey, ServiceKey;
        string RoomName, ServiceName;
        public List<Order> orders = new List<Order>();
        public OrderHistory()
        {
            InitializeComponent();
        }

        private void buttonClearPaidOrders_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Order order in db.Orders)
                {
                    if (order.isPaid == true)
                    {
                        orders.Remove(order);
                        db.Orders.Remove(order);                     
                        
                    }
                }
                db.SaveChanges();
                OrderHistory orderHistory = new OrderHistory();
                orderHistory.Show();
                needToOpenPreviousForm = false;
                this.Close();
                needToOpenPreviousForm = true;
            }
        }

        private void buttonClearDeletedOrders_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Order order in db.Orders)
                {
                    if (order.isDeleted == true)
                    {
                        orders.Remove(order);
                        db.Orders.Remove(order);
                        
                    }
                }
                db.SaveChanges();
                OrderHistory orderHistory = new OrderHistory();
                orderHistory.Show();
                needToOpenPreviousForm = false;
                this.Close();
                needToOpenPreviousForm = true;
            }
        }

        private void OrderHistory_Load(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Order order1 in db.Orders)
                {
                    if (WelcomeForm.client1.id == order1.clientId)
                    {
                        orders.Add(order1);
                    }
                }
                foreach (Order order in orders)
                {
                    if (order.clientId == WelcomeForm.client1.id)
                    {
                        if (order.isPaid)
                        {
                            RoomKey = order.roomId;
                            ServiceKey = order.serviceId;                            
                            RoomName = db.Rooms.Find(RoomKey).category;
                            ServiceName = db.Services.Find(ServiceKey).name;  
                            
                            richTextBoxPaidOrders.Text += "[" + order.id + "] Комната типа: " + RoomName + " с пакетом услуг " + ServiceName + ". Стоимость: " + Convert.ToString(order.totalPrice) + "\n";
                        }
                        else if (order.isDeleted)
                        {
                            RoomKey = order.roomId;
                            ServiceKey = order.serviceId;
                            RoomName = db.Rooms.Find(RoomKey).category;
                            ServiceName = db.Services.Find(ServiceKey).name;
                            richTextBoxDeletedOrders.Text += "[" + order.id + "] Комната типа: " + RoomName + " с пакетом услуг " + ServiceName + ". Стоимость: " + Convert.ToString(order.totalPrice) + "\n";
                        }
                    }
                }
            }
        }

        private void OrderHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needToOpenPreviousForm)
            {
                orders.Clear();
                WelcomeForm welcome = new WelcomeForm();
                welcome.Show();
            }
        }
    }
}
