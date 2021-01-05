using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finaltry.Forms.Student;
using System.Data.SqlClient;

namespace finaltry.Forms
{
    public partial class userinput : Form
    {
        public userinput()
        {
            InitializeComponent();
          
        }
        public static string userchoice;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userchoice = textBox1.Text;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectclass selectclass = new selectclass();
            selectclass.ShowDialog();
            textBox1.Text = selectclass.finalchoice;
            getList(textBox1.Text);
        }


        public void getList(string filter)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT ExtraCurID, ActivityName, Class FROM ActivitiesTable WHERE Class ='"+filter+"'" ;

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            sda.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            var senderGrid = (DataGridView)sender;
            
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                string exid = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[1].Value);

                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
                string query;
                SqlDataAdapter sda;
                connection.Open();
                query = "DELETE From ActivitiesTable WHERE Class = '" + textBox1.Text + "' AND ExtraCurID = '" +exid+ "'";
                Console.WriteLine(textBox1.Text);
                Console.WriteLine(exid);
                sda = new SqlDataAdapter(query, connection);
                sda.SelectCommand.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                string query2 = "Delete From ActivityStudentList WHERE ActivityID = " + exid + "";
                SqlCommand command2 = new SqlCommand(query2, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command2);
                sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                connection.Close();
                getList(textBox1.Text);
            
        }
        }
    }
}
