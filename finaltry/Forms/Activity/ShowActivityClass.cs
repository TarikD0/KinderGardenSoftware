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
using finaltry.Forms.Activity;

namespace finaltry
{
    public partial class ShowActivityClass : Form
    {
        public ShowActivityClass()
        {
           
            InitializeComponent();
            filldata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }



        public void filldata()
        {
            dataGridView1.DataSource = DisplayExtraCur.DataTable;
            ActivityNameBox.Text = DisplayExtraCur.ActivityName;
        }
        public static DataTable DataTable = new DataTable();

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query;
            SqlCommand command;
            SqlDataAdapter sda;
            DataTable table = new DataTable();

            query = "SELECT StudentID FROM StudentList EXCEPT SELECT StudentD FROM ActivityStudentList";
            command = new SqlCommand(query, connection);
            sda = new SqlDataAdapter(command);
            sda.Fill(table);
            int i = 0;
            
            foreach(var row in table.Rows)
            {
                string query2 = "SELECT StudentName From StudentList WHERE StudentID = " + table.Rows[i].ItemArray[0] +"";
                command = new SqlCommand(query2, connection);
                sda = new SqlDataAdapter(command);
                sda.Fill(DataTable);
                i = i + 1;
            }
            Console.WriteLine("So Far So GOOD!");
            AddStudentToActivity addStudentToActivity = new AddStudentToActivity();
            addStudentToActivity.ShowDialog();
            //Console.WriteLine(AddStudentToActivity.name);
            query = "SELECT StudentID From StudentList WHERE StudentName = '" +AddStudentToActivity.name+"'";
            command = new SqlCommand(query, connection);
            sda = new SqlDataAdapter(command);
            DataTable newdatatable = new DataTable();
            sda.Fill(newdatatable);
            string studentid = Convert.ToString(newdatatable.Rows[0].ItemArray[0]);
            Console.WriteLine("Student ID SELECTED");


            query = "SELECT ExtraCurID From ActivitiesTable WHERE ActivityName = '" +ActivityNameBox.Text+"'";
            command = new SqlCommand(query, connection);
            sda = new SqlDataAdapter(command);
            DataTable table1 = new DataTable();
            sda.Fill(table1);
            string activityid = Convert.ToString(table1.Rows[0].ItemArray[0]);

            Console.WriteLine("Activity ID SELECTED");
            query = "INSERT INTO ActivityStudentList(StudentD, ActivityID) VALUES (" +studentid+ "," +activityid+ ")";
            connection.Open();
            sda = new SqlDataAdapter(query, connection);
            sda.SelectCommand.ExecuteNonQuery();
            connection.Close();
            this.Close();
            
        }
    }
}
