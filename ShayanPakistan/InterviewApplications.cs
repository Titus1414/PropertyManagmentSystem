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
    public partial class InterviewApplications : Form
    {
        public InterviewApplications()
        {
            InitializeComponent();
        }

        private void InterviewApplications_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            label1.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

            loaddat();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //right click Date
            label1.Text = Convert.ToDateTime(label1.Text).AddDays(1).ToString("dddd, MMMM dd, yyyy");
            loaddat();

        }

        private void Button2_Click(object sender, EventArgs e)
        { //left click Date
            label1.Text = Convert.ToDateTime(label1.Text).AddDays(-1).ToString("dddd, MMMM dd, yyyy");
            loaddat();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //calender Date
            label1.Text = Convert.ToDateTime(dateTimePicker1.Text).ToString("dddd, MMMM dd, yyyy");
            loaddat();
        }






        void loaddat()
        {
            try
            {
                string query = "SELECT        Candidate_name AS [Name], Education, Job_Title AS[JOB], Mobile, Applying_Date AS [Applying Date], Source, Status ,Marks2 AS [Remarks] FROM Interview_Applications_data WHERE (Applying_Date = '" + Convert.ToDateTime(label1.Text).ToString("M/d/yyyy") + "')";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                label2.Text = dataGridView1.Rows.Count.ToString();
                //dataGridView1.Columns[1].Width = 190;
                filcombo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.TopMost = false;

            }

            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    if (this.dataGridView1.Rows[i].Cells["Status"].Value.ToString() == "Done")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;


                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.TopMost = false;
            }
            dataGridView1.ClearSelection();


        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            button3.Visible = false;
            button4.Visible = true;
            button6.Visible = false;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button6.Visible = false;
            groupBox1.Visible = false;
            button3.Visible = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && comboBox2.Text != "" && comboBox1.Text != "" && dateTimePicker2.Text != "")
                {
                    string query = "INSERT INTO Interview_Applications_data (Candidate_name, Education, Job_Title, Status, Applying_Date, Mobile, Source,Marks2) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + dateTimePicker2.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox4.Text + "')";
                    // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read;
                    read = cmd.ExecuteReader();

                    con.Close();

                    MessageBox.Show("Data Entered Successfully");
                }
                else
                {
                    MessageBox.Show("Enter Required Fields Thankyou");
                    this.TopMost = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.TopMost = false;

            }


            loaddat();

            groupBox1.Visible = false;
            button3.Visible = true;
        }







        void filcombo()
        {
            string query = "SELECT        Designation FROM Basic_Staff_Table";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader myread;
            try
            {

                con.Open();
                myread = cmd.ExecuteReader();
                while (myread.Read())
                {
                    if (myread.GetValue(0).ToString().Trim() != "")
                    {
                        comboBox1.Items.Add(myread.GetValue(0).ToString());
                    }

                }
                myread.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.TopMost = false;


            }

            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                button4.Visible = false;
                button6.Visible = true;
                groupBox1.Visible = true;
                button3.Visible = false;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string nm = row.Cells["Name"].Value.ToString();
                string jb = row.Cells["JOB"].Value.ToString();

                string query = "SELECT    Candidate_name, Education, Job_Title, Status, Applying_Date, Mobile, Source  FROM Interview_Applications_data WHERE (Candidate_name='" + nm + "') AND (Job_Title='" + jb + "')";
                //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                SqlConnection con = new SqlConnection(variables.cons);
                try
                {

                    con.Open();

                    SqlCommand command = new SqlCommand(query, con);
                    SqlDataReader read = command.ExecuteReader();
                    read.Read();
                    if (read.HasRows)
                    {

                        textBox1.Text = read[0].ToString();
                        textBox2.Text = read[1].ToString();
                        comboBox1.Text = read[2].ToString();
                        comboBox2.Text = read[3].ToString();
                        dateTimePicker2.Text = read[4].ToString();
                        textBox5.Text = read[5].ToString();
                        textBox6.Text = read[6].ToString();



                    }




                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.TopMost = false;
                }


            }





        }

        private void Button6_Click(object sender, EventArgs e)
        {
            //ok
            try
            {
                string query = "UPDATE       Interview_Applications_data SET Status = '"+comboBox2.Text+ "', Applying_Date='"+dateTimePicker2.Text+"' WHERE(Candidate_name = '" + textBox1.Text + "') AND(Job_Title = '" + comboBox1.Text + "')  AND(Mobile = '" + textBox5.Text + "')";
                if (textBox1.Text != "" && comboBox2.Text != "" && comboBox1.Text != "" && dateTimePicker2.Text != "")
                {

                    //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read;
                    read = cmd.ExecuteReader();

                    con.Close();

                    MessageBox.Show("Data update Successfully!!!");
                }
                else
                {
                    MessageBox.Show("Enter Required Fields Thankyou");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.TopMost = false;

            }




            groupBox1.Visible = false;
            button3.Visible = true;
            loaddat();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            //
           
                string query = "SELECT        Candidate_name AS [Name], Education, Job_Title AS[JOB], Mobile, Applying_Date AS [Applying Date], Source, Status FROM Interview_Applications_data WHERE        (Candidate_name  LIKE '%" + textBox3.Text + "%') OR (Education LIKE '%" + textBox3.Text + "%') OR (Job_Title LIKE '%" + textBox3.Text + "%') OR (Status  LIKE '%" + textBox3.Text + "%') OR (Source LIKE '%" + textBox3.Text + "%')";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                label2.Text = dataGridView1.Rows.Count.ToString();
                //dataGridView1.Columns[1].Width = 190;
                //filcombo();

            



        }

        private void TextBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT        Candidate_name AS [Name], Education, Job_Title AS[JOB], Mobile, Applying_Date AS [Applying Date], Source, Status FROM Interview_Applications_data WHERE  (Applying_Date = '" + Convert.ToDateTime(label1.Text).ToString("M/d/yyyy") + "') AND ((Candidate_name  LIKE '%" + textBox7.Text + "%')  OR (Education LIKE '%" + textBox7.Text + "%') OR (Job_Title LIKE '%" + textBox7.Text + "%') OR (Status  LIKE '%" + textBox7.Text + "%') OR (Source LIKE '%" + textBox7.Text + "%') )";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                label2.Text = dataGridView1.Rows.Count.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox7_MouseClick(object sender, MouseEventArgs e)
        {
            textBox7.Text = "";
        }
    }
}

    