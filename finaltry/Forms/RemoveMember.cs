﻿using System;
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
    public partial class RemoveMember : Form
    {
        public RemoveMember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tarik\source\repos\finaltry\loginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query;
            SqlDataAdapter sda;
            connection.Open();
            query = "DELETE From Login_Table WHERE LoginID = " + textBox1.Text + "";
            sda = new SqlDataAdapter(query, connection);
            sda.SelectCommand.ExecuteNonQuery();
            connection.Close();
            this.Close();
        }
    }
}
