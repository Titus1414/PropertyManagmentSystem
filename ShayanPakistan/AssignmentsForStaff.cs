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
using System.Globalization;


namespace ShayanPakistan
{
   
    public partial class AssignmentsForStaff : Form
    {
        //bool ck = false;
        string nam,desig;
        string id = "Null";
        int insentive = 0;
        //int ttlWorks = 0;
        //int doneWorks = 0;
        //int rs = 0;
        DataTable infoTable = new DataTable();
        //progress bar
        //double pbunit;
        //int pbwidth, pbhieght, pbcomplete;
        //Bitmap bmp;
        //Graphics g;
        public AssignmentsForStaff(string name,string des)
        {
            InitializeComponent();
            nam = name;
            desig = des;
            label1.Text = name;
            label2.Text = des;

            

        }
        private void AssignmentsForStaff_Load(object sender, EventArgs e)
        {

            label3.Text = DateTime.Now.ToString("dddd  MMMM dd , yyyy");

           


            loaddata();
           // dataGridView1.Columns["Status"].DisplayIndex = 0;
        }
        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }
        //void check ()
        //{
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        dataGridView1.Rows[i].Cells["Status"].Value = dataGridView1.Rows[i].Cells["Chk"].Value.ToString();
        //    }
        //    update1();
        //}
        private void Button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            button8.Visible = false;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
               
                    string query = "INSERT INTO AssigmentsForStaff (StaffName, Designation, Assignments, AssigmentDate, DueDate, Works, Remarks, Staus,DateCompleted) VALUES('" + nam + "', '" + desig + "', '" + richTextBox1.Text.Trim() + "', '" +Convert.ToDateTime(dateTimePicker2.Text).ToString("d/M/yyyy") + "', '" + Convert.ToDateTime(dateTimePicker1.Text).ToString("d/M/yyyy") + "', '" + textBox4.Text.Trim() + "', '" + textBox6.Text.Trim() + "', '" + comboBox1.Text.Trim() + "' , '" +Convert.ToDateTime(dateTimePicker2.Text).ToString("d/M/yyyy") + "')";
                    // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read;
                    read = cmd.ExecuteReader();

                    con.Close();
                MessageBox.Show("Saved Successfully");

