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

namespace finaltry.Forms
{
    public partial class AddActivity : Form
    {
        public AddActivity()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ActivityIDTextBox.Text != "" && ActivityNameTextBox.Text != "" && ActivityPriceTextBox.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
                connection.Open();
           
                string query = "INSERT INTO ActivitiesTable (ExtraCurID, ActivityName, Price, Class) VALUES ('" + ActivityIDTextBox.Text + "','" + ActivityNameTextBox.Text + "','" + Convert.ToInt32(ActivityPriceTextBox.Text) + "','" + textBox1.Text +"')";
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.SelectCommand.ExecuteNonQuery();
                connection.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Complete The Form!", "Error!", MessageBoxButtons.OK);
            }
        }
    }
}
