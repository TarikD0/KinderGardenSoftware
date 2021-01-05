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
using finaltry.Forms;
using System.CodeDom.Compiler;
using finaltry.Forms.Student;

namespace finaltry
{
    public partial class DisplayExtraCur : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
        string query;
        SqlCommand command;
        SqlDataAdapter sda;
        DataTable table;
        string seleclass;
        public DisplayExtraCur()
        {
            selectclass selectclass = new selectclass();
            selectclass.ShowDialog();
            seleclass = selectclass.finalchoice;
          
            InitializeComponent();
            srchData("");
            Console.WriteLine(seleclass);
            Console.WriteLine(selectclass.finalchoice);
        }
        public static DataTable DataTable = new DataTable();
        public static string ActivityName = "";
        public static string classname;
        public static string ActivityID;
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            var senderGrid = (DataGridView)sender;




            if(Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[1].Value).Trim() == "")
            {
             
            }
            else
            {
        
                query = "SELECT StudentD FROM ActivityStudentList WHERE ActivityID = " + senderGrid.Rows[e.RowIndex].Cells[1].Value+" AND Class = '" +seleclass+"'";
                command = new SqlCommand(query, connection);
                sda = new SqlDataAdapter(command);
                table = new DataTable();
                sda.Fill(table);
                
                int i = 0;
              
                   ActivityName = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[2].Value);
                    foreach (var row in table.Rows)
                    {
                        string temp = Convert.ToString(table.Rows[i].ItemArray[0]);
                        string query2 = "SELECT StudentName FROM StudentList WHERE StudentID = " + temp + "";
                        SqlCommand command2 = new SqlCommand(query2, connection);
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command2);
                        sqlDataAdapter.Fill(DataTable);
                                        
                        i = i + 1;
                    }
                classname = selectclass.finalchoice;
                ActivityID = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[1].Value);
                    ShowActivityClass showActivityClass = new ShowActivityClass();
                    showActivityClass.ShowDialog();
                    srchData("");
                
              
           
             
            }

        }
        public void srchData(string DataToSearch)
        {
            query = "SELECT ExtraCurID, ActivityName, Price From ActivitiesTable WHERE Class ='"+ seleclass + "' AND ActivityName Like '%" + DataToSearch + "%'";
            command = new SqlCommand(query, connection);
            sda = new SqlDataAdapter(command);
            table = new DataTable();
            sda.Fill(table);
           
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            srchData(SearchTextBox.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            userinput userinput = new userinput();
            userinput.ShowDialog();
            if(userinput.userchoice == "" || userinput.userchoice == null)
            {

            }
            else
            {
                connection.Open();
                query = "DELETE From ActivitiesTable WHERE ExtraCurID = " + userinput.userchoice + "";
                command = new SqlCommand(query, connection);
                sda = new SqlDataAdapter(command);
                sda.SelectCommand.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                string query2 = "Delete From ActivityStudentList WHERE ActivityID = " + userinput.userchoice + "";
                SqlCommand command2 = new SqlCommand(query2, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command2);
                sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                connection.Close();

            }
            srchData("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddActivity addActivity = new AddActivity();
            addActivity.ShowDialog();
            srchData("");
        }
    }
}
