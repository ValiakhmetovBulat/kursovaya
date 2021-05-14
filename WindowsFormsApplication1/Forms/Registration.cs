//using MyLib;
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
using System.Threading.Tasks;
using System.Net.Sockets;
namespace WindowsFormsApplication1
{
    public partial class Registration : Form
    {
        public static Main main;
        public static Registration registration;
        private byte[] imageBytes;
        private TcpClient client = new TcpClient("127.0.0.1", 8888);
        private Byte[] data;
        private NetworkStream stream;
        private MyLib.Message m1, m2, m;
        private MyLib.ComplexMessage cm = new MyLib.ComplexMessage();
        public Registration()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
        }

        private void InitComponentMessage(object
first, object second, int status)
        {
            this.m1 = MyLib.SerializeAndDeserialize.Serialize(first);
            this.m2 = MyLib.SerializeAndDeserialize.Serialize(second);
            cm.First = m1;
            cm.Second = m2;
            cm.NumberStatus = status;
            m = MyLib.SerializeAndDeserialize.Serialize(cm);
            this.data = m.Data;
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
            
        }

        private void textBoxRepeatPassword_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            
            if (textBoxEmail.Text == "")
            {
                label4.Visible = true;
            }
            if (textBoxLogin.Text == "")
            {
                label1.Visible = true;
            }
            if (textBoxPassword.Text == "")
            {
                label2.Visible = true;
            }
            if (textBoxRepeatPassword.Text == "")
            {
                label3.Visible = true;
            }
            if (textBoxPassword.Text == textBoxRepeatPassword.Text)
            {
                using (UserContext db = new UserContext())
                {
                    int count = 0;
                    foreach (User user1 in db.Users)
                    {
                        if (textBoxEmail.Text == user1.Email)
                        {
                            count++;
                            label6.Location = new Point(65, 196);
                            label6.ForeColor = Color.Red;
                            label6.Visible = true;
                            label6.Text = "пользователь с данной почтой уже зарегестрирован";
                        }
                        if (textBoxLogin.Text == user1.Login)
                        {
                            count++;
                            label6.Location = new Point(65, 196);
                            label6.ForeColor = Color.Red;
                            label6.Visible = true;
                            label6.Text = "пользователь с данным логином уже зарегестрирован";
                        }
                    }
                    if (count == 0)
                    {
                        //try
                        //{
                            User user = new User(textBoxLogin.Text, this.GetHashString(textBoxPassword.Text), textBoxEmail.Text, "User", 0);
                            this.InitComponentMessage(client, user,
0);
                            stream.Write(data, 0, data.Length);
                            stream.Flush();

                            MailAddress from = new MailAddress("ii.oio.ooo@mail.ru", "kriper2004");
                            MailAddress to = new MailAddress(textBoxEmail.Text);
                            MailMessage m = new MailMessage(from, to);
                            m.Subject = "Регистрация";

                            m.Body = "<h1>Здравствуйте, " + user.Login + ".Вы были заригестрированы. Ваши California Hotels</h1>";
                            m.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                            smtp.Credentials = new NetworkCredential("ii.oio.ooo@mail.ru", "MaximovRomanSergeevich");
                            smtp.EnableSsl = true;
                            smtp.Send(m);

                            db.Users.Add(user);
                            db.SaveChanges();
                            label6.ForeColor = Color.Lime;
                            label6.Visible = true;
                            label6.Text = "аккаунт зарегестрирован";
                            textBoxLogin.Text = null;
                            textBoxPassword.Text = null;
                            textBoxRepeatPassword.Text = null;
                            textBoxEmail.Text = null;
                        //}
                        //catch
                        //{
                        //    label6.Location = new Point(120 ,196);
                        //    label6.Visible = true;
                        //    label6.Text = "некорректная почта";
                        //    label6.ForeColor = Color.Red;
                        //}
                    }
                }
            }
            else
            {
                label6.ForeColor = Color.Red;
                label6.Visible = true;
                label6.Text = "пароли не совпадают";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