                richTextBox1.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                richTextBox1.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";

            }
            
            loaddata();
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }
        private void Button4_Click_1(object sender, EventArgs e)
        {
            //  check();
            if (id != "Null")
            {
                deleteRow(id);  
                id = "Null";

            }

            //update1();
            //loaddata();
        }
        void update1()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)

                {

                     //MessageBox.Show("Start");

                    string query = "UPDATE       AssigmentsForStaff SET Works = '" + dataGridView1.Rows[i].Cells["Todays Work"].Value.ToString() + "', Assignments = '" + dataGridView1.Rows[i].Cells["Assignments"].Value.ToString() + "' WHERE(ID = '" + dataGridView1.Rows[i].Cells["ID"].Value.ToString() + "') AND (StaffName = '" + nam + "')";

                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read;
                    read = cmd.ExecuteReader();

                    con.Close();
                    
                }
                MessageBox.Show("Update Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        //void WorkCalculate()
        //{
        //    SqlConnection con = new SqlConnection(variables.cons);
        //    SqlCommand cmd = new SqlCommand("select Count(*) as TotalWorks from AssigmentsForStaff where StaffName = '" + label1.Text + "' and AssigmentDate = '" + label3.Text + "'", con);
        //    SqlCommand cmd1 = new SqlCommand("select Count(*) as DoneWorks from AssigmentsForStaff where StaffName = '" + label1.Text + "' and AssigmentDate = '" + label3.Text + "' and Staus = 'Done' ", con);
        //    con.Open();
        //    SqlDataReader DR = cmd.ExecuteReader();
        //    if (DR.Read())
        //    {
        //        ttlWorks = Convert.ToInt32(DR.GetValue(0));
        //    }
        //    con.Close();
        //    con.Open();
        //    SqlDataReader DR1 = cmd1.ExecuteReader();
            
        //    if (DR1.Read())
        //    {
        //        doneWorks = Convert.ToInt32(DR1.GetValue(0));
        //    }
        //    if (ttlWorks != 0)
        //    {
        //        rs = doneWorks / ttlWorks * 100;
        //    }
            
        //    con.Close();
        //}
        private void Button5_Click(object sender, EventArgs e)
        {
            //nextdate click
            label3.Text = Convert.ToDateTime(label3.Text).AddDays(1).ToString("dddd  MMMM dd , yyyy");
            loaddata();


        }
        private void Button6_Click(object sender, EventArgs e)
        {
            //previous Date Click
            label3.Text = Convert.ToDateTime(label3.Text).AddDays(-1).ToString("dddd  MMMM dd , yyyy");
            loaddata();
        }
        private void DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = label3.Text = Convert.ToDateTime(dateTimePicker3.Text).ToString("dddd  MMMM dd, yyyy");
            loaddata();
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                ////string nm = row.Cells[nam].Value.ToString();
                ////string de = row.Cells[desig].Value.ToString();

                //string id = row.Cells["ID"].Value.ToString();
                //string stat = row.Cells["Status"].Value.ToString();

                //if (stat != "Done")
                //{

                //    try
                //    {

                //        string query = "UPDATE       AssigmentsForStaff SET Staus = 'Done' WHERE(ID = '" + id + "') AND (StaffName = '" + nam + "')";

                //        SqlConnection con = new SqlConnection(variables.cons);
                //        con.Open();
                //        SqlCommand cmd = new SqlCommand(query, con);
                //        SqlDataReader read;
                //        read = cmd.ExecuteReader();

                //        con.Close();
                //        loaddata();
                //        MessageBox.Show("Updated Successfully");




                //    }

                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //}
                //else
                //{

                //    try
                //    {

                //        string query = "UPDATE       AssigmentsForStaff SET Staus = 'Pending' WHERE(ID = '" + id + "') AND (StaffName = '" + nam + "')";

                //        SqlConnection con = new SqlConnection(variables.cons);
                //        con.Open();
                //        SqlCommand cmd = new SqlCommand(query, con);
                //        SqlDataReader read;
                //        read = cmd.ExecuteReader();

                //        con.Close();
                //        loaddata();
                //        MessageBox.Show("Updated Successfully");




                //    }

                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }




                //}






            }
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            if (e.RowIndex>=0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                comboBox2.Visible = true;
                button4.Visible = true;
                button7.Visible = true;
                id =  row.Cells["ID"].Value.ToString();
                


            }
            else
            {
                button4.Visible = false;
                comboBox2.Visible = false;
                button7.Visible = false;

            }

            
            
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    customProgressBar();

            //}
            //catch (Exception ex)
            //{
            //    textBox2.Text = "0";
            //    customProgressBar();
            //}
        }
        void loaddata()
        {

            //int fine = 0;
            //WorkCalculate();
            loadInformation();

            string query = "SELECT    Assignments, AssigmentDate, DueDate, Works AS [Todays Work],  Staus AS [Status],ID,DateCompleted FROM AssigmentsForStaff WHERE ((StaffName = '" + nam+"') AND(Designation = '"+desig+ "')AND(DateCompleted = '" + Convert.ToDateTime(label3.Text).ToString("d/M/yyyy") + "')) OR ((Staus = 'Pending') AND ((StaffName = '" + nam + "')AND (Designation = '" + desig + "'))) ORDER BY AssigmentDate DESC";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;


            //dataGridView1.Columns["ID"].Width = 0;
            //dataGridView1.Columns["Status"].Width = -2;

            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["DateCompleted"].Visible = false;
           // dataGridView1.Columns["Status"].Visible = false;


            dataGridView1.ClearSelection();
            //ox2.Text = Convert.ToDateTime(label3.Text).ToString("M/d/yyyy");


            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{

            //        dataGridView1.Rows[i].Cells["Chk"].Value = dataGridView1.Rows[i].Cells["Status"].Value;




            //}

            //dataGridView1.Columns["Chk"].DisplayIndex = 6;
            //dataGridView1.Columns["Status"].DisplayIndex = 7;


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if( dataGridView1.Rows[i].Cells["Status"].Value.ToString()=="Done")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }

            dataGridView1.Columns["Assignments"].Width = 250;
            dataGridView1.Columns["Todays Work"].Width = 250;
          //  dataGridView1.Columns["Remarks"].Width = 330;
            dataGridView1.Columns["AssigmentDate"].Width = 110;
            dataGridView1.Columns["DueDate"].Width = 80;
            dataGridView1.Columns["Status"].Width = 55;
            // CultureInfo frC = new CultureInfo("fr-FR");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DateTime duedate = DateTime.ParseExact(dataGridView1.Rows[i].Cells["DueDate"].Value.ToString(), "d/M/yyyy", null);
               // MessageBox.Show((Convert.ToDateTime(DateTime.Now.Date.ToString("M/d/yyyy")) - duedate).TotalDays.ToString());
                if (((Convert.ToDateTime(DateTime.Now.Date.ToString("M/d/yyyy")) - duedate).TotalDays>0) && (dataGridView1.Rows[i].Cells["Status"].Value.ToString() != "Done"))          //((Convert.ToDateTime(DateTime.Now.Date.ToString("d/M/yyyy"))- (Convert.ToDateTime(    Convert.ToDateTime(dataGridView1.Rows[i].Cells["DueDate"].Value.ToString()).ToString("d/M/yyyy")))). TotalDays>=1 && dataGridView1.Rows[i].Cells["Status"].Value.ToString() != "Done")
                {
                    
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;//FromArgb(220, 20, 60);

                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
                dataGridView1.EnableHeadersVisualStyles = false;
            }

            calculatedays();
            calculatePerformance();
            fineCalculation();
            insentiveCalculation();

            dataGridView1.Columns["DaysGiven"].DisplayIndex = 5;
            dataGridView1.Columns["TotalDays"].DisplayIndex = 5; 

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            
           // customProgressBar();
            comboBox2.Visible = false;
            button4.Visible = false;
            button7.Visible = false;
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        void calculatedays()
        {
            int l = 0;
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["Status"].Value.ToString() != "Done")
                    {


                        l = i;
                        dataGridView1.Rows[i].Cells["DaysGiven"].Value = (DateTime.ParseExact(dataGridView1.Rows[i].Cells["DueDate"].Value.ToString(), "d/M/yyyy", null) - (DateTime.Now.Date)).TotalDays.ToString();
                        dataGridView1.Rows[i].Cells["TotalDays"].Value= ((DateTime.ParseExact(dataGridView1.Rows[i].Cells["DueDate"].Value.ToString(), "d/M/yyyy", null)) - (DateTime.ParseExact(dataGridView1.Rows[i].Cells["AssigmentDate"].Value.ToString(), "d/M/yyyy", null))).TotalDays.ToString();
                        //DateTime.ParseExact(dataGridView1.Rows[i].Cells["AssigmentDate"].Value.ToString(), "d/M/yyyy", null))
                        //if(dataGridView1.Rows[i].Cells["DaysGiven"].Value.ToString()=="0")
                        //{
                        //    dataGridView1.Rows[i].Cells["DaysGiven"].Value = "-1";
                        //}


                    }
                    else
                    {
                        if (dataGridView1.Rows[i].Cells["DateCompleted"].Value.ToString() != "")
                        {
                             dataGridView1.Rows[i].Cells["DaysGiven"].Value = ((DateTime.ParseExact(dataGridView1.Rows[i].Cells["DueDate"].Value.ToString(), "d/M/yyyy", null)) - (DateTime.ParseExact(dataGridView1.Rows[i].Cells["DateCompleted"].Value.ToString(), "d/M/yyyy", null))).TotalDays.ToString();
                            dataGridView1.Rows[i].Cells["TotalDays"].Value = ((DateTime.ParseExact(dataGridView1.Rows[i].Cells["DueDate"].Value.ToString(), "d/M/yyyy", null)) - (DateTime.ParseExact(dataGridView1.Rows[i].Cells["AssigmentDate"].Value.ToString(), "d/M/yyyy", null))).TotalDays.ToString();
                            // dataGridView1.Rows[i].Cells["DaysGiven"].Value = "don";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "For line no" + l.ToString());
            }


        }
        private void ComboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (id != "Null")
            {
                statusChange(id);
                id = "Null";

            }
        }
        void statusChange(string id)
        {
            
                
           
                        


                try
                {

                
                    string query = "UPDATE       AssigmentsForStaff SET Staus = '"+comboBox2.Text+ "', DateCompleted ='"+DateTime.Now.ToString("d/M/yyyy") +"' WHERE(ID = '" + id + "')";

                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read;
                    read = cmd.ExecuteReader();

                    con.Close();
                    loaddata();
                    MessageBox.Show("Updated Successfully");




                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    comboBox2.Visible = false;
                }
           
            

                


        }
        private void Button7_Click(object sender, EventArgs e)
        {



            

            SqlConnection con = new SqlConnection(variables.cons);
            try
            {

                if (id != "")
                {

                    string query = "SELECT    Assignments, AssigmentDate, DueDate, Works AS [Todays Work],  Staus AS [Status],ID FROM AssigmentsForStaff WHERE ID ='" + id + "'";
                    con.Open();

                    SqlCommand command = new SqlCommand(query, con);
                    SqlDataReader read = command.ExecuteReader();
                    read.Read();
                    if (read.HasRows)
                    {

                        richTextBox1.Text = read[0].ToString();
                         dateTimePicker2.Text = DateTime.ParseExact(read[1].ToString(), "d/M/yyyy", null).ToString("M/d/yyyy");
                        dateTimePicker1.Text = DateTime.ParseExact(read[2].ToString(), "d/M/yyyy", null).ToString("M/d/yyyy");
                       
                        textBox4.Text = read[3].ToString();
                        comboBox1.Text = read[4].ToString();
                        textBox1.Text = read[5].ToString();

                        

                    }
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    button3.Visible = false;


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            editData();
            loaddata();

            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }
        void deleteRow(string id)
        {
            string query = "DELETE FROM AssigmentsForStaff WHERE(ID = '" + id + "')";

            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read;
            read = cmd.ExecuteReader();

            con.Close();
            loaddata();
            MessageBox.Show("Deleted Successfully");


        }
        void calculatePerformance()
        {
            int totalWork = dataGridView1.Rows.Count;
            int workDone = 0;
            float percentage = 0;
            string comment;
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {

                if (dataGridView1.Rows[i].Cells["Status"].Value.ToString() == "Done")
                {
                    workDone++;
                }



            }
            if (totalWork != 0)
            {
                percentage = ((100 / totalWork) * workDone);

                // MessageBox.Show(percentage.ToString() + "%");
            }
            else
            {
                // MessageBox.Show( "No Work Pending Or given Yet");
            }

            if (percentage <= 10)
            {
                if (totalWork == 0)
                {
                    roundButton8.Text = "No Work This Day";
                }
                else
                {
                    comment = "Very Bad";
                    roundButton8.BackColor = roundButton1.BackColor;
                }
            }
            else if (percentage > 10 && percentage <= 20)
            {
                comment = "Bad";
                roundButton8.BackColor = roundButton2.BackColor;
            }
            else if (percentage > 20 && percentage <= 35)
            {
                comment = "Normal";
                roundButton8.BackColor = roundButton3.BackColor;
            }
            else if (totalWork > 35 && totalWork <= 50)
            {
                comment = "Good";
                roundButton8.BackColor = roundButton4.BackColor;
                insentive = 15;
            }
            else if (totalWork > 50 && totalWork <= 70)
            {
                comment = "Very Good";
                roundButton8.BackColor = roundButton5.BackColor;
                insentive = 25;
            }
            else if (percentage > 70 && percentage <= 90)
            {
                comment = "Exellent";
                roundButton8.BackColor = roundButton6.BackColor;
                insentive = 35;
            }
            else if (percentage > 90 && percentage <= 100)
            {
                comment = "Exeptional";
                roundButton8.BackColor = roundButton7.BackColor;
                insentive = 50;
            }
            else 
            {
            }

            //MessageBox.Show(comment);

            roundButton8.Text = percentage.ToString() + "%";
            if (totalWork == 0)
            {
                roundButton8.Text = "No Work This Day";
            }


        }
        void editData()
        {

            string query = "UPDATE       AssigmentsForStaff SET Assignments = '"+richTextBox1.Text.Trim()+"', AssigmentDate = '"+ Convert.ToDateTime(dateTimePicker2.Text).ToString("d/M/yyyy") + "', DueDate = '"+ Convert.ToDateTime(dateTimePicker1.Text).ToString("d/M/yyyy") + "', Works = '"+textBox4.Text.Trim()+"', Staus = '"+comboBox1.Text.Trim()+"', DateCompleted = '"+ Convert.ToDateTime(dateTimePicker2.Text).ToString("d/M/yyyy") + "' WHERE(ID = '"+textBox1.Text.Trim()+"')";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read;
            read = cmd.ExecuteReader();

            con.Close();
            MessageBox.Show("Updated Successfully");




        }
        private void Button9_Click(object sender, EventArgs e)
        {
            var dtfn = Convert.ToDateTime(Attendence.lblDateForAtt).Month;
            string query1 = "Select IsNull(Sum(Fine),0) as Fine,IsNull(Sum(Appriciation),0) as Appriciation,IsNull(Sum(Compensation),0) as Compensation from ExtraPaidOrFine where EmpName = '"+ label1.Text +"' and Month(Date) = '" + dtfn + "'";

            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt1 = new DataTable();
            SqlDataAdapter ad1 = new SqlDataAdapter(query1, con);
            ad1.Fill(dt1);


            int fin = Convert.ToInt32(dt1.Rows[0]["Fine"]);
            int Appr = Convert.ToInt32(dt1.Rows[0]["Appriciation"]);
            int Comp = Convert.ToInt32(dt1.Rows[0]["Compensation"]);


            string name = infoTable.Rows[0]["Staff_Name"].ToString(),
                des = infoTable.Rows[0]["Designation"].ToString(),
                dep = infoTable.Rows[0]["Department"].ToString(),
                salary = infoTable.Rows[0]["Salary"].ToString(),
                stat = infoTable.Rows[0]["Status"].ToString(),
                Eid = infoTable.Rows[0]["ID"].ToString(),
                inc = infoTable.Rows[0]["Increment"].ToString();


            string qry = "select Sum(Fine) as fine from AssigmentsForStaff where StaffName = '" + name + "' and Staus = 'Pending'";
            DataTable dt2 = new DataTable();
            SqlDataAdapter ad2 = new SqlDataAdapter(qry, con);
            ad2.Fill(dt2);
            //con.Close();
            int dprfin = Convert.ToInt32(dt2.Rows[0]["fine"]);

            string qry1 = "select Sum(Insentive) as Insentive from AssigmentsForStaff where StaffName = '" + name + "' and Staus = 'Done' and DateCompleted <= DueDate ";
            DataTable dt21 = new DataTable();
            SqlDataAdapter ad21 = new SqlDataAdapter(qry1, con);
            ad21.Fill(dt21);
            con.Close();
            int dprinsentive = Convert.ToInt32(dt2.Rows[0]["Insentive"]);

            Attendence_Record_Monthly obj = new Attendence_Record_Monthly(name, salary, des, dep, fin,Appr,Comp, stat,inc, "l", dprfin, dprinsentive, Convert.ToInt32(Eid));
            obj.Show();
        }
        void fineCalculation()
        {
            for(int i=0;i<dataGridView1.Rows.Count;i++)
            {
                DateTime duedate = DateTime.ParseExact(dataGridView1.Rows[i].Cells["DueDate"].Value.ToString(), "d/M/yyyy", null);

                if (((Convert.ToDateTime(DateTime.Now.Date.ToString("M/d/yyyy")) - duedate).TotalDays >= 0) && (dataGridView1.Rows[i].Cells["Status"].Value.ToString() != "Done"))          //((Convert.ToDateTime(DateTime.Now.Date.ToString("d/M/yyyy"))- (Convert.ToDateTime(    Convert.ToDateTime(dataGridView1.Rows[i].Cells["DueDate"].Value.ToString()).ToString("d/M/yyyy")))). TotalDays>=1 && dataGridView1.Rows[i].Cells["Status"].Value.ToString() != "Done")
                {
                    string id = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
                    double fd = (Convert.ToDateTime(DateTime.Now.Date.ToString("M/d/yyyy")) - duedate).TotalDays;
                    int FD= Convert.ToInt32(fd);
                   // dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;//FromArgb(220, 20, 60);
                    FD = 40 * FD;
                    insertFine(id, FD);
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }
        void insentiveCalculation()
        {
            int insnt = 0;

            SqlConnection con = new SqlConnection(variables.cons);
            SqlCommand cmd = new SqlCommand("select Convert(int, Replace(Salary,'NIll',0)) + Convert(int, Replace(Increment,'NIll',0)) as salary from Propertica_Staff_info where Staff_Name = '" + label1.Text + "' and Designation = '" + label2.Text + "' ", con);
            con.Open();
            SqlDataReader DR = cmd.ExecuteReader();
            int salry = 0;
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            int days = DateTime.DaysInMonth(year, month);
            string id = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                id = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
            }
            if (DR.Read())
            {
                salry = Convert.ToInt32(DR.GetValue(0));
                int perdayslry = salry / days;
                insnt = perdayslry * insentive / 100;
            }
            con.Close();
            insertInentive(id,insnt);
        }
        void insertFine(string id,int fine)
        {
            string query = "UPDATE AssigmentsForStaff SET Fine = '"+fine+"' WHERE(ID ='"+id+"')";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read;
            read = cmd.ExecuteReader();
            con.Close();
        }
        void insertInentive(string id, int fine)
        {
            if (id != "")
            {
                string query = "UPDATE AssigmentsForStaff SET Insentive = '" + fine + "' WHERE(ID ='" + id + "')";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read;
                read = cmd.ExecuteReader();
                con.Close();
            }
        }
        void loadInformation()
        {
           
            string query = "SELECT        ID,Staff_Name, Designation, Department, Salary ,  Status, Fine  FROM   Propertica_Staff_info  WHERE(Staff_Name = '"+ label1.Text+"')";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
           
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(infoTable);
            
            con.Close();

        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void RoundButton8_Click(object sender, EventArgs e)
        {
        }
        private const int HT_CAPTION = 0x2;
    }
}
