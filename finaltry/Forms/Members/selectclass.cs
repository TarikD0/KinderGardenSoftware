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

namespace finaltry.Forms.Student
{
    public partial class selectclass : Form
    {
        public selectclass()
        {
            InitializeComponent();
            showdata("");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex.Equals(0))
            {
                var senderGrid = (DataGridView)sender;
                finalchoice = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[1].Value);
                this.Close();
            }
        }

        public static string finalchoice;


        public void showdata(string filter)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query3 = "SELECT ClassName From ClassPriceTable WHERE ClassName Like '%" + filter + "%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query3, connection);
            DataTable table = new DataTable();
            sqlDataAdapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            showdata(textBox1.Text);
        }
    }
}
