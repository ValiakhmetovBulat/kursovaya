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
    public partial class WelcomeForm : Form
    {
        
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            checkedListBoxServices.Items.Add("adddd");
            checkedListBoxServices.Items.Add("adddd");
            checkedListBoxServices.Items.Add("adddd");
        }

        private void WelcomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddCash_Click(object sender, EventArgs e)
        {
            
        }
    }
}
