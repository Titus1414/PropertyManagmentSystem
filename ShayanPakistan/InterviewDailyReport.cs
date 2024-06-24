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

namespace ShayanPakistan
{
    public partial class InterviewDailyReport : Form
    {
        string nm = "";// row.Cells["Name"].Value.ToString();
        string jb = "";//row.Cells["JOB"].Value.ToString();
        string mb = "";//row.Cells["Mobile"].Value.ToString();
        string ed = "";//row.Cells["Education"].Value.ToString();
        public InterviewDailyReport()
        {
            InitializeComponent();
        }

        private void InterviewDailyReport_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            label1.Text = DateTime.Now.ToLongDateString();
            loaddata();
        }



















        void loaddata()
        {
            string query = "SELECT        Candidate_name AS [Name], Education, Job_Title AS[JOB], Mobile, Applying_Date AS [Applying Date], Source, Status , Marks AS [Remarks] FROM Interview_Applications_data WHERE (Applying_Date = '" + Convert.ToDateTime(label1.Text).ToString("M/d/yyyy") + "') AND (Status='Done')";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            // label2.Text = dataGridView1.Rows.Count.ToString();
            //dataGridView1.Columns[1].Width = 190;



            //try
            //{

            //    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //    {

            //        if (this.dataGridView1.Rows[i].Cells["Status"].Value.ToString() == "Done")
            //        {
            //            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(212, 175, 55);


            //        }




            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //}
            label2.Text = "Total Entries  " + dataGridView1.Rows.Count.ToString();
            dataGridView1.ClearSelection();

            if(dataGridView1.SelectedRows.Count>0)
            {
                button3.Visible = true;
                comboBox1.Visible = true;

            }
            else
            {
                button3.Visible = false;
                comboBox1.Visible = false;
            }


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //date next
            label1.Text = Convert.ToDateTime(label1.Text).AddDays(1).ToString("dddd, MMMM dd, yyyy");
            loaddata();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Text = Convert.ToDateTime(label1.Text).AddDays(-1).ToString("dddd, MMMM dd, yyyy");
            loaddata();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = Convert.ToDateTime(dateTimePicker1.Text).ToString("dddd, MMMM dd, yyyy");
            loaddata();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                 button3.Visible=true;
                comboBox1.Visible = true;

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                try
                {
                   nm = row.Cells["Name"].Value.ToString();
                   jb = row.Cells["JOB"].Value.ToString();
                    mb = row.Cells["Mobile"].Value.ToString();
                    ed = row.Cells["Education"].Value.ToString();

                   

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else
                {
                button3.Visible = false;
                comboBox1.Visible = false;



            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE       Interview_Applications_data SET Marks = '" + comboBox1.Text + "' WHERE(Candidate_name = '" + nm + "') AND(Job_Title = '" + jb + "') AND(Mobile = '" + mb + "') AND(Education = '" + ed + "')";

                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read;
                read = cmd.ExecuteReader();

                con.Close();
                loaddata();

                MessageBox.Show("Successful");
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
