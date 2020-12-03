using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finaltry.Forms.Activity
{
    public partial class AddStudentToActivity : Form
    {
        public AddStudentToActivity()
        {
            InitializeComponent();
            filldata();
        }
        public static string name;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[1].Value).Trim() == "")
            {

            }
            else
            {
                name = Convert.ToString(senderGrid.Rows[e.RowIndex].Cells[1].Value).Trim();
                this.Close();
            }
        }
        public void filldata()
        {
            dataGridView1.DataSource = ShowActivityClass.DataTable;
        }
    }

}
