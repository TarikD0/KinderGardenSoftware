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
using System.Text.RegularExpressions;
using finaltry.Forms.Student;

namespace finaltry
{
    public partial class AddStudent : Form
    {
       
        List<Activity> activities = new List<Activity>();
        string StudentClass;
        bool Lunch;
        bool TakesBus;
        bool addbutton;
        int prevclasprice = 0;
    
        DataGridViewButtonColumn EditButton = new DataGridViewButtonColumn();
        public AddStudent()
        {
            InitializeComponent();
            TodayTextBox.Text = "Registration Day: "+ Convert.ToString(DateTime.Today).Substring(0,10);
          
        }


        private void lyesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            int price;
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string query = "SELECT ProductPrice FROM Prices WHERE ProductName = 'Lunch'";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            var abc = sda.SelectCommand.ExecuteScalar();
            price = Convert.ToInt32(abc);
            connection.Close();

            if (lyesRadioButton.Checked)
            {
                Lunch = true;
                if (MonthlyPlanTextBox.Text == "")
                {
                    MonthlyPlanTextBox.Text = price.ToString();
                }
                else
                {
                    int temp = Convert.ToInt32(MonthlyPlanTextBox.Text);

                    MonthlyPlanTextBox.Text = Convert.ToString(temp + price);
                }
            }
            else
            {
                Lunch = false;
                int temp = Convert.ToInt32(MonthlyPlanTextBox.Text);
                MonthlyPlanTextBox.Text = Convert.ToString(temp - price);
            }
           
            
        }

 

        private void byesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            int price;
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string query = "SELECT ProductPrice FROM Prices WHERE ProductName = 'Busride'";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            var abc = sda.SelectCommand.ExecuteScalar();
            price = Convert.ToInt32(abc);
            connection.Close();

