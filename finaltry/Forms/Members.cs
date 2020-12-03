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
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
            showdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMember addMember = new AddMember();
            addMember.ShowDialog();
            showdata();

        }

        public void showdata()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query;
            SqlCommand command;
            SqlDataAdapter sda;
            DataTable table = new DataTable();

            query = "SELECT * From Login_Table";
            command = new SqlCommand(query, connection);
            sda = new SqlDataAdapter(command);
            sda.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveMember removeMember = new RemoveMember();
            removeMember.ShowDialog();
            showdata();
        }
    }
}
