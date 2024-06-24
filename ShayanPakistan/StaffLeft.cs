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
    public partial class StaffLeft : Form
    {
        public StaffLeft()
        {
            InitializeComponent();
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StaffLeft_Load(object sender, EventArgs e)
        {
           // this.TopMost = true;
            this.Text = DateTime.Now.ToString("dddd, MMMM dd , yyyy");
            string query = "SELECT  Staff_Name, Designation, Department , Salary AS [Monthly Salary],Date_of_Appointment AS [Joining Date] ,Date_Given_For_Leaving AS [Leaving Date],LeaveTime ,Duration FROM Propertica_Staff_info  WHERE(Status = 'Left')  order by  CAST(Date_Given_For_Leaving AS datetime) DESC";//(Case Department  when 'HR' then 1 when 'Admin' then 2 when 'Accounts' then 3 when 'I.T' then 4 when 'Survey Department' then 5 when 'Legal Department'  then 6 when 'Building And Construcion' then 7 when 'Chairman Secretariate' then 8 when 'Junior Staff' then 9 when 'Business' then 10 else 100 END);";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            Duration();
            
            
             dataGridView1.Columns["LeaveTime"].Visible = false;
            dataGridView1.Columns["Duration"].Visible = false;
            //dataGridView1.Columns["Date_Given_For_Leaving"].Visible = false;

            dataGridView1.Columns["WorkDays"].DisplayIndex = 7;
            dataGridView1.Columns["WorkDays"].Width = 150;
           // dataGridView1.Columns["Joining Date"].Width = 150;

            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 150;

            label2.Text = "Entries "+dataGridView1.Rows.Count.ToString();

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView1.ClearSelection();
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }

        void Duration()
        {
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                try
                {
                    //MessageBox.Show("Start");

                    DateTime zeroTime = new DateTime(1, 1, 1);
                    DateTime olddate = new DateTime();
                    olddate = Convert.ToDateTime(dataGridView1.Rows[i].Cells["Joining Date"].Value).Date;

                    DateTime curdate = Convert.ToDateTime(dataGridView1.Rows[i].Cells["Leaving Date"].Value).Date;//
                    TimeSpan span = new TimeSpan();
                    span = curdate - olddate;




                    // because we start at year 1 for the Gregorian

                    //calendar, we must subtract a year here.
                    if (curdate >= olddate)
                    {

                        int years = (zeroTime + span).Year - 1;
                        int months = (zeroTime + span).Month - 1;
                        float days = (zeroTime + span).Day;
                        //int years =  zeroTime.Year - 1;
                        //int months = zeroTime.Month - 1;
                        //int days = zeroTime.Day;
                       






                        if (Convert.ToInt16(years.ToString()) > 0)
                        {
                            dataGridView1.Rows[i].Cells["WorkDays"].Value = "Years " + years.ToString() + " Months " + months.ToString() + " Days " + days.ToString();

                        }
                        else if ((Convert.ToInt16(years.ToString()) <= 0) && (Convert.ToInt16(months.ToString()) > 0))
                        {
                            dataGridView1.Rows[i].Cells["WorkDays"].Value = "Months " + months.ToString() + " Days " + days.ToString();

                        }
                        else if ((Convert.ToInt16(years.ToString()) <= 0) && (Convert.ToInt16(months.ToString()) <= 0) && (Convert.ToInt16(days.ToString()) > 0))
                        {
                            if (dataGridView1.Rows[i].Cells["LeaveTime"].Value.ToString() == "Before 1:00 PM")
                            {
                                days = days + 0.5f;



                            }
                            dataGridView1.Rows[i].Cells["WorkDays"].Value = "Days " + days.ToString();

                        }

                        else
                        {
                           

                            dataGridView1.Rows[i].Cells["WorkDays"].Value = "Today";
                        }
                    }
                    else
                    {

                      //  MessageBox.Show("Leaving Date Should Be Greater Or equal To Appointment Date");



                    }

                    //dataGridView1.Rows[i].Cells["Duration"].Value = years.ToString()+"Years||"+months.ToString()+ "MONTHS||"+days.ToString()+"Days" ;



                    // MessageBox.Show("Years = "+ years.ToString()+ "MONTHS = " + months.ToString()+"Days" + days.ToString());
                }
                catch(Exception )
                {



                }
            }
            changeFormat();
        }
        bool begindrag = false;
        int mousedownX = 0;
        int mousedownY = 0;

        private void StaffLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                begindrag = true;
                mousedownX = e.X;
                mousedownY = e.Y;

            }
        }

        private void StaffLeft_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                begindrag = false;
                

            }

        }

        private void StaffLeft_MouseMove(object sender, MouseEventArgs e)
        {
            Point temp = new Point();
            if (begindrag==true)
            {
               
                temp.X = this.Location.X + (e.X - mousedownX);
                temp.Y = this.Location.Y + (e.Y - mousedownY);
                this.Location = temp;
               


            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                string query = "SELECT  Staff_Name, Designation, Department , Salary AS [Monthly Salary],Date_of_Appointment AS [Joining Date] ,Date_Given_For_Leaving AS [Leaving Date] FROM Propertica_Staff_info  WHERE(Status = 'Left') AND  Staff_Name LIKE '%"+textBox1.Text+"%' order by  CAST(Date_Given_For_Leaving AS datetime) DESC";
                                                                                                                                                                                                                                                                                                      
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                Duration();
                // dataGridView1.Columns["Date_of_Appointment"].Visible = false;
                //dataGridView1.Columns["Date_Given_For_Leaving"].Visible = false;
                //dataGridView1.Columns["LeaveTime"].Visible = false;
                dataGridView1.Columns["WorkDays"].DisplayIndex = 7;
                dataGridView1.Columns["Joining Date"].Width = 150;

                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 150;

                label2.Text = "Entries " + dataGridView1.Rows.Count.ToString();

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridView1.ClearSelection();

            }
        }

        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Duration();
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string nm = row.Cells["Staff_Name"].Value.ToString();
                string days = row.Cells["Duration"].Value.ToString();

                Form3 obj = new Form3(nm, days,"Nothing");
                obj.Show();
            }
        }
        void changeFormat()
        {
            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //Date_of_Appointment AS [Joining Date] ,Date_Given_For_Leaving AS [Leaving Date]
                    DateTime joinD = Convert.ToDateTime(dataGridView1.Rows[i].Cells["Joining Date"].Value.ToString());
                    dataGridView1.Rows[i].Cells["Joining Date"].Value = joinD.ToString("d/M/yyyy");

                    DateTime LeaveD = Convert.ToDateTime(dataGridView1.Rows[i].Cells["Leaving Date"].Value.ToString());
                    dataGridView1.Rows[i].Cells["Leaving Date"].Value = LeaveD.ToString("d/M/yyyy");
                }
            }
            catch(Exception )
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
