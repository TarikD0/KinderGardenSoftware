using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finaltry.Forms.Finance
{
    public partial class PaymentAmount : Form
    {
        public PaymentAmount()
        {
            InitializeComponent();
            StudentName.Text = "Student Name: " +PaymentPage.studentname;
            ParentName.Text = "Parent Name: "+PaymentPage.parentname;
            OutstandingBalance.Text = "Remaning Balance: "+PaymentPage.balance;
        }

        public static int amount;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                amount = Convert.ToInt32(textBox1.Text);
                Confirm confirm = new Confirm();
                confirm.ShowDialog();
                this.Close();
            }
            else
            {

            }

        }
    }
}
