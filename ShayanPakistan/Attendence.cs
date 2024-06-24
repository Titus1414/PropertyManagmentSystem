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
    public partial class Attendence : Form
    {
        public Attendence()
        {

            InitializeComponent();

        }
        public static string lblDateForAtt;
        private void Form3_Load(object sender, EventArgs e)
        {
            lbl_Dat.Text = DateTime.Now.ToLongDateString();
            lblDateForAtt = lbl_Dat.Text;
            loadpics();
            CreateAndLoad();
            //DateTime dat = Convert.ToDateTime(lbl_Dat.Text);
            //MessageBox.Show(dat.ToShortDateString());
            this.TopMost = false;
        }
        void CreateAndLoad()
        {
            SqlConnection con = new SqlConnection(variables.cons);
            DateTime dat = Convert.ToDateTime(lbl_Dat.Text);
            string query = "SELECT Name, Date, Attendence, Time,ID FROM[Attendence Record] WHERE(Date = '" + dat.ToShortDateString() + "')";




            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                // MessageBox.Show("Exists Already" + "    " + dt.Rows.Count);
                ShowToGrid();

            }
            else
            {
                //  MessageBox.Show("creating");
                Create();
                ShowToGrid();
            }





        }
        void Create()
        {
            SqlConnection con = new SqlConnection(variables.cons);

            string query = "SELECT ID,Staff_Name AS [Name],Designation,Timing,Department,Division,Date_of_Appointment FROM Propertica_Staff_info  WHERE        (Status != 'Left') ";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");

            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            con.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //   Name, Designation, Date, Attendence,Time
                int idfor = Convert.ToInt32(dt.Rows[i]["ID"]);
                string Name = dt.Rows[i]["Name"].ToString();
                string des = dt.Rows[i]["Designation"].ToString();
                string timings = dt.Rows[i]["Timing"].ToString();
                string dept = dt.Rows[i]["Department"].ToString();
                string divi = dt.Rows[i]["Division"].ToString();
                string dateOfapp = dt.Rows[i]["Date_of_Appointment"].ToString();
                DateTime dtAppoint = DateTime.Now;
                if (!string.IsNullOrEmpty(dateOfapp))
                {
                    dtAppoint = Convert.ToDateTime(dateOfapp);
                }

                DateTime dat = Convert.ToDateTime(lbl_Dat.Text);
                string dvsns = "";
                if (Name == "Muhammad Imran" || Name == "Ashraf" || Name == "Zeeshan Hussain")
                {
                    dvsns = "Junior Staff";
                }
                else
                {
                    dvsns = "Seniour Staff";
                }
                string query1 = "INSERT INTO [Attendence Record] (Name, Designation, Date, Attendence,Time,OfficeTimings,Department,Eid,Division,DateOFAppointment,JobCategory) VALUES('" + Name + "', '" + des + "', '" + dat.ToShortDateString() + "', '---','---','" + timings + "','" + dept + "'," + idfor + ",'" + divi + "','" + dtAppoint + "','" + dvsns + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader read;
                read = cmd.ExecuteReader();
                con.Close();
            }
            // MessageBox.Show("Done");
        }
        void ShowToGrid()
        {
            SqlConnection con = new SqlConnection(variables.cons);
            DateTime dat = Convert.ToDateTime(lbl_Dat.Text);
            string query = "SELECT Name, Attendence,Designation,Department,Division,JobCategory as [Job Category],Time,ID,OfficeTimings,DateOFAppointment FROM[Attendence Record] WHERE(Date = '" + dat.ToShortDateString() + "') order by JobCategory desc ,DateOFAppointment";

            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Attendence"].Visible = false;
            dataGridView1.Columns["OfficeTimings"].Visible = false;
            dataGridView1.Columns["Job Category"].Visible = false;
            dataGridView1.Columns["DateOFAppointment"].Visible = false;
            dataGridView1.Columns["Name"].Width = 150;
            dataGridView1.Columns["Division"].Width = 100;
            dataGridView1.Columns["Designation"].Width = 100;
            dataGridView1.Columns["Department"].Width = 110;
            dataGridView1.Columns["ImageColumn"].DisplayIndex = 7;

            dataGridView1.ClearSelection();
            label7.Text = "Employes = " + dataGridView1.Rows.Count.ToString();
            calAns();
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells["Name"].Value.ToString();

                if (row.Cells["Time"].Value.ToString() == "---")
                {
                    time_txt.Text = DateTime.Now.ToShortTimeString();
                }
                else
                {
                    time_txt.Text = row.Cells["Time"].Value.ToString();
                }
                txt_Temp2.Text = row.Cells["OfficeTimings"].Value.ToString();
                txt_temp3.Text = e.RowIndex.ToString();
                textBox1.Text = row.Cells["ID"].Value.ToString();
                Save_btn.Visible = true;
            }
            else
            {
                dataGridView1.ClearSelection();
            }
        }
        private void Save_btn_Click(object sender, EventArgs e)
        {
            string ans = GetAns(Convert.ToInt32(txt_temp3.Text));
            DateTime hlfD = DateTime.Now;
            if (time_txt.Text != "")
            {
                hlfD = Convert.ToDateTime(time_txt.Text);
            }
            string dtTime = DateTime.Now.ToString("12:00");
            DateTime tm = Convert.ToDateTime(dtTime);

            if (Stat_txt.Text == "Leave")
            {
                ans = "Leave";
                time_txt.Text = "";
            }
            else if (Stat_txt.Text == "Absent")
            {
                ans = "Absent";
                time_txt.Text = "";
            }
            else if (Stat_txt.Text == "Present")
            {
                ans = "Present";
                if (txt_Temp2.Text == "Free")
                {
                    time_txt.Text = "";
                }
            }
            else if (Stat_txt.Text == "Half Day")
            {
                ans = "Half Day";
            }
            //if (hlfD > tm)
            //{
            //    ans = "Half Day";
            //}
            SqlConnection con = new SqlConnection(variables.cons);
            string query = "UPDATE [Attendence Record] SET Attendence = '" + ans + "',Time = '" + time_txt.Text + "' WHERE  (ID ='" + textBox1.Text + "') ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read;
            read = cmd.ExecuteReader();
            con.Close();
            MessageBox.Show("Updated Successfully");
            ShowToGrid();
            textBox2.Text = "";
            Stat_txt.Text = "";
            time_txt.Text = "---";
        }
        private void Label2_Click(object sender, EventArgs e)
        {
            lbl_Dat.Text = Convert.ToDateTime(lbl_Dat.Text).AddDays(1).ToLongDateString();
            lblDateForAtt = lbl_Dat.Text;
            CreateAndLoad();
        }
        private void Label5_Click(object sender, EventArgs e)
        {
            lbl_Dat.Text = Convert.ToDateTime(lbl_Dat.Text).AddDays(-1).ToLongDateString();
            lblDateForAtt = lbl_Dat.Text;
            CreateAndLoad();
        }
        void loadpics()
        {
            string query = "Select* From SoftawareIcons";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            PicGrid.DataSource = dt;
            con.Close();
        }
        Image getpic(string ans)
        {
            Image imgs = null;
            if (ans == "Present")
            {

                byte[] img = (byte[])(PicGrid.Rows[0].Cells["Image"].Value);


                MemoryStream ms = new MemoryStream(img);
                imgs = Image.FromStream(ms);


            }
            else if (ans == "Official Leave")
            {

                byte[] img = (byte[])(PicGrid.Rows[1].Cells["Image"].Value);


                MemoryStream ms = new MemoryStream(img);
                imgs = Image.FromStream(ms);


            }
            else if (ans == "Late")
            {

                byte[] img = (byte[])(PicGrid.Rows[2].Cells["Image"].Value);


                MemoryStream ms = new MemoryStream(img);
                imgs = Image.FromStream(ms);


            }
            else if (ans == "Absent")
            {

                byte[] img = (byte[])(PicGrid.Rows[3].Cells["Image"].Value);


                MemoryStream ms = new MemoryStream(img);
                imgs = Image.FromStream(ms);


            }
            else if (ans == "Half Day")
            {

                byte[] img = (byte[])(PicGrid.Rows[4].Cells["Image"].Value);


                MemoryStream ms = new MemoryStream(img);
                imgs = Image.FromStream(ms);


            }
            else if (ans == "Leave")
            {

                byte[] img = (byte[])(PicGrid.Rows[5].Cells["Image"].Value);


                MemoryStream ms = new MemoryStream(img);
                imgs = Image.FromStream(ms);


            }

            else
            {


            }



            return imgs;
        }
        string calAns()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() != "---")
                {
                    dataGridView1.Rows[i].Cells["ImageColumn"].Value = getpic(dataGridView1.Rows[i].Cells["Attendence"].Value.ToString());
                }
            }
            return "";
        }
        string GetAns(int i)
        {
            //  9:00 AM to 6:00 PM
            string attendence = "---";
            if (txt_Temp2.Text == "9:00 AM to 6:00 PM" || txt_Temp2.Text == "9:00 AM to 5:00 PM")
            {
                try
                {
                    DateTime Latet = Convert.ToDateTime("9:30 AM");
                    DateTime halfdT = Convert.ToDateTime("12:05 PM");
                    DateTime times = Convert.ToDateTime(time_txt.Text);
                    if (times < Latet && times < halfdT)
                    {
                        attendence = "Present";
                    }
                    else if ((times > Latet && times < halfdT))
                    {
                        attendence = "Late";
                    }
                    else if ((times > Latet && times > halfdT))
                    {
                        attendence = "Half Day";
                    }
                    else
                    {
                        attendence = "Absent";
                    }
                }
                catch (Exception)
                {
                    attendence = "Absent";
                }
            }
            else if (txt_Temp2.Text == "8:00 AM to 6:00 PM")
            {
                try
                {
                    DateTime Latet = Convert.ToDateTime("8:01 AM");
                    DateTime halfdT = Convert.ToDateTime("12:15 PM");
                    DateTime times = Convert.ToDateTime(time_txt.Text);
                    if (times < Latet && times < halfdT)
                    {
                        attendence = "Present";
                    }
                    else if ((times > Latet && times < halfdT))
                    {
                        attendence = "Late";
                    }
                    else if ((times > Latet && times > halfdT))
                    {
                        attendence = "Half Day";
                    }
                    else
                    {
                        attendence = "Absent";
                    }
                }
                catch (Exception)
                {
                    attendence = "Absent";
                }
            }
            else if (txt_Temp2.Text == "4:00 PM to Onward")
            {
                try
                {
                    DateTime Latet = Convert.ToDateTime("4:15 PM");
                    // DateTime halfdT = Convert.ToDateTime(" PM");
                    DateTime times = Convert.ToDateTime(time_txt.Text);
                    if (times < Latet)
                    {
                        attendence = "Present";
                    }
                    else if (times > Latet)
                    {
                        attendence = "Late";
                    }
                    else
                    {
                        attendence = "Absent";
                    }
                }
                catch (Exception)
                {
                    attendence = "Absent";
                }
            }
            else if (txt_Temp2.Text == "Free")
            {
                try
                {
                    DateTime Latet = Convert.ToDateTime("11:58 PM");
                    // DateTime halfdT = Convert.ToDateTime(" PM");
                    DateTime times = Convert.ToDateTime(time_txt.Text);
                    if (times < Latet)
                    {
                        attendence = "Present";
                    }
                    else
                    {
                        attendence = "Absent";
                    }
                }
                catch (Exception)
                {
                    attendence = "Absent";
                }
            }
            // dataGridView1.Rows[i].Cells["Attendence"].Value = attendence;
            return attendence;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            time_txt.ReadOnly = false;
        }
        private void Label8_Click(object sender, EventArgs e)
        {
            MonthlyRecordMonth obj = new MonthlyRecordMonth();
            obj.Show();
        }
        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == Convert.ToChar(Keys.Pause))
            {
                MessageBox.Show("S Pressed");
                time_txt.Visible = !time_txt.Visible;



            }
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[2].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string a = Convert.ToString(selectedRow.Cells["Name"].Value);
            lblDateForAtt = lbl_Dat.Text;

            if (textBox2.Text != "")
            {

                var dtfn = Convert.ToDateTime(Attendence.lblDateForAtt).Month;

                string query1 = "Select IsNull(Sum(Fine),0) as Fine,IsNull(Sum(Appriciation),0) as Appriciation,IsNull(Sum(Compensation),0) as Compensation from ExtraPaidOrFine where EmpName = '" + a + "' and Month(Date) = '" + dtfn + "'";

                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt1 = new DataTable();
                SqlDataAdapter ad1 = new SqlDataAdapter(query1, con);
                ad1.Fill(dt1);


                int fin = Convert.ToInt32(dt1.Rows[0]["Fine"]);
                int Appr = Convert.ToInt32(dt1.Rows[0]["Appriciation"]);
                int Comp = Convert.ToInt32(dt1.Rows[0]["Compensation"]);


                string query = "Select ID,Designation,Department,Salary,Status,Increment,Staff_Name from Propertica_Staff_info where Staff_Name ='" + textBox2.Text + "' ";

                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);

                string des = dt.Rows[0]["Designation"].ToString();
                string dep = dt.Rows[0]["Department"].ToString();
                string sal = dt.Rows[0]["Salary"].ToString();
                string Eid = dt.Rows[0]["ID"].ToString();
                string stat = dt.Rows[0]["Status"].ToString();
                string inc = dt.Rows[0]["Increment"].ToString();

                string name = dt.Rows[0]["Staff_Name"].ToString();

                string qry = "select IsNull(Sum(Fine),0) as fine from AssigmentsForStaff where StaffName = '" + name + "' and Staus = 'Pending'";
                DataTable dt2 = new DataTable();
                SqlDataAdapter ad2 = new SqlDataAdapter(qry, con);
                ad2.Fill(dt2);
                con.Close();
                int dprfin = 0;
                object value1 = null;
                foreach (DataRow row in dt2.Rows)
                {
                    value1 = row["fine"];
                }
                var vl1 = value1.ToString();
                if (vl1 != "0")
                {
                    dprfin = Convert.ToInt32(dt2.Rows[0]["fine"]);
                }

                string qry1 = "select Sum(Insentive) as Insentive from AssigmentsForStaff where StaffName = '" + name + "' and Staus = 'Done' and DateCompleted <= DueDate ";
                DataTable dt21 = new DataTable();
                SqlDataAdapter ad21 = new SqlDataAdapter(qry1, con);
                ad21.Fill(dt21);
                con.Close();
                int dprinsentive = 0;
                object value = null;
                foreach (DataRow row in dt21.Rows)
                {
                    value = row["Insentive"];
                }
                var vl = value;
                if (vl != DBNull.Value)
                {
                    dprinsentive = Convert.ToInt32(dt21.Rows[0]["Insentive"]);
                }

                Attendence_Record_Monthly obj = new Attendence_Record_Monthly(textBox2.Text, sal, des, dep, fin, Appr, Comp, stat, inc, "Attendence_Record", dprfin, dprinsentive,Convert.ToInt32(Eid));

                obj.Show();
            }
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime datepicker = dateTimePicker1.Value;
            lbl_Dat.Text = datepicker.ToLongDateString();
            loadpics();
            CreateAndLoad();
        }
        private bool mouseDown;
        private Point lastLocation;
        private void Attendence_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        private void Attendence_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Attendence_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}