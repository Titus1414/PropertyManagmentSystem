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
using System.IO;

namespace ShayanPakistan
{
    public partial class Form6 : Form
    {
        int n = 0;
        string imgloc = "";
        public static int emID;
        string dtaeMnt = DateTime.Now.Month.ToString();
        string dtaeyear = DateTime.Now.Year.ToString();

        public Form6()
        {
            InitializeComponent();
            this.TopMost = true;

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            button3.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            lbl_Dat.Text = DateTime.Now.ToString("dddd, MMMM dd , yyyy");
            loaddata();
            //DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            // string query= "SELECT Staff_Name AS[Name], Department, Designation, Date_of_Appointment AS [Date Of Appointment], Salary AS [Salary], Status, Duration FROM Propertica_Staff_info WHERE(Status = 'Probition')OR (Status = 'Regular')OR (Status = 'Trial')OR (Status = 'Permanent') order by  (Case Department  when 'HR' then 1 when 'Admin' then 2 when 'Accounts' then 3 when 'I.T' then 4 when 'Survey Department' then 5 when 'Legal Department'  then 6 when 'Building And Construcion' then 7 when 'Chairman Secretariate' then 8 when 'Junior Staff' then 9 when 'Business' then 10 else 100 END);";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            // con.Open();
            // DataTable dt = new DataTable();
            // SqlDataAdapter ad = new SqlDataAdapter(query, con);
            // ad.Fill(dt);
            // dataGridView1.DataSource = dt;

            // dataGridView1.Columns[1].Width = 170;
            // dataGridView1.Columns[3].Width = 140;
            // dataGridView1.Columns[4].Width = 170;
            // dataGridView1.Columns[7].Width = 170;
            // label1.Text = "Total Entries " + dataGridView1.RowCount;
            // salary();
            //Duration();
            // label8.Text = "Total Salyries=" + n.ToString();
            //dataGridView1.ClearSelection();
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
        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["S_no"].Value = (e.RowIndex + 1).ToString();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //button1.Visible = false;
            //dataGridView1.Visible = false;
            //label1.Visible = false;
            //label8.Visible = false;
            //button3.Visible = false;
            //button5.Visible = false;
            //button6.Visible = false;
            //button7.Visible = false;
            //button8.Visible = false;
            //button9.Visible = false;
            //groupBox1.Visible = true;

            Form3 obj = new Form3(null, null, null);
            obj.Show();

        }
        //private void Button2_Click(object sender, EventArgs e)
        //{
        //    this.TopMost = false;
        //    textBox9.Text = maskedTextBox1.Text;
        //    //save button
        //    if (comboBox4.Text == "")
        //    {
        //        MessageBox.Show("Please Fill All Information");

        //    }
        //    else if (comboBox4.Text == "No")
        //    {
        //        MessageBox.Show("Sorry You Are Not Eligible For The Job ");
        //    }

        //    if (textBox1.Text != "" && comboBox4.Text != "" && comboBox4.Text != "No")
        //    {
        //        byte[] img = null;
        //        try
        //        {
        //            FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
        //            BinaryReader br = new BinaryReader(fs);
        //            img = br.ReadBytes((int)fs.Length);
        //            string query = "INSERT INTO Propertica_Staff_info (Staff_Name, Designation, Department, Fathers_Name, Nic, Address, Mobile, Age, Date_of_Appointment, Salary, Status,Timing,Image) VALUES('" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "', '" + comboBox2.Text.Trim() + "', '" + textBox7.Text.Trim() + "', '" + textBox9.Text.Trim() + "', '" + textBox5.Text.Trim() + "', '" + textBox6.Text.Trim() + "', '" + textBox15.Text.Trim() + "', '" + dateTimePicker1.Text + "', '" + textBox14.Text.Trim() + "', '" + comboBox1.Text.Trim() + "', '" + comboBox2.Text.Trim() + "',@img)";
        //            //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
        //            SqlConnection con = new SqlConnection(variables.cons);
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand(query, con);
        //            cmd.Parameters.Add(new SqlParameter("@img", img));
        //            int x = cmd.ExecuteNonQuery();
        //            //SqlDataReader read;
        //            // read = cmd.ExecuteReader();
        //            con.Close();
        //            //textBox1.Text = textBox2.Text = comboBox2.Text = textBox7.Text = textBox9.Text = textBox5.Text = textBox6.Text = textBox15.Text = textBox14.Text = comboBox1.Text = "";
        //            button1.Visible = true;
        //            dataGridView1.Visible = true;
        //            label1.Visible = true;
        //            //groupBox1.Visible = false;
        //            MessageBox.Show(x.ToString() + " record(s) saved successfully ");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please Enter Name of the employ and other fields carefully. Thankyou!!!");
        //        // textBox1.Text = textBox2.Text = comboBox2.Text = textBox7.Text = textBox9.Text = textBox5.Text = textBox6.Text = textBox15.Text  = textBox14.Text = comboBox1.Text = "";
        //    }
        //    //try
        //    //{
        //    //    byte[] img = null;

