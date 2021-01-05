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

        public static string testing = DisplayExtraCur.classname;
        public static string actid = DisplayExtraCur.ActivityID;
        public void filldata()
        {
            if(DisplayExtraCur.DataTable.Rows.Count == 0)
            {
                label1.Text = "There are currently no students registered to this activity. Maybe add some?";
            }
            else
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT StudentD, StudentName, ActivityName FROM ActivityStudentList WHERE ActivityID = " + DisplayExtraCur.ActivityID + " AND Class = '" + DisplayExtraCur.classname + "'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                sda.Fill(table);
                dataGridView1.DataSource = table;

            }
          
                ActivityNameBox.Text = DisplayExtraCur.ActivityName;
            label2.Text = DisplayExtraCur.classname;
            
          
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query;
            SqlCommand command;
            SqlDataAdapter sda;
            DataTable table = new DataTable();

            Console.WriteLine("So Far So GOOD!");
            AddStudentToActivity addStudentToActivity = new AddStudentToActivity();
            addStudentToActivity.ShowDialog();
            //Console.WriteLine(AddStudentToActivity.name);
            if(AddStudentToActivity.added)

            {
                Console.WriteLine(AddStudentToActivity.name);

                    query = "SELECT StudentID From StudentList WHERE StudentName = '"+ AddStudentToActivity.name + "'";
                command = new SqlCommand(query, connection);
                sda = new SqlDataAdapter(command);
                DataTable newdatatable = new DataTable();
                sda.Fill(newdatatable);
                string studentid = Convert.ToString(newdatatable.Rows[0].ItemArray[0]);
                Console.WriteLine("Student ID SELECTED");


                query = "SELECT ExtraCurID From ActivitiesTable WHERE ActivityName = '" + ActivityNameBox.Text + "'";
                command = new SqlCommand(query, connection);
                sda = new SqlDataAdapter(command);
                DataTable table1 = new DataTable();
                sda.Fill(table1);
                string activityid = Convert.ToString(table1.Rows[0].ItemArray[0]);

                Console.WriteLine("Activity ID SELECTED");
                query = "INSERT INTO ActivityStudentList(StudentD, ActivityID, Class) VALUES (" + studentid + "," + activityid + ",'" + testing +"')";
                connection.Open();
                sda = new SqlDataAdapter(query, connection);
                sda.SelectCommand.ExecuteNonQuery();
                connection.Close();
                this.Close();

            }


        }
    }
}
