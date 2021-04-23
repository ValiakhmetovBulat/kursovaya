using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class PersonalData : Form
    {
        public static WelcomeForm welcome;
        public static PersonalData pd;
        public static User user = Main.user1;
        
        public PersonalData()
        {
            InitializeComponent();
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            dateOfBirth.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "")
            {
                label8.Visible = true;
            }
            if (textBoxName.Text == "")
            {
                label9.Visible = true;
            }
            if (textBoxPerv.Text == "")
            {
                label10.Visible = true;
            }
            if (textBoxPS.Text == "" || textBoxPN.Text == "")
            {
                label11.Visible = true;
            }
            if (textBoxNumber.Text == "")
            {
                label12.Visible = true;
            }
            if(dateOfBirth.Text == "")
            {
                label13.Visible = true;
            }
            using (UserContext db = new UserContext())
            {
                Client client1 = new Client(textBoxSurname.Text, textBoxName.Text, textBoxPerv.Text, dateOfBirth.Value, Convert.ToInt32(textBoxPS.Text), Convert.ToInt32(textBoxPN.Text), textBoxNumber.Text, user.Id);
                db.Clients.Add(client1);
                db.SaveChanges();
            }
            //MessageBox.Show("sfsdfsdfsdf");
            textBoxSurname.Text = null;
            textBoxName.Text = null;
            textBoxPerv.Text = null;
            textBoxPS.Text = null;
            textBoxPN.Text = null;
            textBoxNumber.Text = null;
            dateOfBirth.Text = null;
        }

        private void PersonalData_FormClosed(object sender, FormClosedEventArgs e)
        {
            welcome.Show();
        }

        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBoxPerv_TextChanged(object sender, EventArgs e)
        {
            label10.Visible = false;
        }

        private void textBoxNumber_TextChanged(object sender, EventArgs e)
        {
            label12.Visible = false;
        }

        private void dateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            label13.Visible = false;
        }
        int check1 = 0;
        private void textBoxPS_TextChanged(object sender, EventArgs e)
        {
            check1++;
            if(check2>0)
            {
                label11.Visible = false;
            }
        }
        int check2 = 0;
        private void textBoxPN_TextChanged(object sender, EventArgs e)
        {
            check2++;
            if (check1 > 0)
            {
                label11.Visible = false;
            }
        }

        private void textBoxPS_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxPN_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
