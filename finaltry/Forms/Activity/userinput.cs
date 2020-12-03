using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finaltry.Forms
{
    public partial class userinput : Form
    {
        public userinput()
        {
            InitializeComponent();
          
        }
        public static string userchoice;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userchoice = textBox1.Text;
            this.Close();
        }
    
    }
}
