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
    public partial class Success : Form
    {
        public Success()
        {
            InitializeComponent();
        }

        private void Success_FormClosed(object sender, FormClosedEventArgs e)
        {
            WelcomeForm welcome = new WelcomeForm();
            welcome.Show();
        }

        private void Success_Load(object sender, EventArgs e)
        {

        }
    }
}
