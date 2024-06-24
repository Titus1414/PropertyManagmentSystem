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
using System.Globalization;
using System.Web;

namespace ShayanPakistan
{
    public partial class Attendence_Record_Monthly : Form
    {
        string nam;
        int f;
        int A;
        int C;
        string Statuses;
        string slry1;
        string incre;
        DateTime increDate;
        DateTime AssDate;
        int dprfn;
        int insts;
        public static int Eid;
        public static string Emname;
        string fthName;
        string imggs = "";
        public Attendence_Record_Monthly(string name, string salary, string desig, string dep, int fine, int Appr, int Comp, string status, string inc, string form, int DPRFine, int Insntv,int id)
        {
            //this.TopMost = true;
            Statuses = status;
            nam = name;
            f = fine;
            A = Appr;
            C = Comp;
            slry1 = salary;
            incre = inc;
            Eid = id;
            InitializeComponent();
            var sdfsd = Attendence.lblDateForAtt;
            loadpics();
            if (form == "Attendence_Record")
            {
                label2.Text = sdfsd;
            }
            else if (form != "Attendence_Record")
            {
                label2.Text = form;
            }
            string query = "select IncrementDate,Fathers_Name from Propertica_Staff_info where Staff_Name = '" + name + "' and Designation = '" + desig + "' and Department = '" + dep + "' and Id = "+Eid+" ";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader read = command.ExecuteReader();
            read.Read();
            int slry = Convert.ToInt32(salary);
            DateTime dtn = DateTime.Now.Date;
            DateTime date = Convert.ToDateTime(sdfsd);
            DateTime dt;
            var sdf = read[0].ToString();
            fthName = read[1].ToString();
            if (sdf != " No Increment " && sdf != "Nill" && sdf != "")
            {
                dt = Convert.ToDateTime(read[0]);
                increDate = dt;
                if (dtn == date)
                {
                    if (inc != "")
                    {
                        if (dt <= dtn)
                        {
                            slry = (Convert.ToInt32(salary)) + (Convert.ToInt32(inc == "" ? "0" : inc));
                        }
                    }
                }
            }

            label1.Text = name;
            label13.Text = desig;
            label14.Text = dep;
            label19.Text = status;
            if (incre != null && incre != "Nill" && incre != "NIll")
            {
                if (increDate <= date)
                {
                    slry = (Convert.ToInt32(slry1)) + (Convert.ToInt32(incre == "" ? "0" : incre));
                }
            }
            textBox6.Text = slry.ToString();
            textBox25.Text = fine.ToString();
            textBox1.Text = Appr.ToString();
            textBox24.Text = Comp.ToString();
            textBox8.Text = DPRFine.ToString();
            textBox26.Text = Insntv.ToString();
            DPRFine = dprfn;
            insts = Insntv;
        }
        void loaddata(DateTime date)
        {
            AssDate = date;
            textBox2.Text = "0";
            textBox4.Text = "0";
            textBox3.Text = "0";
            int advnSlry = 0;
            var mnth12 = date.Month;

            if (mnth12 == 12 && nam == "Titus Zaman")
            {
                textBox15.Text = "5000";
                advnSlry = Convert.ToInt32(textBox15.Text);
            }
            else if (mnth12 == 12 && nam == "Muhammad Mohsin Raza")
            {
                textBox15.Text = "600";
                advnSlry = Convert.ToInt32(textBox15.Text);
            }
            else
            {
                textBox15.Text = "0";
                advnSlry = Convert.ToInt32(textBox15.Text);
            }

            DateTime dat1 = Convert.ToDateTime(label2.Text);
            DateTime dtPrev = dat1.AddMonths(-1);
            SqlConnection con = new SqlConnection(variables.cons);
            SqlCommand cmd = new SqlCommand("SELECT top 1 [Attendence Record].Date, Propertica_Staff_info.PICName FROM Propertica_Staff_info INNER JOIN[Attendence Record] ON Propertica_Staff_info.Staff_Name =[Attendence Record].Name Where  Month([Attendence Record].Date) ='" + dat1.Month.ToString() + "' AND year([Attendence Record].Date)   ='" + dat1.Year.ToString() + "' AND    Staff_Name = '" + nam + "' and Attendence not in ('---','') ORDER BY   cast([Attendence Record].Date  as datetime)  DESC ", con);
            SqlCommand cmd1 = new SqlCommand("select Paid from Salaries where Month(Date) = '" + dat1.Month.ToString() + "' AND year(Date)   ='" + dat1.Year.ToString() + "' And Eid = "+ Eid + "", con);
            SqlCommand cmd2 = new SqlCommand("select Balance from Salaries where Month(Date) = '" + dtPrev.Month.ToString() + "' AND year(Date)   ='" + dtPrev.Year.ToString() + "' And Eid = "+ Eid + "", con);
            con.Open();
            SqlDataReader DR1;
            DR1 = cmd.ExecuteReader();
            DateTime firstOfNextMonth = new DateTime(date.Year, date.Month, 1).AddMonths(1);
            DateTime lastOfThisMonth = firstOfNextMonth.AddDays(-1);
            DateTime dtOfLast = DateTime.Now;
            var lstmont = lastOfThisMonth.Month;
            var mnth = dtOfLast.Month;
            if (lstmont != mnth)
            {
                dtOfLast = lastOfThisMonth;
            }
            if (DR1.Read())
            {
                var sdrt = DR1.GetValue(0).ToString();
                imggs = DR1[1].ToString();
                //dtOfLast = Convert.ToDateTime(sdrt);
            }
            if (!string.IsNullOrEmpty(imggs))
            {
                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                string MyImg = path + "\\StaffImages\\" + imggs;
                pictureBox1.Image = Image.FromFile(@"" + MyImg + "");
            }
            DR1.Close();
            SqlDataReader DR2;
            DR2 = cmd1.ExecuteReader();
            if (DR2.Read())
            {
                var asfdwe = DR2.GetValue(0).ToString();
                if (!string.IsNullOrEmpty(asfdwe))
                {
                    button4.Text = "Paid";
                    button4.BackColor = Color.Green;
                }
                else
                {
                    button4.Text = "Pay";
                    button4.BackColor = Color.Red;
                }
            }
            else
            {
                button4.Text = "Pay";
                button4.BackColor = Color.Red;
            }
            DR2.Close();
            SqlDataReader DR3;
            DR3 = cmd2.ExecuteReader();
            if (DR3.Read())
            {
                textBox17.Text = DR3.GetValue(0).ToString();
            }
            DR3.Close();
            //SqlDataReader DR2 = cmd1.ExecuteReader();
            //SqlDataReader DR3 = cmd2.ExecuteReader();
            
            con.Close();
            SqlCommand cmdq = new SqlCommand("SELECT top 1 Propertica_Staff_info.ID,Propertica_Staff_info.Staff_Name FROM Propertica_Staff_info INNER JOIN[Attendence Record] ON Propertica_Staff_info.Staff_Name =[Attendence Record].Name Where  Month([Attendence Record].Date) ='" + dat1.Month.ToString() + "' AND year([Attendence Record].Date)   ='" + dat1.Year.ToString() + "' AND    Staff_Name = '" + nam + "' ORDER BY   cast([Attendence Record].Date  as datetime)  ASC ", con);
            con.Open();
            SqlDataReader DR1q = cmdq.ExecuteReader();
            var dd = "";
            var dd1 = "";
            if (DR1q.Read())
            {
                dd = DR1q.GetValue(0).ToString();
                dd1 = DR1q.GetValue(1).ToString();
                Emname = dd1;
                Eid = Convert.ToInt32(dd);
            }
            else {
                Eid = 0;
            }
            con.Close();
            //con.Open();
            string query = " SELECT Propertica_Staff_info.Department,Propertica_Staff_info.Staff_Name, Propertica_Staff_info.Designation, CONVERT(VARCHAR, CONVERT(DATETIME,[Attendence Record].Date), 106) as Date , [Attendence Record].Attendence FROM Propertica_Staff_info INNER JOIN[Attendence Record] ON Propertica_Staff_info.Staff_Name =[Attendence Record].Name Where  Month([Attendence Record].Date) ='" + dat1.Month.ToString() + "' AND year([Attendence Record].Date)   ='" + dat1.Year.ToString() + "' AND    Staff_Name = '" + nam + "' and Propertica_Staff_info.ID = "+Eid+" ORDER BY   cast([Attendence Record].Date  as datetime)  ASC ";// [Attendence Record].Date DESC; ";
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            con.Open();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Staff_Name"].Visible = false;
            dataGridView1.Columns["Department"].Visible = false;
            dataGridView1.Columns["Designation"].Visible = false;
            dataGridView1.Columns["Attendence"].Visible = false;
            dataGridView1.Columns["imgg"].DisplayIndex = 5;
            picload();
            DateTime dat = Convert.ToDateTime(label2.Text);
            string tdays = DateTime.DaysInMonth(Convert.ToInt32(dat.ToString("yyyy")), Convert.ToInt32(dat.ToString("MM"))).ToString();
            textBox5.Text = "" + tdays;
            int slry = Convert.ToInt32(slry1);
            if (incre != null && incre != "Nill" && incre != "NIll")
            {
                if (increDate <= date)
                {
                    slry = (Convert.ToInt32(slry1)) + (Convert.ToInt32(incre == "" ? "0" : incre));
                }
            }
            textBox6.Text = slry.ToString();
            int present = 0, absent = 0, late = 0, salayDays = 0, leave = 0, HalfDays = 0, oficialLeaves = 0 ;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() == "Present")
                {
                    present++;
                    salayDays++;
                }
                else if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() == "Absent")
                {
                    absent++;
                    salayDays++;
                }
                else if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() == "Late")
                {
                    late++;
                    salayDays++;
                }
                else if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() == "Leave")
                {
                    leave++;
                    salayDays++;
                }
                else if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() == "Half Day")
                {
                    HalfDays++;
                    salayDays++;
                }
                else if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() == "Official Leave")
                {
                    oficialLeaves++;
                }
            }
            var cnt = dataGridView1.Rows.Count;
            int drpf9 = Convert.ToInt32(textBox8.Text);

            //var sdfss = dataGridView1.Rows[dataGridView1.Rows.Count - Convert.ToInt32(cnt)].Cells["Date"].Value.ToString();

            if (Statuses != "Left")
            {
                DateTime startdate = dtOfLast;
                DateTime enddate = Convert.ToDateTime(dataGridView1.Rows[dataGridView1.Rows.Count - Convert.ToInt32(cnt)].Cells["Date"].Value.ToString());
                int TotalSundays = CountSundays(enddate, lastOfThisMonth);
                int sundays = CountSundays(enddate, startdate);
                int leaves =  oficialLeaves - sundays;
                salayDays = salayDays + sundays + leaves;
            }
            string qry = "select IsNull(Sum(Fine),0) as fine from AssigmentsForStaff where StaffName = '" + label1.Text + "' and Staus = 'Pending' and Month(CONVERT(Date, AssigmentDate,105)) = '" + AssDate.Month + "' ";
            DataTable dt2 = new DataTable();
            SqlDataAdapter ad2 = new SqlDataAdapter(qry, con);
            ad2.Fill(dt2);
            //con.Close();
            object value1 = null;
            foreach (DataRow row in dt2.Rows)
            {
                value1 = row["fine"];
            }
            var vl1 = value1.ToString();
            if (vl1 != "0")
            {
                drpf9 = Convert.ToInt32(dt2.Rows[0]["fine"]);
            }
            string qry1 = "select Sum(Insentive) as Insentive from AssigmentsForStaff where StaffName = '" + label1.Text + "' and Staus = 'Done' and DateCompleted <= DueDate and Month(CONVERT(Date, AssigmentDate,105)) = '" + AssDate.Month + "' ";
            DataTable dt21 = new DataTable();
            SqlDataAdapter ad21 = new SqlDataAdapter(qry1, con);
            ad21.Fill(dt21);
            con.Close();
            object value = null;
            foreach (DataRow row in dt21.Rows)
            {
                value = row["Insentive"];
            }
            var vl = value;
            if (vl != DBNull.Value)
            {
                insts = Convert.ToInt32(dt21.Rows[0]["Insentive"]);
            }
            else
            {
                insts = 0;
            }
            textBox26.Text = insts.ToString();
            textBox12.Text = leave.ToString();

            if (label19.Text == "Regular") 
            {
                if (leave > 0)
                {
                    leave--;
                }
                if (leave <= 0)
                {
                    leave = 0;
                }
            }
            else
            {
            }

            

            textBox2.Text = "" + present;
            textBox4.Text = "" + absent;
            textBox3.Text = "" + late;
            textBox14.Text = "" + HalfDays;
            textBox7.Text = (Convert.ToInt32(textBox6.Text.ToString()) / Convert.ToInt32(tdays)).ToString();

            double total = 0;
            int Lates = late / 3;

            double half = ((double)HalfDays / (double)2);
            double FinalSdays = (salayDays) - (half + leave + Lates + (absent * 2));
            textBox11.Text = FinalSdays.ToString();
            total = (Convert.ToDouble(textBox6.Text) * (double)FinalSdays) / (Convert.ToDouble(textBox5.Text));
            richTextBox1.Text = "R.S: " + (((int)total + A + C + insts) - (f + drpf9) - advnSlry).ToString();

            present = absent = late = 0;
            total = 0.0;

            dataGridView1.ClearSelection();
        }
        private void Attendence_Record_Monthly_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            loaddata(date: dt);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //next month
            DateTime dt = Convert.ToDateTime(label2.Text).AddMonths(1);
            var fulldt = dt.ToLongDateString();
            label2.Text = fulldt;
            loaddata(date: dt);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            //previous month
            DateTime dt = Convert.ToDateTime(label2.Text).AddMonths(-1);
            var fulldt = dt.ToLongDateString();
            label2.Text = fulldt;
            loaddata(date: dt);
        }
        void picload()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() == "Present")
                {
                    Bitmap bmpPhoto = new Bitmap(getpic("Present"));
                    dataGridView1.Rows[i].Cells["imgg"].Value = bmpPhoto;
                }
                else if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() == "Absent")
                {
                    Bitmap bmpPhoto = new Bitmap(getpic("Absent"));
                    dataGridView1.Rows[i].Cells["imgg"].Value = bmpPhoto;
                }
                else if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() == "Half Day")
                {
                    Bitmap bmpPhoto = new Bitmap(getpic("Half Day"));
                    dataGridView1.Rows[i].Cells["imgg"].Value = bmpPhoto;
                }
                else if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() == "Late")
                {
                    Bitmap bmpPhoto = new Bitmap(getpic("Late"));
                    dataGridView1.Rows[i].Cells["imgg"].Value = bmpPhoto;
                }
                else if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() == "Leave")
                {
                    Bitmap bmpPhoto = new Bitmap(getpic("Leave"));
                    dataGridView1.Rows[i].Cells["imgg"].Value = bmpPhoto;
                }
                else if (dataGridView1.Rows[i].Cells["Attendence"].Value.ToString() == "Official Leave")
                {
                    Bitmap bmpPhoto = new Bitmap(getpic("Official Leave"));
                    dataGridView1.Rows[i].Cells["imgg"].Value = bmpPhoto;
                }
            }
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
            //HalfDay//Late
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
        void loadpics()
        {
            string query = "Select * From SoftawareIcons";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            PicGrid.DataSource = dt;
            con.Close();

        }
        int CountSundays(DateTime startDate, DateTime endDate)
        {
            int SundayCount = 0;
            for (DateTime dt = startDate; dt < endDate; dt = dt.AddDays(1.0))
            {
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    SundayCount++;
                }
            }

            return SundayCount;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
        }
        private void TextBox1_Click(object sender, EventArgs e)
        {
            GetAppreciation gf = new GetAppreciation();
            gf.Show();
        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTimeNew = dateTimePicker1.Value;
            label2.Text = dateTimeNew.ToString();
            Attendence_Record_Monthly obj = new Attendence_Record_Monthly(name: nam.ToString(), salary: slry1.ToString(), desig: label13.Text.ToString(), dep: label14.Text.ToString(), fine: Convert.ToInt32(f), Appr: Convert.ToInt32(A), Comp: Convert.ToInt32(C), status: Statuses.ToString(), inc: incre, form: label2.Text.ToString(), DPRFine: dprfn, Insntv: insts,id:Eid);
            obj.Show();
            this.TopMost = true;
        }
        private void TextBox8_Click(object sender, EventArgs e)
        {
            string nm = label1.Text.ToString();
            string des = label13.Text.ToString();
            AssignmentsForStaff obj = new AssignmentsForStaff(nm, des);
            obj.Show();
        }
        private void TextBox25_Click(object sender, EventArgs e)
        {
            GetFine gf = new GetFine();
            gf.Show();
        }
        private void TextBox25_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBox24_Click(object sender, EventArgs e)
        {
            GetCompensation sdf = new GetCompensation();
            sdf.Show();
        }
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            var mnth = Convert.ToDateTime(label2.Text).ToString("MMMM yyy");


            int x = 100, y = 100, a = 50; //start position
            string apppath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            //Image myImage = ImageHelper.LoadFromAspNetUrl("~/Images/shayan.png");
            //E:\SVN\Titus\ShayanPakistan\ShayanPakistan\Images\ShayanPakistan
            System.Drawing.Image img = System.Drawing.Image.FromFile("E:\\SVN\\Titus\\ShayanPakistan\\ShayanPakistan\\Images\\shayan.png");
            Bitmap dst = new Bitmap(100, 80);
            e.Graphics.DrawImage(img, 20,20, dst.Width, dst.Height);

            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string MyImg = path + "\\StaffImages\\" + imggs;
            //pictureBox1.Image = Image.FromFile(@"" + MyImg + "");
            //MemoryStream ms = new MemoryStream(imggs);
            Image returnImage = Image.FromFile(MyImg);
            Bitmap dst1 = new Bitmap(150, 180);
            e.Graphics.DrawImage(returnImage, 650, 130, dst1.Width, dst1.Height);
            ////////////////////////after Break

            //Image newImage = Image.FromFile(HttpContext.Current.Server.MapPath(@"~/Images/shayan.png"));
            //newImage = System.IO.Path.Combine(apppath, "");
            //int width = 80, height = 50;
            //int ix = x, iy = y; //image position
            //e.Graphics.DrawImage(newImage, ix, iy, width, height);

            //x += 0; //left align texts with logo image
            //y += height + 30; //some space below logo

            var header = new Font("Calibri", 21, FontStyle.Bold);
            int hdy = (int)header.GetHeight(e.Graphics); //30; //line height spacing

            var fnt = new Font("Times new Roman", 14, FontStyle.Bold);
            int dy = (int)fnt.GetHeight(e.Graphics);
            
            //label2//Month
            e.Graphics.DrawString("Staff Salary of " + mnth, new Font("Times new Roman", 16, FontStyle.Bold), Brushes.Black, new PointF(300, 80)); y += hdy;
            //e.Graphics.DrawString("Shayan Pakistan", new Font("Times new Roman", 18, FontStyle.Bold), Brushes.Blue, new PointF(650, 70)); y += hdy;
            e.Graphics.DrawString("Name : ", fnt, Brushes.Black, new PointF(20, 170));// y += dy;
            e.Graphics.DrawString(label1.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(170, 170)); y += dy;//Name
            e.Graphics.DrawString("Father's Name : ", fnt, Brushes.Black, new PointF(20, 195));// y += dy;
            e.Graphics.DrawString(fthName, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(170, 195)); y += dy;//Name
            e.Graphics.DrawString("Department : ", fnt, Brushes.Black, new PointF(20, 220));// y += dy;
            e.Graphics.DrawString(label14.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(170, 220)); y += dy;//Name
            e.Graphics.DrawString("Designation : ", fnt, Brushes.Black, new PointF(20, 245));// y += dy;
            e.Graphics.DrawString(label13.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(170, 245)); y += dy;//Name
            e.Graphics.DrawString("Job Status : ", fnt, Brushes.Black, new PointF(20, 270));// y += dy;
            e.Graphics.DrawString(label19.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Red, new PointF(170, 270)); y += dy;//Name

            e.Graphics.DrawString("Salary Information", fnt, Brushes.Black, new PointF(350, 320));// y += dy;

            e.Graphics.DrawString("Basic Salary : ", fnt, Brushes.Black, new PointF(80, 370));// y += dy;
            e.Graphics.DrawString(textBox6.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(250, 370)); y += dy;//Name

            e.Graphics.DrawString("Salary Days : ", fnt, Brushes.Black, new PointF(500, 370));
            e.Graphics.DrawString(textBox11.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(670, 370)); y += dy;//Salary Days


            e.Graphics.DrawString("Per Day Salary : ", fnt, Brushes.Black, new PointF(80, 420));// y += dy;
            e.Graphics.DrawString(textBox7.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(250, 420)); y += dy;//Name

            e.Graphics.DrawString("Late Days : ", fnt, Brushes.Black, new PointF(500, 420));
            e.Graphics.DrawString(textBox3.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(670, 420)); y += dy;//Salary Days

            e.Graphics.DrawString("Leave Days : ", fnt, Brushes.Black, new PointF(80, 470));// y += dy;
            e.Graphics.DrawString(textBox12.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(250, 470)); y += dy;//Name

            e.Graphics.DrawString("Half Days : ", fnt, Brushes.Black, new PointF(500, 470));
            e.Graphics.DrawString(textBox14.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(670, 470)); y += dy;//Salary Days

            e.Graphics.DrawString("Absent Days : ", fnt, Brushes.Black, new PointF(80, 520));// y += dy;
            e.Graphics.DrawString(textBox4.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(250, 520)); y += dy;//Name

            e.Graphics.DrawString("Penalty : ", fnt, Brushes.Black, new PointF(500, 520));
            e.Graphics.DrawString(textBox25.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(670, 520)); y += dy;//Salary Days

            e.Graphics.DrawString("Appreciation : ", fnt, Brushes.Black, new PointF(80, 570));// y += dy;
            e.Graphics.DrawString(textBox1.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(250, 570)); y += dy;//Name

            e.Graphics.DrawString("Special Allowance : ", fnt, Brushes.Black, new PointF(500, 570));
            e.Graphics.DrawString(textBox24.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(670, 570)); y += dy;//Salary Days

            e.Graphics.DrawString("DPR Fine : ", fnt, Brushes.Black, new PointF(80, 620));// y += dy;
            e.Graphics.DrawString(textBox8.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(250, 620)); y += dy;//Name

            e.Graphics.DrawString("DPR Insentive : ", fnt, Brushes.Black, new PointF(500, 620));
            e.Graphics.DrawString(textBox26.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(670, 620)); y += dy;//Salary Days

            e.Graphics.DrawString("Over Time : ", fnt, Brushes.Black, new PointF(80, 670));// y += dy;
            e.Graphics.DrawString(textBox9.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(250, 670)); y += dy;//Name

            e.Graphics.DrawString("Advance Salary : ", fnt, Brushes.Black, new PointF(500, 670));
            e.Graphics.DrawString(textBox15.Text, new Font("Times new Roman", 14, FontStyle.Underline), Brushes.Black, new PointF(670, 670)); y += dy;//Salary Days

            e.Graphics.DrawString("Total Amount : ", fnt, Brushes.Black, new PointF(550, 750));
            e.Graphics.DrawString(richTextBox1.Text, new Font("Time new romans", 14, FontStyle.Underline), Brushes.Black, new PointF(700, 750));

            e.Graphics.DrawString("Previous Balance : ", fnt, Brushes.Black, new PointF(550, 770));
            e.Graphics.DrawString("0", new Font("Time new romans", 14, FontStyle.Underline), Brushes.Black, new PointF(787, 770));

            e.Graphics.DrawString("Deducatio : ", fnt, Brushes.Black, new PointF(550, 790));
            e.Graphics.DrawString("0", new Font("Time new romans", 14, FontStyle.Underline), Brushes.Black, new PointF(787, 790));

            e.Graphics.DrawString("Paying Amount : ", fnt, Brushes.Black, new PointF(550, 810));
            e.Graphics.DrawString("0", new Font("Time new romans", 14, FontStyle.Underline), Brushes.Black, new PointF(787, 810));

            e.Graphics.DrawString("Current Balance : ", fnt, Brushes.Black, new PointF(550, 830));
            e.Graphics.DrawString("0", new Font("Time new romans", 14, FontStyle.Underline), Brushes.Black, new PointF(787, 830));

            //e.Graphics.DrawString(" : ", fnt, Brushes.Black, new PointF(550, 850));
            //e.Graphics.DrawString("0", new Font("Time new romans", 14, FontStyle.Underline), Brushes.Black, new PointF(787, 850));

            e.Graphics.DrawString("---------------------------", fnt, Brushes.Black, new PointF(150, 800));
            e.Graphics.DrawString("Accountant", fnt, Brushes.Black, new PointF(185, 820));

            e.Graphics.DrawString("---------------------------", fnt, Brushes.Black, new PointF(150, 870));
            e.Graphics.DrawString("Signature CEO", fnt, Brushes.Black, new PointF(175, 890));

            e.Graphics.DrawString("---------------------------", fnt, Brushes.Black, new PointF(550, 900));
            e.Graphics.DrawString("Received By", fnt, Brushes.Black, new PointF(575, 920));

            e.Graphics.DrawString("Note : ", fnt, Brushes.Black, new PointF(20, 950));
            e.Graphics.DrawString("The salary amount mentioned in the monthly salary statement, once signed by the employee shall be considered final.", new Font("Times new Roman", 12, FontStyle.Regular), Brushes.Black, new PointF(20, 980));
            e.Graphics.DrawString("No argument shall be acceptable over the amount received thereafter.", new Font("Times new Roman", 12, FontStyle.Regular), Brushes.Black, new PointF(20, 1010));
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;

            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private bool mouseDown;
        private Point lastLocation;
        private void Attendence_Record_Monthly_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void Attendence_Record_Monthly_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void Attendence_Record_Monthly_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        

        private void Button4_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary();
            salary.Show();
        }
    }
}
