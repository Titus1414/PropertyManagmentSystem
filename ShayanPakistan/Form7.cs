using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;

namespace ShayanPakistan
{
    public partial class Form7 : Form
    {
        string des;
        public Form7(string a)
        {
            InitializeComponent();
            des = a;
            this.Text = DateTime.Today.ToString("MMMM/dd/yyyy,dddd");
            DataLoad();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            DataLoad();


        }

        private void DataLoad()
        {
            string query = "SELECT        Staff_Name, Designation, Department FROM Propertica_Staff_info WHERE((Department = '" + des + "')) AND( (Status = 'Probition')OR (Status = 'Regular')OR (Status = 'Trial')OR (Status = 'Permanent'))";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();






            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 130;
            dataGridView1.Columns[3].Width = 130;


            label1.Text = "Total Entries =" + dataGridView1.Rows.Count;

        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
