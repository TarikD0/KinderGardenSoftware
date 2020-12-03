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
    public partial class EditService : Form
    {
        public EditService()
        {
            InitializeComponent();
            ServiceNameBox.Text = ServicePrices.servicename;
            textBox2.Text = ServicePrices.servicename;
            textBox3.Text = ServicePrices.serviceprice;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query;
            SqlDataAdapter sda;
            connection.Open();
            query = "UPDATE Prices SET ProductName = '"+textBox2.Text+"', ProductPrice = '"+textBox3.Text+"";
            sda = new SqlDataAdapter(query, connection);
            sda.SelectCommand.ExecuteNonQuery();
            connection.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
