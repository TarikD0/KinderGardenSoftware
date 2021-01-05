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
    public partial class PaymentPage : Form
    {
        public PaymentPage()
        {
            InitializeComponent();
            searchdata("");
        }
        public static string studentname;
        public static string parentname;
        public static string balance;
        public static string studentid;


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                studentid = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[1].Value);
                studentname = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                parentname = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[4].Value);
                balance = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[5].Value);
                PaymentAmount paymentAmount = new PaymentAmount();
                paymentAmount.ShowDialog();
                searchdata("");
            }



         }

        public void searchdata(string valueToSearch)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT StudentID, StudentName, StudentSurname, StudentParentName, Balance From StudentList WHERE StudentName Like '%" + valueToSearch + "%' AND Balance > 0";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            sda.Fill(table);
            dataGridView1.DataSource = table;
            Console.WriteLine(dataGridView1.DataSource.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchdata(textBox1.Text);
        }
    }
}
