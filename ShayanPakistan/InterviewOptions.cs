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
    public partial class InterviewOptions : Form
    {
        public InterviewOptions()
        {
            InitializeComponent();
        }

        private void InterviewOptions_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            try
            {
                string query = "SELECT        Options FROM Interview_Option";
                //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

                dataGridView1.Columns[1].Width = 190;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.TopMost = false;
            }
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string nm = row.Cells["Options"].Value.ToString();

                ////////////////////////////////////////////////////
                if (nm == "Applications")
                {
                    InterviewApplications obj = new InterviewApplications();
                    obj.Show();
                    //textBox1.Text = nm;
                }
                else if(nm== "Daily Interview Report")
                {
                    InterviewDailyReport obj = new InterviewDailyReport();
                    obj.Show();
                }


            }
        }
    }
}
