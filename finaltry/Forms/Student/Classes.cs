using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace finaltry
{
   
    public partial class cls : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
        string query;
        SqlCommand command;
        SqlDataAdapter sda;
        DataTable table;
        bool StudentName, ParentName, PhoneNumber, Class = false;
        public List<string> parData = new List<string>();
        public cls()
        {
            InitializeComponent();
            searchData("");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            StudentName = false;
            ParentName = true;
            PhoneNumber = false;
            Class = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            StudentName = false;
            ParentName = false;
            PhoneNumber = true;
            Class = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            StudentName = false;
            ParentName = false;
            PhoneNumber = false;
            Class = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent add = new AddStudent();
            add.ShowDialog();
            searchData("");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
            var result = MessageBox.Show("Are you sure you want to delete this user?","Delete User", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                var senderGrid = (DataGridView)sender;
               
                if(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    string temp = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[1].Value);
                    query = "DELETE From StudentList WHERE StudentID = "+ senderGrid.Rows[e.RowIndex].Cells[1].Value + "";
                    command = new SqlCommand(query, connection);
                    sda = new SqlDataAdapter(command);
                    table = new DataTable();
                    sda.Fill(table);
                    dataGridView1.DataSource = table;
                    searchData("");
                }
            }
        }

        public void searchData(String valueToSearch)
        {
            if (StudentName) { 
             query = "SELECT * From StudentList WHERE StudentName Like '%"+valueToSearch+"%'";
             command = new SqlCommand(query, connection);
             sda = new SqlDataAdapter(command);
             table = new DataTable();
             sda.Fill(table);
             dataGridView1.DataSource = table;
             Console.WriteLine(dataGridView1.DataSource.ToString());
            }
            else if(ParentName)
            {
                query = "SELECT * From StudentList WHERE StudentParentName Like '%" + valueToSearch + "%'";
                command = new SqlCommand(query, connection);
                sda = new SqlDataAdapter(command);
                table = new DataTable();
                sda.Fill(table);
                dataGridView1.DataSource = table;
                Console.WriteLine(dataGridView1.DataSource.ToString());
            }
            else if(PhoneNumber)
            {
                query = "SELECT * From StudentList WHERE ParentPhoneNumber Like '%" + valueToSearch + "%'";
                command = new SqlCommand(query, connection);
                sda = new SqlDataAdapter(command);
                table = new DataTable();
                sda.Fill(table);
                dataGridView1.DataSource = table;
                Console.WriteLine(dataGridView1.DataSource.ToString());
            }
            else if(Class)
            {
                query = "SELECT * From StudentList WHERE StudentClass Like '%" + valueToSearch + "%'";
                command = new SqlCommand(query, connection);
                sda = new SqlDataAdapter(command);
                table = new DataTable();
                sda.Fill(table);
                dataGridView1.DataSource = table;
                Console.WriteLine(dataGridView1.DataSource.ToString());
            }
            else
            {
                query = "SELECT * From StudentList WHERE StudentName Like '%" + valueToSearch + "%'";
                command = new SqlCommand(query, connection);
                sda = new SqlDataAdapter(command);
                table = new DataTable();
                sda.Fill(table);
                dataGridView1.DataSource = table;
                Console.WriteLine(dataGridView1.DataSource.ToString());
                
            }

            




        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            searchData(textBox1.Text);
         
      
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            StudentName = true;
            ParentName = false;
            PhoneNumber = false;
            Class = false;
        }
    }
}
