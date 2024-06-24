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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sno"].Value = (e.RowIndex + 1).ToString();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Text =  DateTime.Now.ToString("dddd, MMMM dd , yyyy");


            string query = "SELECT  Staff_Name, Designation, Department FROM Propertica_Staff_info  WHERE(Status = 'Probition')OR (Status = 'Regular')OR (Status = 'Trial')OR (Status = 'Permanent') order by  (Case Department  when 'HR' then 1 when 'Admin' then 2 when 'Accounts' then 3 when 'I.T' then 4 when 'Survey Department' then 5 when 'Legal Department'  then 6 when 'Building And Construcion' then 7 when 'Chairman Secretariate' then 8 when 'Junior Staff' then 9 when 'Business' then 10 else 100 END);";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();



            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;

           // label1.Text = "Total Entries "+
        }
    }
}
