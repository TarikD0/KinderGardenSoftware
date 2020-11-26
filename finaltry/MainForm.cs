using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finaltry
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void customizeDesign()
        {
            subpanel1.Visible = false;
            subpanel2.Visible = false;
            subpanel3.Visible = false;
            subpanel4.Visible = false;
            subpanel5.Visible = false;

        }
        private void hideSubMenu()
        {
            if(subpanel1.Visible == true)
            {
                subpanel1.Visible = false;
            }
            if (subpanel2.Visible == true)
            {
                subpanel2.Visible = false;
            }
            if (subpanel3.Visible == true)
            {
                subpanel3.Visible = false;
            }
            if (subpanel4.Visible == true)
            {
                subpanel4.Visible = false;
            }
            if (subpanel5.Visible == true)
            {
                subpanel5.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanel1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanel2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanel3);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanel4);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanel5);
        }

   
    }
}