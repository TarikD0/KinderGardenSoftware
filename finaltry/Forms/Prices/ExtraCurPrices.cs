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
            showdata("");
        }
        public static string activityid;
        public static string activityname;
        public static string activityprice;
        public static string classname;


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            activityid = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[1].Value);
            activityname = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[2].Value);
            activityprice = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[3].Value);
            classname = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[4].Value);


            Console.WriteLine(senderGrid.Rows[e.RowIndex].Cells[1].Value);
            Console.WriteLine(senderGrid.Rows[e.RowIndex].Cells[2].Value);
            Console.WriteLine(senderGrid.Rows[e.RowIndex].Cells[3].Value);
            Console.WriteLine(senderGrid.Rows[e.RowIndex].Cells[4].Value);

            EditActivityPrices editActivityPrices = new EditActivityPrices();
            editActivityPrices.ShowDialog();
            showdata("");


        }

        public void showdata(string filter)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query;
            SqlCommand command;
            SqlDataAdapter sda;
            DataTable table = new DataTable();
            if(filter == "")
            {
                query = "SELECT * From ActivitiesTable";
                command = new SqlCommand(query, connection);
                sda = new SqlDataAdapter(command);
                sda.Fill(table);
                dataGridView1.DataSource = table;
            }
            else
            {
                if(radioButton1.Checked)
                {
                    query = "SELECT * From ActivitiesTable WHERE ActivityName Like '%" + filter +"%'";
                    command = new SqlCommand(query, connection);
                    sda = new SqlDataAdapter(command);
                    sda.Fill(table);
                    dataGridView1.DataSource = table;
                }
                else if(radioButton2.Checked)
                {
                    query = "SELECT * From ActivitiesTable WHERE Class Like '%" + filter + "%'";
                    command = new SqlCommand(query, connection);
                    sda = new SqlDataAdapter(command);
                    sda.Fill(table);
                    dataGridView1.DataSource = table;
                }
                else
                {
                    query = "SELECT * From ActivitiesTable WHERE ActivityName Like '%" + filter + "%'";
                    command = new SqlCommand(query, connection);
                    sda = new SqlDataAdapter(command);
                    sda.Fill(table);
                    dataGridView1.DataSource = table;

                }
                    
                
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddActivity add = new AddActivity();
            add.ShowDialog();
            showdata("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userinput userinput = new userinput();
            userinput.ShowDialog();
            showdata("");
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showdata(textBox1.Text);
        }
    }
}
