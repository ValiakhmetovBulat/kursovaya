using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Forms
{
    public partial class CashAccount : Form
    {
     
       
        public User user = Main.user1;
        public CashAccount()
        {
            InitializeComponent();
            radioButtonRuble.Checked = true;
            
        }

        private void CashAccount_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddCash_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                try
                {
                    user = db.Users.Find(user.Id);
                    int cash = Convert.ToInt32(textBoxAddCash.Text);                 
                    if (radioButtonRuble.Checked)
                    {
                        user.sum += cash;
                        
                    }
                    if (radioButtonDollar.Checked)
                    {
                        user.sum += cash * 70;
                    }
                    if (radioButtonEuro.Checked)
                    {
                        user.sum += cash * 90;
                    }
                    MessageBox.Show("Счет пополнен");
                    textBoxAddCash.Text = null;
                    db.SaveChanges();
                }
                catch
                {

                }
            }
        }

        private void CashAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            
        }

        private void textBoxAddCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
