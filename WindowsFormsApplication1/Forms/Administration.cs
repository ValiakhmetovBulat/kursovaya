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

namespace WindowsFormsApplication1
{
    public partial class Administration : Form
    {
        
        public Administration()
        {
            InitializeComponent();
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
                    item = db.Users.Find(key);
                    item.Login = textBox1.Text;
                }
                if (textBox2.Text != "")
                {
                    item = db.Users.Find(key);
                    item.Password = GetHashString(textBox2.Text);
                }
                if (textBox3.Text != "")
                {
                    item = db.Users.Find(key);
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
        public int key;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                foreach (User user in db.Users)
                {
                    if (user.Login ==  comboBox1.SelectedItem.ToString())
                    {
                        key = user.Id;
                    }
                }
            }
        }

        private void Administration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main.main.Show();
        }
    }
}
