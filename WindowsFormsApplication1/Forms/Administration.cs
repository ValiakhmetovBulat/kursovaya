using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net;
using System.Net.Mail;
using WindowsFormsApplication1.Classes;

namespace WindowsFormsApplication1
{
    public partial class Administration : Form
    {
        public int UserKey;
        public int ClientKey;
        public int RoomKey;
        public int ServiceKey;
        public int StaffKey;
        public int PositionKey;
        public string UserLogin = "";
        public Administration()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            comboBox1.KeyPress += (sender, e) => e.Handled = true;
            comboBox2.KeyPress += (sender, e) => e.Handled = true;
            comboBox3.KeyPress += (sender, e) => e.Handled = true;
            comboBox4.KeyPress += (sender, e) => e.Handled = true;
            comboBox5.KeyPress += (sender, e) => e.Handled = true;
            comboBox6.KeyPress += (sender, e) => e.Handled = true;
        }

        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }
        public User user1;
        private void Administration_Load(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (User user in db.Users)
                {
                    comboBox1.Items.Add(user.Login);
                }
                foreach (Client client in db.Clients)
                {
                    user1 = db.Users.Find(client.userId);
                    comboBox2.Items.Add(user1.Login);                    
                }
                foreach (Room room in db.Rooms)
                {
                    comboBox3.Items.Add(room.category);
                }
                foreach (Service service in db.Services)
                {
                    comboBox4.Items.Add(service.name);
                }
                foreach (Staff staff in db.Staff)
                {
                    comboBox5.Items.Add(staff.surname + " " + staff.name + " " + staff.patr);
                }
                foreach (Position position in db.Positions)
                {
                    comboBox6.Items.Add(position.name);
                }
            }
        }
        public User itemUser;
        public Client itemClient;
        public Room itemRoom;
        public Service itemService;
        public Staff itemStaff;
        public Position itemPosition;
        public int count = 0;
        private void buttonChange_Click(object sender, EventArgs e)
        {
                using (UserContext db = new UserContext())
                {
                    /// USER
                    if (textBox1.Text != "")
                    {
                        itemUser = db.Users.Find(UserKey);
                        itemUser.Login = textBox1.Text;
                    }
                    if (textBox2.Text != "")
                    {
                        itemUser = db.Users.Find(UserKey);
                        itemUser.Password = GetHashString(textBox2.Text);
                    }
                    if (textBox3.Text != "")
                    {
                        itemUser = db.Users.Find(UserKey);
                        itemUser.Email = textBox3.Text;
                    }
                    //// CLIENT
                    if (textBox4.Text != "")
                    {
                        itemClient = db.Clients.Find(ClientKey);
                        itemClient.surname = textBox4.Text;
                    }
                    if (textBox5.Text != "")
                    {
                        itemClient = db.Clients.Find(ClientKey);
                        itemClient.name = textBox5.Text;
                    }
                    if (textBox6.Text != "")
                    {
                        itemClient = db.Clients.Find(ClientKey);
                        itemClient.patr = textBox6.Text;
                    }
                    if (textBox7.Text != "")
                    {
                        itemClient = db.Clients.Find(ClientKey);
                        itemClient.p_series = Convert.ToInt32(textBox7.Text);
                    }
                    if (textBox8.Text != "")
                    {
                        itemClient = db.Clients.Find(ClientKey);
                        itemClient.p_number = Convert.ToInt32(textBox8.Text);
                    }
                    if (textBox9.Text != "")
                    {
                        itemClient = db.Clients.Find(ClientKey);
                        itemClient.phone = textBox9.Text;
                    }
                    if (dateTimePicker1.Value != null)
                    {
                        itemClient = db.Clients.Find(ClientKey);
                        itemClient.date_of_birth = dateTimePicker1.Value;
                    }
                    /// ROOM
                    if (textBox10.Text != "")
                    {
                        itemRoom = db.Rooms.Find(RoomKey);
                        itemRoom.category = textBox10.Text;
                    }
                    if (textBox11.Text != "")
                    {
                        itemRoom = db.Rooms.Find(RoomKey);
                        itemRoom.price= Convert.ToInt32(textBox11.Text);
                    }
                    /// SERVICE
                    if (textBox12.Text != "")
                    {
                        itemService = db.Services.Find(ServiceKey);
                        itemService.name = textBox12.Text;
                    }
                    if (textBox13.Text != "")
                    {
                        itemService = db.Services.Find(ServiceKey);
                        itemService.price = Convert.ToInt32(textBox13.Text);
                    }
                    if(richTextBox1.Text != "")
                    {
                        itemService = db.Services.Find(ServiceKey);
                        itemService.description = richTextBox1.Text;
                    }
                    /// STAFF
                    /// нулевой потому что там есть проблемы который я не хочу изменять(слишком лень и долго да и у меня не получится enable-migrations не работает...)
                    /// Position
                    if (textBox21.Text != "")
                    {
                        itemPosition = db.Positions.Find(PositionKey);
                        itemPosition.name = textBox21.Text;
                    }
                    if (textBox22.Text != "")
                    {
                        itemPosition = db.Positions.Find(PositionKey);
                        itemPosition.salary = Convert.ToInt32(textBox22.Text);
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Ошибка", "Сообщение");
            }
            //foreach (User user in db.Users)
            //{
            //    if (user.Email == textBox3.Text)
            //    {
            //        count++;
            //    }
            //}

            //if (count == 0)
            //{
            //    
            //    MailAddress from = new MailAddress("ii.oio.ooo@mail.ru", "kriper2004");
            //    MailAddress to = new MailAddress(textBox3.Text);
            //    MailMessage m = new MailMessage(from, to);
            //    m.Subject = "Смена данных";

            //    m.Body = "<h1>Здравствуйте, " + item.Login + ".Ваши данные были изменены. Ваши California Hotels</h1>";
            //    m.IsBodyHtml = true;
            //    SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            //    smtp.Credentials = new NetworkCredential("ii.oio.ooo@mail.ru", "MaximovRomanSergeevich");
            //    smtp.EnableSsl = true;
            //    smtp.Send(m);
            //    count = 0;
            //}

            //else
            //{
            //    MessageBox.Show("Пользователь с данной почтой уже существует");
            //}

        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
                using (UserContext db = new UserContext())
                {
                    if(comboBox1.SelectedItem != null)
                    {
                        foreach (User user in db.Users)
                        {
                            if (user.Login == comboBox1.SelectedItem.ToString())
                            {
                                db.Users.Remove(user);
                            }
                        }
                    }
                    if(comboBox2.SelectedItem != null)
                    {
                        foreach (Client client in db.Clients)
                        {
                            if (UserLogin == comboBox2.SelectedItem.ToString())
                            {
                                db.Clients.Remove(client);
                            }
                        }
                    }
                    if(comboBox3.SelectedItem != null)
                    {
                        foreach (Room room in db.Rooms)
                        {
                            if (room.category == comboBox3.SelectedItem.ToString())
                            {
                                db.Rooms.Remove(room);
                            }
                        }
                    }
                    if(comboBox4.SelectedItem != null)
                    {
                        foreach (Service service in db.Services)
                        {
                            if (service.name == comboBox4.SelectedItem.ToString())
                            {
                                db.Services.Remove(service);
                            }
                        }
                    }
                    if(comboBox6.SelectedItem != null)
                    {
                        foreach (Position position in db.Positions)
                        {
                            if (position.name == comboBox6.SelectedItem.ToString())
                            {
                                db.Positions.Remove(position);
                            }
                        }
                    }
                    
                    db.SaveChanges();
                }
                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
                comboBox3.SelectedItem = null;
                comboBox4.SelectedItem = null;
                comboBox5.SelectedItem = null;
                comboBox6.SelectedItem = null;
        }
        private void Administration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main.main.Show();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (User user in db.Users)
                {
                    if (user.Login == comboBox1.SelectedItem.ToString())
                    {
                        UserKey = user.Id;
                        textBox1.Text = user.Login;
                        textBox2.Text = user.Password;
                        textBox3.Text = user.Email;
                    }
                }
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Client client in db.Clients)
                {
                    if (user1.Login == comboBox2.SelectedItem.ToString())
                    {
                        ClientKey = client.id;
                        textBox4.Text = client.surname;
                        textBox5.Text = client.name;
                        textBox6.Text = client.patr;
                        textBox7.Text = Convert.ToString(client.p_series);
                        textBox8.Text = Convert.ToString(client.p_number);
                        textBox9.Text = client.phone;
                        dateTimePicker1.Value = client.date_of_birth;
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Room room in db.Rooms)
                {
                    if (room.category == comboBox3.SelectedItem.ToString())
                    {
                        RoomKey = room.id;
                        textBox10.Text = room.category;
                        textBox11.Text = Convert.ToString(room.price);
                    }
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Service service in db.Services)
                {
                    if (service.name == comboBox4.SelectedItem.ToString())
                    {
                        ServiceKey = service.id;
                        textBox12.Text = service.name;
                        textBox13.Text = Convert.ToString(service.price);
                    }
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //using (UserContext db = new UserContext())
            //{
            //    foreach (Client client in db.Clients)
            //    {
            //        if (UserLogin == comboBox5.SelectedItem.ToString())
            //        {
            //            ClientKey = client.id;
            //            textBox4.Text = client.surname;
            //            textBox5.Text = client.name;
            //            textBox6.Text = client.patr;
            //            textBox7.Text = Convert.ToString(client.p_series);
            //            textBox8.Text = Convert.ToString(client.p_number);
            //            textBox9.Text = client.phone;
            //            dateTimePicker1.Value = client.date_of_birth;
            //        }
            //    }
            //}
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Position position in db.Positions)
                {
                    if (position.name == comboBox6.SelectedItem.ToString())
                    {
                        PositionKey = position.id;
                        textBox21.Text = position.name;
                        textBox22.Text = Convert.ToString(position.salary);
                    }
                }
            }
        }

        
    }
}
