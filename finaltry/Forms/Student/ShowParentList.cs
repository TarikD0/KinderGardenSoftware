using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finaltry
{
    public partial class ShowParentList : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
        string query;
        SqlCommand command;
        SqlDataAdapter sda;
        DataTable table;
   
        public ShowParentList()
        {
            InitializeComponent();
            search_Button("", "");
           
            
        }
        public static List<string> parentdata2 = new List<string>();
        
  

        public void search_Button(string texttosearch, string searchin)
        {
            if (searchin == "")
            {
                query = "SELECT StudentParentName, StudentParentSurname, ParentPhoneNumber, ParentEmail From StudentList WHERE StudentParentName Like '%" + "" + "%'";
            }
            else
            {
                query = "SELECT StudentParentName, StudentParentSurname, ParentPhoneNumber, ParentEmail From StudentList WHERE "+searchin+ " Like '%" + texttosearch + "%'";
            }
            command = new SqlCommand(query, connection);
            sda = new SqlDataAdapter(command);
            table = new DataTable();
            sda.Fill(table);
            dataGridView1.DataSource = table;
            Console.WriteLine(dataGridView1.DataSource.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchin;
            if (radioButton1.Checked)
            {
                searchin = "StudentParentName";
            }
            else if (radioButton2.Checked)
            {
                searchin = "ParentEmail";
            }
            else if (radioButton3.Checked)
            {
                searchin = "ParentPhoneNumber";
            }
            else
            {
                searchin = "";
            }

            search_Button(textBox1.Text, searchin);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            parentdata2.Clear();
            var senderGrid = (DataGridView)sender;

            string name = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[1].Value);
            string surname = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[2].Value);
            string phone = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[3].Value);
            string email = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[4].Value);
            
            parentdata2.Add(name);
            parentdata2.Add(surname);
            parentdata2.Add(phone);
            parentdata2.Add(email);
            NameTextBox.Text = name;
            textBox2.Text = surname;
            PhoneTextBox.Text = phone;
            EmailTextBox.Text = email;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(NameTextBox.Text != "")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Choose a parent!", "Error!", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
