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
    public partial class ChangeClassPrice : Form
    {
        public ChangeClassPrice()
        {
            InitializeComponent();
            ClassNameBox.Text = ClassPrices.classname;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string query = "UPDATE ClassPriceTable SET ClassPrice = '" + textBox1.Text + "' WHERE ClassName = '" + ClassPrices.classname + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            sda.SelectCommand.ExecuteNonQuery();
            connection.Close();
            this.Close();
        }
    }
}
