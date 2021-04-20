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
        public static CashAccount CashAcc;
        public static WelcomeForm welcome;
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
            try
            {
                int cash = Convert.ToInt32(textBoxAddCash.Text);
                int cash1 = Convert.ToInt32(welcome.textBoxCash.Text);
                int cash2 = 0;
                if (radioButtonRuble.Checked)
                {
                    cash2 = cash + cash1;
                    welcome.textBoxCash.Text = Convert.ToString(cash2);
                }
                if (radioButtonDollar.Checked)
                {
                    cash2 = cash * 75 + cash1;
                    welcome.textBoxCash.Text = Convert.ToString(cash2);
                }
                if (radioButtonEuro.Checked)
                {
                    cash2 = cash * 90 + cash1;
                    welcome.textBoxCash.Text = Convert.ToString(cash2);
                }
                MessageBox.Show("+деньги");
                textBoxAddCash.Text = null;
            }
            catch
            {

            }

        }

        private void CashAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            welcome.Show();
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
