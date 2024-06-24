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
    public partial class AddNewDept : Form
    {
        public AddNewDept()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Shayan_Department   (Departments,Division) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read;
            read = cmd.ExecuteReader();
            con.Close();

            MessageBox.Show("Record Was Saved Successfully");
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
