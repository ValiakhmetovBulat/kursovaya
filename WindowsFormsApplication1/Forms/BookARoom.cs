using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Classes
{
    public partial class BookARoom : Form
    {
        public static BookARoom bookARoom;
        public static WelcomeForm welcome;
        public int RoomKey = 0;
        public int ClientKey = 0;
        public int ServiceKey = 0;
        public int price1 = 0;
        public int price2 = 0;
        public int price = 0;
        public BookARoom()
        {
            InitializeComponent();
            bookARoom = this;
        }

        private void BookARoom_Load(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach(Room room in db.Rooms)
                {
                    comboBoxRooms.Items.Add(room.category);
                }
                foreach(Service service in db.Services)
                {
                    comboBoxServices.Items.Add(service.name);
                }
            }
            textBoxTotalPrice.Text = "0"; 
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Client client in db.Clients)
                {
                    if (Main.user1.Id == client.userId)
                    {
                        ClientKey = client.id;
                    }
                }
                if (comboBoxRooms.SelectedItem != null || comboBoxServices.SelectedItem != null)
                {
                    Order order = new Order(dateOfArriving.Value, dateOfLeaving.Value, ClientKey, RoomKey, ServiceKey, Convert.ToInt32(textBoxTotalPrice.Text), false);
                    db.Orders.Add(order);
                    db.SaveChanges();
                    welcome.Show();
                    bookARoom.Hide();
                }
                else
                {
                    MessageBox.Show("Неккоректный ввод", "Сообщение");
                }
                
            }
        }

        private void comboBoxRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Room room in db.Rooms)
                {
                    if (room.category == comboBoxRooms.SelectedItem.ToString())
                    {
                        RoomKey = room.id;
                        textBoxPriceOfRooms.Text = Convert.ToString(room.price);
                        price1 = Convert.ToInt32(room.price);
                    }                    
                }
            }
            textBoxTotalPrice.Text = Convert.ToString(price1 + price2);

        }

        private void comboBoxServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Service service in db.Services)
                {
                    if (service.name == comboBoxServices.SelectedItem.ToString())
                    {
                        ServiceKey = service.id;
                        richTextBoxPriceOfServices.Text = "Стоимость: \n" + Convert.ToString(service.price) + "\nОписание:\n " + service.description;
                        price2 = Convert.ToInt32(service.price);
                    }
                }
            }
            textBoxTotalPrice.Text = Convert.ToString(price1 + price2);
        }

        private void BookARoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            welcome.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
