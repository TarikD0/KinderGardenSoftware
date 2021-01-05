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


namespace finaltry.Forms
{
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MemberIDTextBox.Text.Trim() != "" && MemberNameTextBox.Text.Trim() !="" && (radioButton1.Checked || radioButton2.Checked))
            {
                bool temp = false;
                
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
                string query;
                SqlDataAdapter sda;
                connection.Open();
                if(radioButton1.Checked)
                {
                    temp = true;

                }
                else
                {
                    temp = false;
                }

                query = "INSERT INTO Login_Table(LoginID, UserName, Password, isAdmin) VALUES ('" + MemberIDTextBox.Text + "','" + MemberNameTextBox.Text + "','" + textBox1.Text + "','" + Convert.ToString(temp) + "')";
                sda = new SqlDataAdapter(query, connection);
                sda.SelectCommand.ExecuteNonQuery();
                connection.Close();
                this.Close();
            }
        }
    }
}
