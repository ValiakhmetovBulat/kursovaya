using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Forms;

namespace WindowsFormsApplication1
{
    public partial class WelcomeForm : Form
    {
        public static WelcomeForm welcome;
        public WelcomeForm()
        {
            InitializeComponent();
            welcome = this;
            CashAccount.welcome = this;
            PersonalData.welcome = this;
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            textBoxCash.Text = "0";
        }

        private void WelcomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            //MessageBox.Show("Выберите один из вариантов","Сообщение",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
       
        private void buttonAddCash_Click(object sender, EventArgs e)
        {
            CashAccount CashAcc = new CashAccount();
            CashAcc.Show();
            welcome.Hide();
        }

        private void buttonBookARoom_Click(object sender, EventArgs e)
        {
            PersonalData pd = new PersonalData();
            pd.Show();
            welcome.Hide();
        }
    }
}
