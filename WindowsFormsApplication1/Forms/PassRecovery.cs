using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    public partial class PassRecovery : Form
    {
        public static Main main;
        public int recoveryCode;
        public User user1;
        public PassRecovery()
        {
            InitializeComponent();
            button1.Text = "Отправить";
            label2.Visible = false;
        }

        private void PassRecovery_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                using (UserContext db = new UserContext())
            {


                {
                    if (button1.Text == "Отправить")
                    {
                        MailAddress from = new MailAddress("ii.oio.ooo@mail.ru", "kriper2004");
                        MailAddress to = new MailAddress(textBoxEmail.Text);
                        MailMessage m = new MailMessage(from, to);
                        m.Subject = "Восстановление";

                        foreach (User user in db.Users)
                        {
                            if (textBoxEmail.Text == user.Email)
                            {
                                user1 = user;
                                Random random = new Random();
                                recoveryCode = random.Next(10000, 99999);
                                m.Body = "<h1>Здравствуйте, " + user.Login + ".Ваш код подтверждения: " + recoveryCode + "</h1>";
                                label1.Text = "Введите код подтверждения";
                                button1.Text = "ОК";                                    
                                m.IsBodyHtml = true;
                                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                                smtp.Credentials = new NetworkCredential("ii.oio.ooo@mail.ru", "MaximovRomanSergeevich");
                                smtp.EnableSsl = true;
                                smtp.Send(m);

                                label2.Location = new Point(67, 76);
                                label2.ForeColor = Color.Lime;
                                label2.Visible = true;
                                label2.Text = "код успешно отправлен";
                                textBoxEmail.Text = "";
                            }

                        }
                    }

                    else if (button1.Text == "ОК")
                    {
                        if (textBoxEmail.Text == Convert.ToString(recoveryCode))
                        {
                            label1.Text = "Введите новый пароль";
                            label2.Visible = false;
                            button1.Text = "Изменить";
                            textBoxEmail.Text = "";
                        }
                        else
                        {
                            label2.Location = new Point(67, 76);
                            label2.ForeColor = Color.Red;
                            label2.Text = "код неверен";
                        }
                    }

                    else if (button1.Text == "Изменить")
                    {

                        if (textBoxEmail.Text != "")
                        {
                            label2.Location = new Point(67, 76);
                            label2.ForeColor = Color.Lime;
                            label2.Visible = true;
                            label2.Text = "пароль успешно изменен";
                            //MessageBox.Show(user1.Password);
                            //MessageBox.Show(GetHashString(textBoxEmail.Text));                            
                            var item = db.Users.Find(user1.Id);
                            item.Password = this.GetHashString(textBoxEmail.Text);
                            db.SaveChanges();
                        }
                        else
                        {
                            label2.Location = new Point(67, 76);
                            label2.ForeColor = Color.Red;
                            label2.Text = "некорректный пароль";


                        }
                    }






                }

                }
               
        }
            catch
            {
                label2.ForeColor = Color.Red;
                label2.Location = new Point(80, 76);
                label2.Text = "неверный формат почты";
                label2.Visible = true;
            }
        }

        private void PassRecovery_Load(object sender, EventArgs e)
        {

        }
    }
}
