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

namespace ShayanPakistan
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
         
        
        private void Button1_Click(object sender, EventArgs e)
        {
            int id;
            id = Attendence_Record_Monthly.Eid;
            label1.Text = Attendence_Record_Monthly.Emname;

            DateTime dateTime = Convert.ToDateTime(dateTimePicker1.Text);

            var query = "Insert into Salaries values ("+ id +",'"+ dateTime  + "',"+textBox1.Text+","+textBox2.Text+")";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read;
            read = cmd.ExecuteReader();
            con.Close();

            MessageBox.Show("Record Saved Successfully");
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
