using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Classes;
using WindowsFormsApplication1.Forms;

namespace WindowsFormsApplication1
{
    
    public partial class WelcomeForm : Form
    {
        public static WelcomeForm welcome;
        public static User user = Main.user1;
        public static Client client1;
        public int RoomKey = 0;
        public int ServiceKey = 0;
        public string RoomName = "";
        public string ServiceName = "";
        public int TotalPrice = 0;
        public List<Order> orders = new List<Order>();
        public WelcomeForm()
        {
            InitializeComponent();
            welcome = this;
            CashAccount.welcome = this;
            PersonalData.welcome = this;
            BookARoom.welcome = this;
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            checkedListBoxServices.Items.Clear();
            textBoxCash.Text = "0";

            using (UserContext db = new UserContext())
            {
                foreach (Client client in db.Clients)
                {
                    if (Main.user1.Id == client.userId)
                    {
                        client1 = client;
                    }
                }
                foreach (Order order1 in db.Orders)
                {
                    if (client1.id == order1.clientId)
                    {
                        orders.Add(order1);
                    }
                }
                
                foreach (Order order in orders)
                {
                    if (!order.isPaid)
                    {
                        RoomKey = order.roomId;
                        ServiceKey = order.serviceId;
                        TotalPrice = order.totalPrice;
                        foreach (Room room in db.Rooms)
                        {
                            if (RoomKey == room.id)
                            {
                                RoomName = room.category;
                            }
                        }
                        foreach (Service service in db.Services)
                        {
                            if (ServiceKey == service.id)
                            {
                                ServiceName = service.name;
                            }
                        }
                        checkedListBoxServices.Items.Add("Комната типа: " + RoomName + " с пакетом услуг " + ServiceName + ". Стоимость: " + Convert.ToString(TotalPrice));
                    }
                }
            }
        }

        private void WelcomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            //MessageBox.Show("Выберите один из вариантов","Сообщение",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
       
        private void buttonAddCash_Click(object sender, EventArgs e)
        {
            CashAccount CashAcc = new CashAccount();
            CashAcc.Show();
            welcome.Hide();
        }
        public bool IsCreated = false;
        private void buttonBookARoom_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Client client in db.Clients)
                {
                    if (user.Id == client.userId)
                    {
                        IsCreated = true;
                    }
                }
                if (!IsCreated)
                {
                    PersonalData pd = new PersonalData();
                    pd.Show();
                    welcome.Hide();
                }
                else
                {
                    MessageBox.Show("уже забито)");
                    BookARoom bookARoom = new BookARoom();
                    bookARoom.Show();
                    welcome.Hide();
                }
            }
        }
        public int totalPrice = 0;
        private void checkedListBoxServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            totalPrice = 0;
            foreach (Order order in orders)
            {
                
            }
        }

        private void buttonPayServices_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxCash.Text) > totalPrice)
            {
                textBoxCash.Text = Convert.ToString(Convert.ToInt32(textBoxCash.Text) - totalPrice);
            }
            else
            {
                MessageBox.Show("Пополните ваш счет", "Сообщение");
            }
        }
    }
}
