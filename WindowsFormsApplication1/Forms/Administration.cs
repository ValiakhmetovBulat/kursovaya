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
            radioButton4.Checked = true;
            radioButton9.Checked = true;
            radioButton12.Checked = true;
            radioButton15.Checked = true;
            radioButton18.Checked = true;
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
                    if (Main.user1.Id == client.userId)
                    {
                        UserLogin = Main.user1.Login;
                        comboBox2.Items.Add(UserLogin);
                    }
                }
                foreach (Room room in db.Rooms)
                {
                    comboBox3.Items.Add(room.category);
                }
                foreach (Service service in db.Services)
                {
                    comboBox4.Items.Add(service.name);
                }
                foreach(Staff staff in db.Staff)
                {
                    comboBox5.Items.Add(staff.surname + " " + staff.name + " " + staff.patr);
                }
                foreach(Position position in db.Positions)
                {
                    comboBox6.Items.Add(position.name);
                }
            }
        }
        public User item;
        public int count = 0;
        private void buttonChange_Click(object sender, EventArgs e)
        {

            
            using (UserContext db = new UserContext())
            {
                if (textBox1.Text != "")
                {                    
                    item = db.Users.Find(UserKey);
                    item.Login = textBox1.Text;
                }
                if (textBox2.Text != "")
                {
                    item = db.Users.Find(UserKey);
                    item.Password = GetHashString(textBox2.Text);
                }
                if (textBox3.Text != "")
                {
                    item = db.Users.Find(UserKey);
                    item.Email = textBox3.Text;
                }
                db.SaveChanges();

                foreach (User user in db.Users)
                {
                    if (user.Email == textBox3.Text)
                    {
                        count++;
                    }
                }

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
                    if (user.Login ==  comboBox1.SelectedItem.ToString())
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
                    if (UserLogin == comboBox2.SelectedItem.ToString())
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
