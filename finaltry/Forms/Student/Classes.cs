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
            getlastupdate();
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
            if (e.ColumnIndex.Equals(0))
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



                        query = "DELETE From ActivityStudentList WHERE StudentID = " + senderGrid.Rows[e.RowIndex].Cells[1].Value + "";
                        command = new SqlCommand(query, connection);
                        sda = new SqlDataAdapter(command);
                        
                    searchData("");
                }
            }
            }
            else
            {

            }
        }
        public void getlastupdate()
        {
            string query13 = "SELECT DateTime From UpdatesTable WHERE Id = 1";
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");

            SqlCommand command2 = new SqlCommand(query13, connection);
            SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(command2);
            DataTable dataTable = new DataTable();
            sqlDataAdapter5.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                DateTime datetime = Convert.ToDateTime(dataTable.Rows[0].ItemArray[0]);
                label2.Text = Convert.ToString(datetime).Substring(0,10);
                Console.WriteLine(datetime);
            }
            else
            {
                Console.WriteLine("wait wattt");

            }
           }

        private void button2_Click(object sender, EventArgs e)
        {
           
            int studentidtemp;
            int studentBalancesss;
            DateTime regdate;
            foreach (DataGridViewRow a in dataGridView1.Rows)
            {
                if(a.Cells[1].Value != null)
                {
                   

               
                string temp2 = Convert.ToString(a.Cells[14].Value);
                string date = temp2.Substring(0, 10);
                string month = date.Substring(0, 2);
                string day = date.Substring(3, 2);
                string year = date.Substring(6,4);

                studentidtemp = Convert.ToInt32(a.Cells[1].Value);
                studentBalancesss = Convert.ToInt32(a.Cells[13].Value);
                regdate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            
                if (DateTime.Today.Subtract(regdate).Days >= 30)
                {
                        int totaldaysatschool = DateTime.Today.Subtract(regdate).Days;
                        if (label2.Text == null)
                        {
                            if((totaldaysatschool / 30 ) > 0)
                            {
                                int monthspasseed = totaldaysatschool / 30;

                                CalculateAmountotAdd(studentidtemp, monthspasseed);
                            }
                            string temp12 = Convert.ToString(DateTime.Today).Substring(0, 10);
                            query = "INSERT INTO UpdatesTable(Id, DateTime) VALUES (1, '" +temp12+"')";
                            connection.Open();
                            sda = new SqlDataAdapter(query, connection);
                            sda.SelectCommand.ExecuteNonQuery();
                            connection.Close();

                        }
                        else
                        {
                            string tempday = label2.Text.Substring(0, 2);
                            string tempmonth = label2.Text.Substring(3, 2);
                            string tempyear = label2.Text.Substring(6, 4);

                            DateTime lastupdated = new DateTime(Convert.ToInt32(tempyear), Convert.ToInt32(tempmonth), Convert.ToInt32(tempday));
                            int daysbetween = regdate.Subtract(lastupdated).Days;


                            int monthspassedreg = totaldaysatschool / 30;
                            int monthspassedlastupdate = daysbetween / 30;
                            int outstandingmonths = monthspassedreg - monthspassedlastupdate;
                            if (outstandingmonths > 0)
                            {
                                CalculateAmountotAdd(studentidtemp, outstandingmonths);
                            }
                        }

                    }
                else
                {
                    if(label2.Text == "")
                        {
                            SqlConnection connection4 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");

                            string temp12 = Convert.ToString(DateTime.Today).Substring(0, 10);
                            string query9 = "UPDATE UpdatesTable SET DateTime = '"+temp12+"' WHERE Id = 1";
                            connection4.Open();
                            SqlDataAdapter sda5 = new SqlDataAdapter(query9, connection4);
                            sda5.SelectCommand.ExecuteNonQuery();
                            connection4.Close();
                        }
                }
                }
                else
                {
                   
                }


            }

            label2.Text = Convert.ToString(DateTime.Today).Substring(0,10);
        }

        public void CalculateAmountotAdd(int studid, int noofmonths)
        {
            Console.WriteLine("WOOOOOOOWWW");
            query = "Select StudentClass, UsesBus, TakesLunch, Balance FROM StudentList WHERE StudentID = " + studid+"";
            command = new SqlCommand(query, connection);
            sda = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            foreach (DataRow a in dataTable.Rows)
            {
                Console.WriteLine("omgomgomg");
                int balance = 0;
                string classname = Convert.ToString(a.ItemArray[0]);
                bool bus = Convert.ToBoolean(a.ItemArray[1]);
                bool lunch = Convert.ToBoolean(a.ItemArray[2]);
                int balan = Convert.ToInt32(a.ItemArray[3]);

                if (bus)
                {
                    int price;
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
                    connection.Open();
                    string query = "SELECT ProductPrice FROM Prices WHERE ProductName = 'Busride'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                    var abc = sda.SelectCommand.ExecuteScalar();
                    price = Convert.ToInt32(abc);
                    connection.Close();
                    balance = balance + price;
                }
                if(lunch)
                {
                    int price;
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
                    connection.Open();
                    string query = "SELECT ProductPrice FROM Prices WHERE ProductName = 'Lunch'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                    var abc = sda.SelectCommand.ExecuteScalar();
                    price = Convert.ToInt32(abc);
                    connection.Close();
                    balance = balance + price;
                }

                int tempprice;
                SqlConnection connection2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
                connection2.Open();
                string query2 = "SELECT ClassPrice FROM ClassPriceTable WHERE ClassName = '"+classname+"'";
                SqlDataAdapter sda2 = new SqlDataAdapter(query2, connection2);
                var abcd = sda2.SelectCommand.ExecuteScalar();
                tempprice = Convert.ToInt32(abcd);
                connection2.Close();
                balance = balance + tempprice;


                query2 = "SELECT ActivityID FROM ActivityStudentList WHERE StudentD ='" +studid+"' AND Class = '" +classname+"'";
                SqlCommand sqlCommand = new SqlCommand(query2, connection2);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable1 = new DataTable();
                sqlDataAdapter.Fill(dataTable1);
                foreach(DataRow dt in dataTable1.Rows)
                {
                    if(dt.ItemArray[0] == null)
                    {
                        Console.WriteLine("sad day");
                    }
                    connection2.Open();
                   string query3 = "SELECT Price FROM ActivitiesTable WHERE ExtraCurID = '" +dt.ItemArray[0]+"'";
                    SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(query3, connection2);
                    var scal = sqlDataAdapter1.SelectCommand.ExecuteScalar();
                    connection2.Close();
                    int tempprice2 = Convert.ToInt32(scal);
                    balance = balance + tempprice2;
                }

                int balance2 = balance + balan;
                balance2 = balance2 * noofmonths;
                string query4 = "UPDATE StudentList SET Balance = "+balance2+", MonthlyPrice= "+balance+" WHERE StudentID = "+studid+"";
                connection2.Open();
                SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(query4, connection2);
                sqlDataAdapter2.SelectCommand.ExecuteNonQuery();
                connection2.Close();

                searchData("");
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
