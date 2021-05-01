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
using WindowsFormsApplication1.Classes;

namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {

        public static Main main;
        public static User user1;
        public Main()
        {
            InitializeComponent();
            main = this;
            Registration.main = this;
            PassRecovery.main = this;
            
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;

            //using (UserContext db = new UserContext())
            //{
            //    Room room = new Room("Стандарт одноместный", 5000);
            //    db.Rooms.Add(room);
            //    Room room1 = new Room("Полу-люкс одноместный", 10000);
            //    db.Rooms.Add(room1);
            //    Room room2 = new Room("Люкс одноместный", 15000);
            //    db.Rooms.Add(room2);
            //    db.SaveChanges();
            //}

            //using (UserContext db = new UserContext())
            //{
            //    Service service = new Service("Базовый", 0, "Бесплатный Wi-Fi; Бесплатный завтрак; Уборка номера; Пробуждение к определенному времени.");
            //    db.Services.Add(service);
            //    Service service1 = new Service("Оптимальный", 5000, "Базовый пакет услуг; Ремонт одежды и обуви, стирка и химчистка; Организация экскурсий; Вызов такси; Заказ услуг переводчиков, гидов.");
            //    db.Services.Add(service1);
            //    Service service2 = new Service("Премиальный", 10000, "Базовый пакет услуг; Оптимальный пакет услуг; Прокат автомобилей; Пользование бильярдной, спортивным залом и площадками; Пользование сауной, баней, бассейном; Доставка посылок в номер; Прокат различного инвентаря, бытовых приборов.");
            //    db.Services.Add(service2);
            //    db.SaveChanges();
            //}

            //using (UserContext db = new UserContext())
            //{
            //    Staff staff = new Staff("Пупин", "Альберт", "Викторович", Convert.ToDateTime("05/01/1996"), 1245, 124579, "45678945619", 1);
            //    db.Staff.Add(staff);
            //    db.SaveChanges();
            //}
            //using (UserContext db = new UserContext())
            //{
            //    Position position = new Position("Администратор", 50000);
            //    Position position1 = new Position("Менеджер", 15000);
            //    Position position2 = new Position("Горничная", 20000);
            //    db.Positions.Add(position);
            //    db.Positions.Add(position2);
            //    db.Positions.Add(position1);
            //    db.SaveChanges();
            //}

            //using (UserContext db = new UserContext())
            //{
            //    User user = new User("admin", GetHashString("admin"), "valiaxmetovb135@gmail.com", "Admin");
            //    db.Users.Add(user);
            //    db.SaveChanges();
            //}

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            PassRecovery pr = new PassRecovery();
            pr.Show();
            main.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            main.Hide();
        }

        private void labelRegistration_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void labelRegistration_MouseLeave(object sender, EventArgs e)
        {
            labelRegistration.ForeColor = Color.White;
        }

        private void labelRegistration_MouseMove(object sender, MouseEventArgs e)
        {
            labelRegistration.ForeColor = Color.DeepSkyBlue;
        }

        private void labelPassRecovery_MouseMove(object sender, MouseEventArgs e)
        {
            labelPassRecovery.ForeColor = Color.DeepSkyBlue;
        }

        private void labelPassRecovery_MouseLeave(object sender, EventArgs e)
        {
            labelPassRecovery.ForeColor = Color.White;
        }
        //void textBoxesIsEmpty()
        //{
        //    if (textBoxLogin.Text == null )
        //}

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                label3.Visible = true;
            }
            if (textBoxPassword.Text == "")
            {
                label4.Visible = true;
            }
            if(textBoxLogin.Text != null && textBoxPassword.Text !=null)
            {
            using (UserContext db = new UserContext())
                {
                foreach (User user in db.Users)
                    {
                    
                    if (textBoxLogin.Text == user.Login && this.GetHashString(textBoxPassword.Text) == user.Password)
                        {
                            MessageBox.Show("Вход выполнен","Авторизация...");
                            user1 = user;
                            main.Hide();
                            if (user.Role == "Admin")
                            {
                                Administration administration = new Administration();
                                administration.Show();
                            }
                            else
                            {
                                WelcomeForm welcomeform = new WelcomeForm();
                                welcomeform.Show();
                            }
                        return;
                        }
                    }
                    label6.Visible = true;
                }
            }
            
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
        }
        public string pass = "";
        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;            
            pass = textBoxPassword.Text;
            
        }
        public bool IsPasswordVisible = true;
        private void label5_Click(object sender, EventArgs e)
        {
            if (IsPasswordVisible)
            {
                textBoxPassword.PasswordChar = '\0';
                IsPasswordVisible = false;
                label5.ForeColor = Color.DeepSkyBlue;
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
                IsPasswordVisible = true;
                label5.ForeColor = Color.White;
            }
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            if (IsPasswordVisible)
            {
                label5.ForeColor = Color.White;
            }
            else
            {
                label5.ForeColor = Color.DeepSkyBlue;
            }
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsPasswordVisible)
            {
                label5.ForeColor = Color.DeepSkyBlue;
            }
            else
            {
                label5.ForeColor = Color.White;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (textBoxLogin.Text == "")
                {
                    label3.Visible = true;
                }
                if (textBoxPassword.Text == "")
                {
                    label4.Visible = true;
                }
                if (textBoxLogin.Text != null && textBoxPassword.Text != null)
                {
                    using (UserContext db = new UserContext())
                    {
                        foreach (User user in db.Users)
                        {

                            if (textBoxLogin.Text == user.Login && this.GetHashString(textBoxPassword.Text) == user.Password)
                            {
                                MessageBox.Show("Вход выполнен", "Авторизация...");
                                user1 = user;
                                main.Hide();
                                if (user.Role == "Admin")
                                {
                                    Administration administration = new Administration();
                                    administration.Show();
                                }
                                else
                                {
                                    WelcomeForm welcomeform = new WelcomeForm();
                                    welcomeform.Show();
                                }
                                return;
                            }
                        }
                        label6.Visible = true;
                    }
                }
            }
        }
    }
}
