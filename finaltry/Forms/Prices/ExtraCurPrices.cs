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
    public partial class ExtraCurPrices : Form
    {
        public ExtraCurPrices()
        {
            InitializeComponent();
            showdata();
        }
        public static string activityid;
        public static string activityname;
        public static string activityprice;


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            activityid = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[1].Value);
            activityname = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[2].Value);
            activityprice = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[3].Value);
            EditActivityPrices editActivityPrices = new EditActivityPrices();
            editActivityPrices.Show();
            showdata();


        }

        public void showdata()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query;
            SqlCommand command;
            SqlDataAdapter sda;
            DataTable table = new DataTable();

            query = "SELECT * From ActivitiesTable";
            command = new SqlCommand(query, connection);
            sda = new SqlDataAdapter(command);
            sda.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddActivity add = new AddActivity();
            add.ShowDialog();
            showdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userinput userinput = new userinput();
            userinput.ShowDialog();
            showdata();
            if (userinput.userchoice == "" || userinput.userchoice == null)
            {

            }
            else
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
                string query;
                SqlDataAdapter sda;
                
                connection.Open();
                query = "DELETE From ActivitiesTable WHERE ExtraCurID = " + userinput.userchoice + "";

                sda = new SqlDataAdapter(query, connection);
                sda.SelectCommand.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                string query2 = "Delete From ActivityStudentList WHERE ActivityID = " + userinput.userchoice + "";
                SqlCommand command2 = new SqlCommand(query2, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command2);
                sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                connection.Close();

            }
            showdata();
        }
    }
}
