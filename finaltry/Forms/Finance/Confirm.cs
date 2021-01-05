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
    public partial class Confirm : Form
    {
        public Confirm()
        {
            InitializeComponent();
            label2.Text = label2.Text + " " + PaymentPage.studentname;
            label3.Text = label3.Text + " " + PaymentAmount.amount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentid = PaymentPage.studentid;
            int balance = Convert.ToInt32(PaymentPage.balance);
            int amount = PaymentAmount.amount;

            int newbalance = balance - amount;

            
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string query = "UPDATE StudentList SET Balance = " + newbalance + " WHERE StudentID = " + studentid + "";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.SelectCommand.ExecuteNonQuery();
            connection.Close();


            connection.Open();
            string query2 = "INSERT INTO PaymentsTable (StudentID, StudentName, ParentName, PaymentAmount, Date) VALUES ('"+studentid+"','"+PaymentPage.studentname+"','"+PaymentPage.parentname+"','" +amount+ "','" +Convert.ToString(DateTime.Today).Substring(0,10)+"')";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query2, connection);
            sqlDataAdapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
            this.Hide();
            InvoicePage invoicePage = new InvoicePage();
            invoicePage.ShowDialog();
            
        }
    }
}
