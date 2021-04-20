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
namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        public static Main main;
        
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
            //    int key = 8;
            //    var item = db.Users.Find(key);
            //    item.Role = "Admin";
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
    }
}