            if (byesRadioButton.Checked)
            {
                TakesBus = true;
                if (MonthlyPlanTextBox.Text == "")
                {
                    MonthlyPlanTextBox.Text = price.ToString();
                }
                else
                {
                    int temp = Convert.ToInt32(MonthlyPlanTextBox.Text);

                    MonthlyPlanTextBox.Text = Convert.ToString(temp + price);
                }
            }
            else
            {
                TakesBus = false;
                int temp = Convert.ToInt32(MonthlyPlanTextBox.Text);
                MonthlyPlanTextBox.Text = Convert.ToString(temp - price);
            }

        }

   
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            CalculateDiscount();
            Regex regex = new Regex("^[0-9]{10}");
            bool isValidPhone = regex.IsMatch(PhoneNumberTextBox.Text);
            bool isValidEmail;
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (!Regex.IsMatch(EmailTextBox.Text, pattern))
            {
                isValidEmail = false;
            }
            else
            {
                isValidEmail = true;
            }

            String messege = "";
            if (StudentIDTextBox.Text.Trim().Length == 0)
            {
                messege = messege + "Complete Student ID Form!\n";
            }
            else if (StudentNameTextBox.Text.Trim().Length == 0)
            {
                messege = messege + "Complete Student Name Form!\n";
            }
            else if (ParentNameTextBox.Text.Trim().Length == 0)
            {
                messege = messege + "Complete Parent Name Form!\n";
            }
            else if (PhoneNumberTextBox.Text.Trim().Length == 0)
            {
                
                messege = messege + "Complete Phone Number Form!\n";
            }
            else if(!isValidPhone)
            {
                messege = messege + "Wrong Phone Number!";
            }
            else if (EmailTextBox.Text.Trim().Length == 0)
            {
                messege = messege + "Complete Email Form!\n";
            }
            else if(!isValidEmail)
            {
                messege = messege + "Email is not Valid!";
            }
            else if(textBox3.Text.Trim().Length == 0)
            {
                messege = messege + "Select a Class!";
            }
            
            else if(!lnoRadioButton.Checked && !lyesRadioButton.Checked)
            {
                messege = messege + "Complete Lunch Form!\n";
            }
            else if(!byesRadioButton.Checked && !bnoRadioButton.Checked)
            {
                messege = messege + "Complete Bus Ride Form!\n";
            }
            else if(byesRadioButton.Checked && AddressTextBox.Text.Trim().Length == 0)
            {
                messege = messege + "Complete Address Form!\n";
            }


            if (messege.Length == 0)
            {

                int count = activities.Count;
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
                connection.Open();
                string query = "INSERT INTO StudentList (StudentID, StudentName,StudentSurname, StudentParentName, StudentParentSurname, ParentPhoneNumber, StudentClass, UsesBus , TakesLunch, ExtraCurActivitiesCount, MonthlyPrice, ParentEmail, Balance, RegDate) VALUES ('" + StudentIDTextBox.Text + "','" + StudentNameTextBox.Text + "','" + textBox1.Text + "','"+ ParentNameTextBox.Text + "','" + textBox2.Text +"','"+ PhoneNumberTextBox.Text + "','" + textBox3.Text + "','" + TakesBus + "','" + Lunch + "','" + count + "','" + Convert.ToInt32(MonthlyPlanTextBox.Text) + "','" + EmailTextBox.Text + "','"+Convert.ToInt32(MonthlyPlanTextBox.Text)+"', convert(date, '"+ Convert.ToString(DateTime.Today).Substring(0, 10) + "'))";
             
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.SelectCommand.ExecuteNonQuery();
                connection.Close();

                this.Close();
            }
            else
            {

                MessageBox.Show(messege, "Error!", MessageBoxButtons.OK); ;
            }
            addactivities();
        }
        public void addactivities()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            
            foreach(Activity a in activities)
            {
                connection.Open();
                string query3 = "SELECT ExtraCurID From ActivitiesTable WHERE ActivityName = " + a.getActivity + "";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query3, connection);
                DataTable table = new DataTable();
                sqlDataAdapter.Fill(table);
                Console.WriteLine(table.Rows[0].ItemArray[0]);
                string query4 = "INSERT INTO ActivityStudentList(StudentD, ActivityID, Class, StudentName, ActivityName) VALUES (" + StudentIDTextBox.Text + ","+table.Rows[0].ItemArray[0] +",'" +textBox3.Text+ "','" +StudentNameTextBox.Text+ "'," + a.getActivity+ ")";
                SqlDataAdapter sqldataadapter2 = new SqlDataAdapter(query4, connection);
                sqldataadapter2.SelectCommand.ExecuteNonQuery();
                connection.Close();
            }
          
            connection.Close();

        }
        public void CalculateDiscount()
        {
            if(discountTextBox.Text != "")
            {
                int temp = Convert.ToInt32(discountTextBox.Text);
                int main = Convert.ToInt32(MonthlyPlanTextBox.Text);
                int onepercent = main / 100;
                int remainder = main % 100; 
                int totaldiscount = onepercent * temp;
                int totaldiscount2 = (remainder * temp)/100;
                int finalprice = main - (totaldiscount+totaldiscount2);
                MonthlyPlanTextBox.Text = Convert.ToString(finalprice);
            }
        }
        public void getActivities(string a)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT ActivityName,Price From ActivitiesTable WHERE Class = '"+ a +"'";
            
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            sda.Fill(table);
           
            dataGridView1.DataSource = table;
            if(addbutton)
            {

            }
            else
            {
                EditButton.Name = "Add";
                EditButton.Text = "ADD";
                EditButton.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(EditButton);
                addbutton = true;
            }
          
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            var senderGrid = (DataGridView)sender;
            bool contains = false;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
        
                

                Activity activity = new Activity("'"+senderGrid.Rows[e.RowIndex].Cells[0].Value+"'",Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[1].Value) );
                foreach(var Activity in activities)
                {
                    if(Activity.getActivity == activity.getActivity)
                    {
                        contains = true;
                    }
                }
                if(contains == false)
                { 
                activities.Add(activity);
                listView1.Items.Clear();
                foreach (var Activity in activities)
                {
                    var row = new string[] { Activity.getActivity, Convert.ToString(Activity.money) };
                    var lvi = new ListViewItem(row);
                    lvi.Tag = Activity;
                    listView1.Items.Add(lvi);
                }
                }
                else
                {

                }
                if (contains == false)
                {

                    if (MonthlyPlanTextBox.Text.Trim().Length == 0)
                    {
                        MonthlyPlanTextBox.Text = Convert.ToString(activity.money);
                    }
                    else
                    {
                        int a = Convert.ToInt32(MonthlyPlanTextBox.Text);
                        int b = a + activity.money;
                        MonthlyPlanTextBox.Text = Convert.ToString(b);
                    }
                }
              

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = new string[] { listView1.SelectedItems[0].SubItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text };
                Console.WriteLine(selectedItem[0]);
                Console.WriteLine(selectedItem[1]);
                Activity activity = new Activity(selectedItem[0], Convert.ToInt32(selectedItem[1]));
                int a = Convert.ToInt32(MonthlyPlanTextBox.Text);
                int b = a - activity.money;
                MonthlyPlanTextBox.Text = Convert.ToString(b);
                if (selectedItem != null)
                {

                    activities.RemoveAll(r => r.getActivity == selectedItem[0]);
                   listView1.Items.Remove(listView1.SelectedItems[0]);
                    foreach(var ctivity in activities)
                    {
                        Console.WriteLine(ctivity.getActivity);
                    }
                }

            }
            catch(Exception ex)
            {

            }
        }

        private void ParentExists_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowParentList showParentList = new ShowParentList();
            showParentList.ShowDialog();
            
            if(ShowParentList.parentdata2.Count != 0)
            {
                ParentNameTextBox.Text = ShowParentList.parentdata2[0];
                textBox2.Text = ShowParentList.parentdata2[1];
                PhoneNumberTextBox.Text = ShowParentList.parentdata2[2];
                EmailTextBox.Text = ShowParentList.parentdata2[3];
                discountTextBox.Text = "5";
            }
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
           
            if(StudentNameTextBox.Text != "")
            {
               var result = MessageBox.Show("Are you sure you want to quit?", "EXIT",MessageBoxButtons.OKCancel);
                if(result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectclass selectclass = new selectclass();
            selectclass.ShowDialog();
            textBox3.Text = selectclass.finalchoice;
            getActivities(textBox3.Text);
            

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT ClassPrice From ClassPriceTable WHERE ClassName ='" + textBox3.Text + "'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            sda.Fill(table);
            if(table.Rows.Count != 0)
            {

           
            Console.WriteLine(table.Rows[0].ItemArray[0]);
            if (MonthlyPlanTextBox.Text != "")
            {
                int maintemp = Convert.ToInt32(MonthlyPlanTextBox.Text);
                maintemp = maintemp - prevclasprice;
                maintemp = maintemp + Convert.ToInt32(table.Rows[0].ItemArray[0]);
                prevclasprice = Convert.ToInt32(table.Rows[0].ItemArray[0]);
                MonthlyPlanTextBox.Text = Convert.ToString(maintemp);
            }
            else
            {
                MonthlyPlanTextBox.Text = Convert.ToString(table.Rows[0].ItemArray[0]);
                prevclasprice = Convert.ToInt32(table.Rows[0].ItemArray[0]);
            }
            }
            else
            {
                MessageBox.Show("Choose a Valid Class!", "Error!", MessageBoxButtons.OK);
            }
        }
    }
}
