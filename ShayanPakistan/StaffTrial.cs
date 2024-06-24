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
    public partial class StaffTrial : Form
    {
        int n = 0;
        public static int emID;
        public StaffTrial()
        {
            InitializeComponent();
        }

        private void StaffTrial_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        private void salary()
        {


            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {

                if (dataGridView1.Rows[i].Cells[5].Value == null)
                {
                    n = n + 0;

                }
                else
                {
                    n = n + Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                }



            }

        }
        private void Duration()
        {
            //DateTime olddate = Convert.ToDateTime(dataGridView1.Rows[1].Cells["Date Of Appointment"].Value).Date;
            //DateTime today = DateTime.Now;
            //TimeSpan difference = today.Subtract(olddate);
            //MessageBox.show(difference+" ----"+difference.Days+"-------"+difference.mon)
            //MessageBox.Show(years.ToString());
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
                //dataGridView1.Rows[i].Cells["Duration"].Value = years.ToString()+"Years||"+months.ToString()+ "MONTHS||"+days.ToString()+"Days" ;
                // MessageBox.Show("Years = "+ years.ToString()+ "MONTHS = " + months.ToString()+"Days" + days.ToString());
            }
        }
        public void loaddata()
        {
            //this.TopMost = false;
            //this.Text = "Staff Information" + DateTime.Now.ToString("dddd, MMMM dd , yyyy");
            string query = "SELECT Staff_Name AS[Name], Department, Designation, Date_of_Appointment AS [Date Of Appointment], Convert(int, Salary) + Convert(int,Replace(Isnull(Increment,0),'Nill',0)) AS [Salary], Status, Duration,Timing,Notice,ID FROM Propertica_Staff_info WHERE(Status = 'Trial') order by  (Case Department  when 'HR' then 1 when 'Admin' then 2 when 'Accounts' then 3 when 'I.T' then 4 when 'Survey Department' then 5 when 'Legal Department'  then 6 when 'Building And Construcion' then 7 when 'Chairman Secretariate' then 8 when 'Junior Staff' then 9 when 'Business' then 10 else 100 END);";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[3].Width = 140;
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[7].Width = 170;
            dataGridView1.Columns["Notice"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;
            label2.Text = dataGridView1.RowCount.ToString();

            salary();
            Duration();
            dataGridView1.ClearSelection();
        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string nm = row.Cells["Name"].Value.ToString();
                string days = row.Cells["Duration"].Value.ToString();
                string notice = row.Cells["Notice"].Value.ToString();
                string d = row.Cells["ID"].Value.ToString();
                emID = Convert.ToInt32(d);
                Form3 obj = new Form3(nm, days, notice);
                obj.Show();
                this.Close();
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string nm = row.Cells["ID"].Value.ToString();
                emID = Convert.ToInt32(nm);
            }
        }
    }
}
