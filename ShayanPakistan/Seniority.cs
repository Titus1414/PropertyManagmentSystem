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
    public partial class Seniority : Form
    {
        public Seniority()
        {
            InitializeComponent();
        }

        private void Seniority_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Text = DateTime.Now.ToString("dddd, MMMM dd , yyyy");

            string query = "SELECT Staff_Name AS[Name], Department, Designation, Date_of_Appointment AS [Date Of Appointment], Salary AS [Salary], Status, Duration,Timing,Notice FROM Propertica_Staff_info  WHERE(Status = 'Probition')OR (Status = 'Regular')OR (Status = 'Trial')OR (Status = 'Permanent') AND (IsDate(Date_of_Appointment) = 1)  ;";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[3].Width = 140;
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[7].Width = 170;
            dataGridView1.Columns["Notice"].Visible = false;
            Duration();
            dataGridView1.ClearSelection();
        }

        private void Duration()
        {
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                DateTime zeroTime = new DateTime(01, 01, 01);
                DateTime olddate = new DateTime();
                olddate = Convert.ToDateTime(dataGridView1.Rows[i].Cells["Date Of Appointment"].Value).Date;
                DateTime curdate = DateTime.Now;
                TimeSpan span = new TimeSpan();
                span = curdate - olddate;
                int years = (zeroTime + span).Year - 1;
                int months = (zeroTime + span).Month - 1;
                int days = (zeroTime + span).Day;

                if (Convert.ToInt16(years.ToString()) > 0)
                {
                    dataGridView1.Rows[i].Cells["Duration"].Value = "Years " + years.ToString() + " Months " + months.ToString() + " Days " + days.ToString();

                }
                else if ((Convert.ToInt16(years.ToString()) <= 0) && (Convert.ToInt16(months.ToString()) > 0))
                {
                    dataGridView1.Rows[i].Cells["Duration"].Value = "Months " + months.ToString() + " Days " + days.ToString();
                }
                else if ((Convert.ToInt16(years.ToString()) <= 0) && (Convert.ToInt16(months.ToString()) <= 0) && (Convert.ToInt16(days.ToString()) > 0))
                {
                    dataGridView1.Rows[i].Cells["Duration"].Value = "Days " + days.ToString();
                }
                else
                {
                    dataGridView1.Rows[i].Cells["Duration"].Value = "Today";
                }
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
