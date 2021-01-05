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
    public partial class ServicePrices : Form
    {
        public ServicePrices()
        {
            InitializeComponent();
            showdata("");
        }



        public void showdata(string filter)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query;
            SqlCommand command;
            SqlDataAdapter sda;
            DataTable table = new DataTable();

            query = "SELECT * From Prices WHERE ProductName Like '%" + filter +"%'";
            command = new SqlCommand(query, connection);
            sda = new SqlDataAdapter(command);
            sda.Fill(table);

            dataGridView1.DataSource = table;

        }
        public static string serviceid;
        public static string servicename;
        public static string serviceprice;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            serviceid = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[1].Value);
            servicename = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[2].Value);
            serviceprice = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[3].Value);
            EditService editService = new EditService();
            editService.ShowDialog();
            showdata("");



        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddService addService = new AddService();
            addService.ShowDialog();
            showdata("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveService removeService = new RemoveService();
            removeService.ShowDialog();
            showdata("");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            showdata(textBox1.Text);
        }
    }
}
