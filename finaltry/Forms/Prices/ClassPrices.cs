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

namespace finaltry.Forms.Prices
{
    public partial class ClassPrices : Form
    {
        public ClassPrices()
        {
            InitializeComponent();
            showdata("");
        }
        public static string classname;
        public static string classprice;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            classname = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[2].Value);
            classprice = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[3].Value);
            ChangeClassPrice changeClassPrice = new ChangeClassPrice();
            changeClassPrice.ShowDialog();
            showdata("");

            
        }

        public void showdata(string filter)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query;
            SqlCommand command;
            SqlDataAdapter sda;
            DataTable table = new DataTable();

            query = "SELECT * From ClassPriceTable WHERE ClassName Like '%" + filter +"%'";
            command = new SqlCommand(query, connection);
            sda = new SqlDataAdapter(command);
            sda.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClass addClass = new AddClass();
            addClass.ShowDialog();
            showdata("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveClass remove = new RemoveClass();
            remove.ShowDialog();
            showdata("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showdata(textBox1.Text);
        }
    }
}
