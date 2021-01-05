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
namespace finaltry.Forms.Activity
{
    public partial class AddStudentToActivity : Form
    {
        public AddStudentToActivity()
        {
            InitializeComponent();
            filldata();
        }
        public static bool added;
        public static string name;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns.Count != 0)
            {

                if (e.ColumnIndex.Equals(0))
                {
                    added = true;
                    name = Convert.ToString(senderGrid.Rows[0].Cells[1].Value);
                    this.Close();
                }
            }
            else
            {
                
            }


        }
        public void filldata()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query;
            SqlCommand command;
            SqlDataAdapter sda;
            DataTable table = new DataTable();
            Console.WriteLine(DisplayExtraCur.classname);
            query = "SELECT StudentID FROM StudentList WHERE StudentClass = '"+ ShowActivityClass.testing +"' EXCEPT SELECT StudentD from ActivityStudentList WHERE ActivityID ="+ShowActivityClass.actid+"";
            command = new SqlCommand(query, connection);
            sda = new SqlDataAdapter(command);
            sda.Fill(table);
            Console.WriteLine(table.Rows.Count);
            int i = 0;
            DataTable dataTable = new DataTable();
            foreach (var row in table.Rows)
            {
                string query2 = "SELECT StudentName, StudentSurname From StudentList WHERE StudentID = " + table.Rows[i].ItemArray[0] + "";
                command = new SqlCommand(query2, connection);
                sda = new SqlDataAdapter(command);
                
                sda.Fill(dataTable);
                i = i + 1;
            }

            dataGridView1.DataSource = dataTable;
        }
    }

}
