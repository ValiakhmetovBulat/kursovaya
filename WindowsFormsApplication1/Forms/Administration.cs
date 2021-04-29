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
            comboBox7.KeyPress += (sender, e) => e.Handled = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox13.Enabled = false;
            textBox14.Enabled = false;
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            textBox17.Enabled = false;
            textBox18.Enabled = false;
            textBox19.Enabled = false;
            comboBox7.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            buttonDelete.Enabled = false;
            buttonChange.Enabled = false;
            buttonAdd.Enabled = false;

            textBoxUserClient.Visible = false;
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
                    comboBox5.Items.Add(staff.name);
                }
                foreach (Position position in db.Positions)
                {
                    comboBox6.Items.Add(position.name);
                    comboBox7.Items.Add(position.name);
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
                if (comboBox1.SelectedItem != null && tabControl1.SelectedTab == tabControl1.TabPages[0])
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
                }
                if (comboBox2.SelectedItem != null && tabControl1.SelectedTab == tabControl1.TabPages[1])
                {
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
                }
                if (comboBox3.SelectedItem != null && tabControl1.SelectedTab == tabControl1.TabPages[2])
                {
                    /// ROOM
                    if (textBox10.Text != "")
                    {
                        itemRoom = db.Rooms.Find(RoomKey);
                        itemRoom.category = textBox10.Text;
                    }
                    if (textBox11.Text != "")
                    {
                        itemRoom = db.Rooms.Find(RoomKey);
                        itemRoom.price = Convert.ToInt32(textBox11.Text);
                    }
                }
                if (comboBox4.SelectedItem != null && tabControl1.SelectedTab == tabControl1.TabPages[3])
                {
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
                    if (richTextBox1.Text != "")
                    {
                        itemService = db.Services.Find(ServiceKey);
                        itemService.description = richTextBox1.Text;
                    }
                }
                if (comboBox5.SelectedItem != null && tabControl1.SelectedTab == tabControl1.TabPages[4])
                {
                    /// STAFF
                    if (textBox14.Text != "")
                    {
                        itemStaff = db.Staff.Find(StaffKey);
                        itemStaff.phone = textBox14.Text;
                    }
                    if (textBox15.Text != "")
                    {
                        itemStaff = db.Staff.Find(StaffKey);
                        itemStaff.p_number = Convert.ToInt32(textBox15.Text);
                    }
                    if (textBox16.Text != "")
                    {
                        itemStaff = db.Staff.Find(StaffKey);
                        itemStaff.p_series = Convert.ToInt32(textBox15.Text);
                    }
                    if (textBox17.Text != "")
                    {
                        itemStaff = db.Staff.Find(StaffKey);
                        itemStaff.patr = textBox17.Text;
                    }
                    if (textBox18.Text != "")
                    {
                        itemStaff = db.Staff.Find(StaffKey);
                        itemStaff.name = textBox18.Text;
                    }
                    if (textBox19.Text != "")
                    {
                        itemStaff = db.Staff.Find(StaffKey);
                        itemStaff.surname = textBox19.Text;
                    }
                    //if (textBox20.Text != "")
                    //{
                    //    itemStaff = db.Staff.Find(StaffKey);
                    //    itemStaff.positionId = textBox15.Text;
                    //}
                    if (comboBox7.SelectedItem != null)
                    {
                        foreach(Position position in db.Positions)
                        {
                            if (position.name == comboBox7.Text)
                            {
                                itemStaff.positionId = position.id;
                                break;
                            }
                        }
                    }
                }


                if (comboBox6.SelectedItem != null && tabControl1.SelectedTab == tabControl1.TabPages[5])
                {
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
                }
                    
                    db.SaveChanges();
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
                if(comboBox1.SelectedItem != null && tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    foreach (User user in db.Users)
                    {
                        if (user.Login == comboBox1.SelectedItem.ToString())
                        {
                            db.Users.Remove(user);
                            _formRefresh(0);
                            break;
                        }
                    }
                }
                if (comboBox2.SelectedItem != null && tabControl1.SelectedTab == tabControl1.TabPages[1])
                {
                    foreach (User user in db.Users)
                    {
                        if (user.Login == comboBox2.SelectedItem.ToString())
                        {
                            user1 = user;
                        } 
                    }

                    foreach (Client client in db.Clients)
                    {
                        

                        if (user1.Login == comboBox2.SelectedItem.ToString())
                        {
                            db.Clients.Remove(client);
                            
                            _formRefresh(1);
                            break;
                        }
                    }

                    //if (comboBox7.SelectedItem != null)
                    //{
                    //    foreach (Position position in db.Positions)
                    //    {
                    //        if (position.name == comboBox7.Text)
                    //        {
                    //            itemStaff.positionId = position.id;
                    //            break;
                    //        }
                    //    }
                    //}

                }
                if (comboBox3.SelectedItem != null && tabControl1.SelectedTab == tabControl1.TabPages[2])
                {
                    foreach (Room room in db.Rooms)
                    {
                        if (room.category == comboBox3.SelectedItem.ToString())
                        {
                            db.Rooms.Remove(room);
                            _formRefresh(2);
                            break;
                        }
                    }
                }
                if (comboBox4.SelectedItem != null && tabControl1.SelectedTab == tabControl1.TabPages[3])
                {
                    foreach (Service service in db.Services)
                    {
                        if (service.name == comboBox4.SelectedItem.ToString())
                        {
                            db.Services.Remove(service);
                            _formRefresh(3);
                            break;
                        }
                    }
                }
                if (comboBox5.SelectedItem != null && tabControl1.SelectedTab == tabControl1.TabPages[4])
                {
                    foreach (Staff staff in db.Staff)
                    {
                        if (staff.name == comboBox5.SelectedItem.ToString())
                        {
                            db.Staff.Remove(staff);
                            comboBox5.Items.Clear();
                            comboBox5.SelectedItem = null;
                            _formRefresh(4);
                            break;
                        }
                    }
                }
                if (comboBox6.SelectedItem != null && tabControl1.SelectedTab == tabControl1.TabPages[5])
                {
                    foreach (Position position in db.Positions)
                    {
                        if (position.name == comboBox6.SelectedItem.ToString())
                        {
                            db.Positions.Remove(position);
                            _formRefresh(5);                       
                            break;
                        }
                    }
                }
                   
                    db.SaveChanges();
                }
                //comboBox1.SelectedItem = null;
                //comboBox2.SelectedItem = null;
                //comboBox3.SelectedItem = null;
                //comboBox4.SelectedItem = null;
                //comboBox5.SelectedItem = null;
                //comboBox6.SelectedItem = null;
        }
        private void Administration_FormClosed(object sender, FormClosedEventArgs e)
        {
            
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
                        richTextBox1.Text = service.description;
                    }                  
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (Staff staff in db.Staff)
                {
                    if (staff.name == comboBox5.SelectedItem.ToString())
                    {
                        StaffKey = staff.id;
                        textBox14.Text = staff.phone;
                        textBox15.Text = Convert.ToString(staff.p_number);
                        textBox16.Text = Convert.ToString(staff.p_series);
                        textBox17.Text = staff.patr;
                        textBox18.Text = staff.name;
                        textBox19.Text = staff.surname;
                        //var item = db.Positions.Find(staff.positionId);
                        //comboBox7.Text = item.name;
                        dateTimePicker2.Value = staff.date_of_birth;
                    }
                }
            }
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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = true;
            buttonChange.Enabled = false;
            buttonAdd.Enabled = false;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox13.Enabled = false;
            textBox14.Enabled = false;
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            textBox17.Enabled = false;
            textBox18.Enabled = false;
            textBox19.Enabled = false;
            comboBox7.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = false;
            buttonChange.Enabled = false;
            buttonAdd.Enabled = false;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox13.Enabled = false;
            textBox14.Enabled = false;
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            textBox17.Enabled = false;
            textBox18.Enabled = false;
            textBox19.Enabled = false;
            comboBox7.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = false;
            buttonAdd.Enabled = false;
            buttonChange.Enabled = true;

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            textBox13.Enabled = true;
            textBox14.Enabled = true;
            textBox15.Enabled = true;
            textBox16.Enabled = true;
            textBox17.Enabled = true;
            textBox18.Enabled = true;
            textBox19.Enabled = true;
            comboBox7.Enabled = false;
            textBox21.Enabled = true;
            textBox22.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }

        private void _formRefresh(int page = 0)
        {
            Administration administration = new Administration();
            administration.Show();
            administration.tabControl1.SelectedIndex = page;
            this.Close();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            _formRefresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main.main.Show();
        }

        private void Administration_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        public bool UserIsCreated = false;
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages[0] && textBox1.Text != null && textBox2.Text != null && textBox3.Text != null)
                {
                    User user = new User(textBox1.Text, GetHashString(textBox2.Text), textBox3.Text, "User", 0);
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages[1] && textBox4.Text != null && textBox5.Text != null
                    && textBox6.Text != null && textBox7.Text != null && textBox8.Text != null && textBox9.Text != null
                    && dateTimePicker1 != null && textBoxUserClient.Text != null)
                {
                    foreach(User user in db.Users)
                    {
                        if(textBoxUserClient.Text == user.Login)
                        {
                            UserIsCreated = true;
                            UserKey = user.Id;
                        }
                    }
                    if(!UserIsCreated)
                    {
                        MessageBox.Show("Данного пользователя не существует", "Сообщение");
                    }
                    else
                    {
                        Client client = new Client(textBox4.Text, textBox5.Text, textBox6.Text, dateTimePicker1.Value, 
                            Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text),textBox9.Text, UserKey);
                        db.Clients.Add(client);
                        db.SaveChanges();
                    }
                }
                if (tabControl1.SelectedTab == tabControl1.TabPages[2] && textBox10.Text != null && textBox11.Text != null)
                {
                    Room room = new Room(textBox10.Text,Convert.ToInt32(textBox11.Text));
                    db.Rooms.Add(room);
                    db.SaveChanges();
                }
                if(tabControl1.SelectedTab == tabControl1.TabPages[3] && textBox12.Text != null && textBox13.Text != null)
                {
                    Service service = new Service(textBox12.Text, Convert.ToInt32(textBox13.Text), richTextBox1.Text);
                    db.Services.Add(service);
                    db.SaveChanges();
                }
                if(tabControl1.SelectedTab == tabControl1.TabPages[4] && textBox14.Text != null && textBox15.Text != null
                    && textBox16.Text != null && textBox17.Text != null && textBox18.Text != null && textBox19.Text != null
                    && dateTimePicker2 != null && comboBox7.SelectedItem != null)
                {
                    foreach(Position position in db.Positions)
                    {
                        if(comboBox7.Text == position.name)
                        {
                            PositionKey = position.id;
                        }
                    }

                    Staff staff = new Staff(textBox19.Text, textBox18.Text, textBox17.Text, dateTimePicker2.Value,
                            Convert.ToInt32(textBox16.Text), Convert.ToInt32(textBox15.Text), textBox14.Text, PositionKey);
                    db.Staff.Add(staff);
                    db.SaveChanges();
                }
                if(tabControl1.SelectedTab == tabControl1.TabPages[5] && textBox21.Text != null && textBox22.Text != null)
                {
                    Position position = new Position(textBox21.Text, Convert.ToInt32(textBox22.Text));
                    db.Positions.Add(position);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Обнаружены пустые поля", "Сообщение");
                }
            }
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            buttonChange.Enabled = false;
            buttonDelete.Enabled = false;
            buttonAdd.Enabled = true;

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            textBox13.Enabled = true;
            textBox14.Enabled = true;
            textBox15.Enabled = true;
            textBox16.Enabled = true;
            textBox17.Enabled = true;
            textBox18.Enabled = true;
            textBox19.Enabled = true;
            comboBox7.Enabled = true;
            textBox21.Enabled = true;
            textBox22.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;

            comboBox2.Visible = false;
            textBoxUserClient.Visible = true;
        }

        private void textBoxUserClient_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxUserClient_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
