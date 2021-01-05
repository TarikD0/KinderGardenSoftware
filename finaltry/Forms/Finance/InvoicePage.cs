using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace finaltry.Forms.Finance
{
    public partial class InvoicePage : Form
    {
        public InvoicePage()
        {
            
            InitializeComponent();
            label2.Text = Login.username;
            label6.Text = Convert.ToString(DateTime.Today).Substring(0, 10);
            getdata();
        }


        public void getdata()
        {
            bool taklunch = false;
            bool takbus = false;
            string clas = "";
            int ExtraActCount = 0;
            int balance = 0;
            string studid = PaymentPage.studentid;
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT StudentClass, UsesBus, TakesLunch, ExtraCurActivitiesCount, Balance, StudentName, StudentSurname, StudentParentName, StudentParentSurname FROM StudentList WHERE StudentID = "+studid+"";
            SqlCommand command = new SqlCommand(query,connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            sda.Fill(table);
            if(table.Rows.Count == 1)
            {
                clas = Convert.ToString(table.Rows[0].ItemArray[0]);
                takbus = Convert.ToBoolean(table.Rows[0].ItemArray[1]);
                taklunch = Convert.ToBoolean(table.Rows[0].ItemArray[2]);
                ExtraActCount = Convert.ToInt32(table.Rows[0].ItemArray[3]);
                balance = Convert.ToInt32(table.Rows[0].ItemArray[4]);

            }
            label8.Text = "Class Name: " +clas;
            label9.Text = "Lunch Taken: " + Convert.ToString(taklunch);
            label10.Text = "Bus Taken: " + Convert.ToString(takbus);
            label11.Text = "Number of Activities Registered: " + Convert.ToString(ExtraActCount);
            label12.Text = "Total Balance Remaining: " + Convert.ToString(balance);
            label13.Text = "Amount Paid: " + Convert.ToString(PaymentAmount.amount);
            label14.Text = "Parent Name: " + Convert.ToString(table.Rows[0].ItemArray[7]) +" "+Convert.ToString(table.Rows[0].ItemArray[8]);
            label15.Text = "Student Name: " + Convert.ToString(table.Rows[0].ItemArray[5]) + " " + Convert.ToString(table.Rows[0].ItemArray[6]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
