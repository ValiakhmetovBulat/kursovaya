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

namespace WindowsFormsApplication1.Forms
{
    public partial class ChangeData : Form
    {
        public ChangeData()
        {
            InitializeComponent();
        }
        
        private void ChangeData_FormClosed(object sender, FormClosedEventArgs e)
        {
            WelcomeForm welcome = new WelcomeForm();
            welcome.Show();
        }

        private void ChangeData_Load(object sender, EventArgs e)
        {
            bool IsClientFound = false;
            label8.Visible = false;
            using (UserContext db = new UserContext())
            {
                textBoxChangeLogin.Text = Main.user1.Login;                
                textBoxChangeEmail.Text = Main.user1.Email;
                foreach (Client client in db.Clients)
                {
                    if (client.userId == Main.user1.Id)
                    {
                        textBoxChangeName.Text = client.name;
                        textBoxChangeSurname.Text = client.surname;
                        textBoxChangePerv.Text = client.patr;
                        textBoxChangeNumber.Text = client.phone;
                        textBoxChangeName.Enabled = true;
                        textBoxChangeSurname.Enabled = true;
                        textBoxChangePerv.Enabled = true;
                        textBoxChangeNumber.Enabled = true;
                        textBoxChangePS.Enabled = true;
                        textBoxChangePN.Enabled = true;
                        dateOfBirth.Enabled = true;
                        textBoxChangePS.Text = client.p_series.ToString();
                        textBoxChangePN.Text = client.p_number.ToString();
                        dateOfBirth.Value = client.date_of_birth;
                        label8.Visible = false;
                        IsClientFound = true;
                    }
                    else if (!IsClientFound)
                    {
                        label8.Visible = true;
                        dateOfBirth.Enabled = false ;
                        textBoxChangeName.Enabled = false;
                        textBoxChangeSurname.Enabled = false;
                        textBoxChangePerv.Enabled = false;
                        textBoxChangeNumber.Enabled = false;
                        textBoxChangePS.Enabled = false;
                        textBoxChangePN.Enabled = false;
                    }
                }
            }
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
        private void buttonChangeData_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
               foreach (Client client in db.Clients)
                {
                    if (client.userId == Main.user1.Id)
                    {
                        client.name = textBoxChangeName.Text;
                        client.surname = textBoxChangeName.Text;
                        client.patr = textBoxChangePerv.Text;
                        client.phone = textBoxChangeNumber.Text;
                        client.p_number = Convert.ToInt32(textBoxChangePN.Text);
                        client.p_series = Convert.ToInt32(textBoxChangePS.Text);
                        client.date_of_birth = dateOfBirth.Value;
                       
                    }

                }
               foreach (User user in db.Users)
                {
                    if (user.Id == Main.user1.Id)
                    {
                        if (textBoxChangePassword.Text != "")
                        {
                            user.Login = textBoxChangeLogin.Text;
                            user.Password = GetHashString(textBoxChangePassword.Text);
                            user.Email = textBoxChangeEmail.Text;
                        }
                        else
                        {
                            user.Login = textBoxChangeLogin.Text;
                            user.Email = textBoxChangeEmail.Text;
                        }
                    }
                }
                db.SaveChanges();
                MessageBox.Show("Изменено");
            }
        }

        private void textBoxChangePS_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxChangePN_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxChangeNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
