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
    public partial class InvoiceList : Form
    {
        public InvoiceList()
        {
            InitializeComponent();
            searchdata();
        }

        public static string studentid;
        public static string date;
        public static string amount;

        public void searchdata()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * FROM PaymentsTable";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            sda.Fill(table);
            dataGridView1.DataSource = table;
            Console.WriteLine(dataGridView1.DataSource.ToString());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                studentid = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                date = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[6].Value);
                amount = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[5].Value);

                Console.WriteLine(studentid);
                Console.WriteLine(date);
                Console.WriteLine(amount);
                ShowInvoicesFromList showInvoicesFromList = new ShowInvoicesFromList();
                showInvoicesFromList.ShowDialog();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
