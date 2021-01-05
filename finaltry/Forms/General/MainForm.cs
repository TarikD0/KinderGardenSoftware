using finaltry.Classes;
using finaltry.Forms;
using finaltry.Forms.Finance;
using finaltry.Forms.Prices;
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
           // List<Student> students = new List<Student>();
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

        private void button6_Click(object sender, EventArgs e)
        {


        

       }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if ((Application.OpenForms["Classes"] as cls) != null)
            {
                Console.WriteLine("asdasd");
            }
            else
            {
                List<Student> students = new List<Student>();
                cls classes = new cls();

                classes.ShowDialog();

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DisplayExtraCur displayExtraCur = new DisplayExtraCur();
            displayExtraCur.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddActivity addActivity = new AddActivity();
            addActivity.ShowDialog();

        }

        private void button21_Click(object sender, EventArgs e)
        {
            ClassPrices classPrices = new ClassPrices();
            classPrices.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ServicePrices servicePrices = new ServicePrices();
            servicePrices.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExtraCurPrices extraCurPrices = new ExtraCurPrices();
            extraCurPrices.ShowDialog();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Members members = new Members();
            members.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddMember addMember = new AddMember();
            addMember.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemoveMember removeMember = new RemoveMember();
            removeMember.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PaymentPage paymentPage = new PaymentPage();
            paymentPage.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            InvoiceList invoiceList = new InvoiceList();
            invoiceList.ShowDialog();
        }
    }
}