        //    //    FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
        //    //    BinaryReader br = new BinaryReader(fs);
        //    //    img = br.ReadBytes((int)fs.Length);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.Message);
        //    //}
        //    loaddata();
        //}
        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string nm = row.Cells["ID"].Value.ToString();
                emID = Convert.ToInt32(nm);
            }
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //    string nm = row.Cells["Name"].Value.ToString();
            //    string days = row.Cells["Duration"].Value.ToString();
            //  string notice=  row.Cells["Notice"].Value.ToString();

            //    ////////////////////////////////////////////////////


            //    Form3 obj = new Form3(nm,days,notice);
            //    obj.Show();
            //    this.Close();



            //}
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            //  browse image for new Staff
            try
            {

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(* .jpg)|*.jpg|GIF Files (* .gif)| * .gif|All Files(*.*)|*.*";
                dlg.Title = "Select Employ Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    imgloc = dlg.FileName.ToString();
                    //pictureBox1.ImageLocation = imgloc;

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
        public void loaddata()
        {
            this.TopMost = false;
            //this.Text = "Staff Information" + DateTime.Now.ToString("dddd, MMMM dd , yyyy");
            
            string query = "SELECT Staff_Name AS[Name], Department, Designation, Date_of_Appointment AS [Date Of Appointment], Convert(int, Salary) + Convert(int,Replace(Isnull(Increment,0),'Nill',0)) AS [Salary], Status, Duration,Timing,Notice,ID FROM Propertica_Staff_info WHERE(Status = 'Probition')OR (Status = 'Regular') OR (Status = 'Permanent') OR (Month(Date_Given_For_Leaving) = "+ Convert.ToInt32(dtaeMnt) +" and year(Date_Given_For_Leaving) = "+ dtaeyear + ") order by  (Case Department  when 'HR' then 1 when 'Admin' then 2 when 'Accounts' then 3 when 'I.T' then 4 when 'Survey Department' then 5 when 'Legal Department'  then 6 when 'Building And Construcion' then 7 when 'Chairman Secretariate' then 8 when 'Junior Staff' then 9 when 'Business' then 10 else 100 END);";
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
            //Left
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells["Status"].Value.ToString() == "Left")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;

                }


            }

            label1.Text = "Total Entries " + dataGridView1.RowCount;

            salary();
            Duration();
            label8.Text = "Total salaries=" + n.ToString();


            dataGridView1.ClearSelection();
            con.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
        private void Button5_Click(object sender, EventArgs e)
        {
            var SelectedName = dataGridView1.SelectedCells[1].Value;
            var SelectedDesg = dataGridView1.SelectedCells[1].Value;
            AssignmentsForStaff obj = new AssignmentsForStaff(SelectedName.ToString(), SelectedDesg.ToString());
            obj.Show();
        }
        private void Button6_Click(object sender, EventArgs e)
        {
        }
        private void Button7_Click(object sender, EventArgs e)
        {
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            //int f = Convert.ToInt32(FineText.Text);
            try
            {
                Attendence attendence = new Attendence();
                attendence.Show();
                //Attendence_Record_Monthly obj = new Attendence_Record_Monthly(textBox1.Text, textBox7.Text, textBox3.Text, textBox4.Text, f, comboBox1.Text, textBox18.Text, "Attendence_Record");
                //obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            AddFineAppricationOrCompensation adfn = new AddFineAppricationOrCompensation();
            adfn.Show();
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
        private void Button10_Click(object sender, EventArgs e)
        {
            Seniority obj = new Seniority();
            obj.Show();
        }
        private void GroupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void Button11_Click(object sender, EventArgs e)
        {
            StaffLeft obj = new StaffLeft();
            obj.Show();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            StaffTrial staffTrial = new StaffTrial();
            staffTrial.Show();


        }

        private void Label18_Click(object sender, EventArgs e)
        {
            lbl_Dat.Text = Convert.ToDateTime(lbl_Dat.Text).AddMonths(-1).ToLongDateString();
            DateTime sdf = Convert.ToDateTime(lbl_Dat.Text);
            lbl_Dat.Text = sdf.ToString("dddd, MMMM dd , yyyy");
            dtaeMnt = sdf.Month.ToString();
            dtaeyear = sdf.Year.ToString();
            loaddata();
        }

        private void Label17_Click(object sender, EventArgs e)
        {
            lbl_Dat.Text = Convert.ToDateTime(lbl_Dat.Text).AddMonths(1).ToLongDateString();
            DateTime sdf = Convert.ToDateTime(lbl_Dat.Text);
            lbl_Dat.Text = sdf.ToString("dddd, MMMM dd , yyyy");
            dtaeMnt = sdf.Month.ToString();
            dtaeyear = sdf.Year.ToString();
            loaddata();
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
