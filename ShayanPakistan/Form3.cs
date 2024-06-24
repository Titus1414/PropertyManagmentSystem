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
    public partial class Form3 : Form
    {
        string n;
        string imgloc = "";
        public Form3(string name, string days, string Notice)
        {
            InitializeComponent();
            textBox1.Text = name;
            n = name;
            if (!string.IsNullOrEmpty(name))
            {
                pr();
                label25.Text = days;
                button2.Visible = true;
                button9.Visible = false;
            }
            else {
                button2.Visible = false;
                button9.Visible = true;
            }
            
            
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString("dddd, MMMM dd , yyyy");
            this.TopMost = true;
            textBox20.Visible = false;
        }
        private void Label7_Click(object sender, EventArgs e)
        {
        }
        private void Label9_Click(object sender, EventArgs e)
        {
        }
        private void Label12_Click(object sender, EventArgs e)
        {
        }
        private void Label11_Click(object sender, EventArgs e)
        {
        }
        private void Label10_Click(object sender, EventArgs e)
        {
        }
        private void Label13_Click(object sender, EventArgs e)
        {
        }
        private void GroupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void Button1_Click(object sender, EventArgs e)
        {
        }
        private void Button4_Click(object sender, EventArgs e)
        {
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void TextBox11_TextChanged(object sender, EventArgs e)
        {
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            //byte[] img = null;
            //try
            //{
            //    if (imgloc != "")
            //    {
            //        FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            //        BinaryReader br = new BinaryReader(fs);
            //        img = br.ReadBytes((int)fs.Length);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error1");
            //    MessageBox.Show(ex.Message);
            //}
            try
            {
                if (textBox20.Text != "")
                {
                    string PicName = Path.GetFileName(textBox20.Text);
                    string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    File.Copy(textBox20.Text, Path.Combine(path + "\\StaffImages\\", Path.GetFileName(textBox20.Text)), true);
                    //Image = @img,
                    string query = " UPDATE Propertica_Staff_info SET Staff_Name = '" + textBox1.Text + "', Designation = '" + textBox3.Text + "', Department = '" + comboBox5.SelectedText + "', Fathers_Name = '" + textBox2.Text + "', Nic = '" + textBox5.Text + "', Date_of_Appointment = '" + dateTimePicker1.Text + "', Salary = '" + textBox7.Text + "', Address = '" + textBox11.Text + "', Mobile = '" + textBox8.Text + "', Ref_Mob = '" + textBox9.Text + "', Landline = '" + textBox10.Text + "', Date_of_Birth = '" + textBox13.Text + "', Age = '" + textBox12.Text + "',  Status = '" + comboBox1.Text + "', Ref_Name='" + textBox6.Text + "',Ref_Adress='" + textBox14.Text + "',Ref2_Name='" + textBox15.Text + "',Ref2_Adress='" + textBox17.Text + "',Ref2_Mobile='" + textBox16.Text + "',Timing='" + comboBox3.Text + "',IncrementDate = '" + textBox19.Text + "',Increment = '" + textBox18.Text + "', PICName =  @PicName,AccountNo = '"+textBox4.Text+"' WHERE(Staff_Name = '" + n + "')";
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PicName", PicName);
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Updated with image Successfully");
                    Form6 obj = new Form6();
                    obj.Show();
                    this.Close();
                }
                else
                {
                    string query = " UPDATE Propertica_Staff_info SET Staff_Name = '" + textBox1.Text + "', Designation = '" + textBox3.Text + "', Department = '" + comboBox5.SelectedText + "', Fathers_Name = '" + textBox2.Text + "', Nic = '" + textBox5.Text + "', Date_of_Appointment = '" + dateTimePicker1.Text + "', Salary = '" + textBox7.Text + "', Address = '" + textBox11.Text + "', Mobile = '" + textBox8.Text + "', Ref_Mob = '" + textBox9.Text + "', Landline = '" + textBox10.Text + "', Date_of_Birth = '" + textBox13.Text + "', Age = '" + textBox12.Text + "',  Status = '" + comboBox1.Text + "', Ref_Name='" + textBox6.Text + "',Ref_Adress='" + textBox14.Text + "',Ref2_Name='" + textBox15.Text + "',Ref2_Adress='" + textBox17.Text + "',Ref2_Mobile='" + textBox16.Text + "',Timing='" + comboBox3.Text + "',IncrementDate = '" + textBox19.Text + "',Increment = '" + textBox18.Text + "',AccountNo = '" + textBox4.Text + "' WHERE(Staff_Name = '" + n + "')";
                    //string query = " UPDATE Propertica_Staff_info SET Staff_Name = '" + textBox1.Text + "', Designation = '" + textBox3.Text + "', Department = '" + textBox4.Text + "', Fathers_Name = '" + textBox2.Text + "', Nic = '" + textBox5.Text + "', Date_of_Appointment = '" + dateTimePicker1.Text + "', Salary = '" + textBox7.Text + "', Address = '" + textBox11.Text + "', Mobile = '" + textBox8.Text + "', Ref_Mob = '" + textBox9.Text + "', Landline = '" + textBox10.Text + "', Date_of_Birth = '" + textBox13.Text + "', Age = '" + textBox12.Text + "',  Status = '" + comboBox1.Text + "',Timing='" + comboBox3.Text + "',IncrementDate = '" + textBox19.Text + "',Increment = '" + textBox18.Text + "'  WHERE(Staff_Name = '" + n + "')";
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Updated Successfully");
                    Form6 obj = new Form6();
                    obj.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
        }
        private void ComboBox2_TextChanged(object sender, EventArgs e)
        {
            button3.Visible = true;
            button2.Visible = false;
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "")
                {
                    DateTime dates = Convert.ToDateTime(dateTimePicker3.Text);
                    string query1 = " UPDATE Propertica_Staff_info SET  Date_Applied_For_leaving = '" + dateTimePicker2.Value.ToLongDateString() + "', Date_Given_For_Leaving = '" + dates.ToShortDateString() + "' ,Status='Left', Notice = N'" + richTextBox1.Text.Trim() + "' WHERE(Staff_Name = '" + n + "')";
                    SqlConnection con1 = new SqlConnection(variables.cons);
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand(query1, con1);
                    SqlDataReader read1;
                    read1 = cmd1.ExecuteReader();
                    con1.Close();
                    MessageBox.Show("Updated to Left Staff Successfully");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void pr()
        {
            string query = "SELECT  Staff_Name, Designation, Department, Fathers_Name, Nic, Date_of_Appointment, Salary, Address, Mobile, Ref_Mob, Landline, Date_of_Birth, Age,  Status , PICName, Fine,Increment,IncrementDate,Ref_Name,Ref_Adress,Ref2_Name,Ref2_Adress,Ref2_Mobile,Ref_Mob,Timing,Date_Applied_For_leaving,Date_Given_For_Leaving,AccountNo   FROM   Propertica_Staff_info  WHERE(Staff_Name = '" + n.Trim() + "')";
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
                    textBox18.Text = read[16].ToString();//Increment
                    string dtpv = " No Increment ";
                    if (textBox18.Text == "" || textBox18.Text == "0")
                    {
                        
                    }
                    else {
                        dtpv = read[17].ToString();//IncrementDate
                    }



                    textBox1.Text = read[0].ToString();
                    textBox3.Text = read[1].ToString();
                    comboBox5.SelectedText = read[2].ToString();
                    textBox2.Text = read[3].ToString();
                    textBox5.Text = read[4].ToString();//nic
                    dateTimePicker1.Text = read[5].ToString();//aply date
                    textBox7.Text = read[6].ToString();//salary
                    textBox11.Text = read[7].ToString();//adress
                    textBox8.Text = read[8].ToString();//mobile
                    textBox9.Text = read[9].ToString();//refmobile
                    textBox10.Text = read[10].ToString();//landline
                    textBox13.Text = read[11].ToString();//dateofbirth
                    textBox12.Text = read[12].ToString();//age
                    comboBox1.Text = read[13].ToString();//status
                    FineText.Text = read[15].ToString();//Fine
                    
                    textBox19.Text = dtpv;//IncrementDate
                    textBox6.Text = read[18].ToString();//RefName
                    textBox14.Text = read[19].ToString();//RefAddress
                    textBox15.Text = read[20].ToString();//RefName2
                    textBox17.Text = read[21].ToString();//Ref2Address
                    textBox16.Text = read[22].ToString();//Ref2Mobile
                    textBox9.Text = read[23].ToString();//RefMobile
                    comboBox3.Text = read[24].ToString();//Timing
                    dateTimePicker4.Text = read[25].ToString();
                    dateTimePicker2.Text = read[25].ToString();
                    dateTimePicker3.Text = read[26].ToString();
                    textBox4.Text = read[27].ToString();

                    if (FineText.Text == "")
                    {
                        FineText.Text = "0";
                    }
                    string sts = read[13].ToString();
                    if (sts == "Left")
                    {
                        radioButton1.Checked = true;
                        radioButton1.Enabled = false;
                        radioButton2.Enabled = true;
                        radioButton3.Enabled = true;
                    }
                    //byte[] img = (byte[])(read[14]);
                    //if (img == null)
                    //{
                    //    pictureBox1.Image = null;
                    //}
                    //else
                    //{
                    //    MemoryStream ms = new MemoryStream(img);
                    //    pictureBox1.Image = Image.FromStream(ms);
                    //}
                    var imgg = read[14].ToString();
                    if (!string.IsNullOrEmpty(imgg))
                    {
                        string PicPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                        string MyImg = PicPath + "\\StaffImages\\" + read[14].ToString();
                        pictureBox2.Image = Image.FromFile(@""+ MyImg + "");
                    }
                    else
                    {

                        pictureBox2.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show("Data Does not Exist");
                }
                con.Close();
            }

            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }
        private void Button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(* .jpg)|*.jpg|GIF Files (* .gif)| * .gif|All Files(*.*)|*.*";
                dlg.Title = "Select Employ Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    imgloc = dlg.FileName.ToString();
                    pictureBox2.ImageLocation = imgloc;
                    textBox20.Text = imgloc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            AssignmentsForStaff obj = new AssignmentsForStaff(textBox1.Text, textBox3.Text);
            obj.Show();
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                var dtfn = Convert.ToDateTime(Attendence.lblDateForAtt).Month;
                string query1 = "Select Eid,IsNull(Sum(Fine),0) as Fine,IsNull(Sum(Appriciation),0) as Appriciation,IsNull(Sum(Compensation),0) as Compensation from ExtraPaidOrFine where EmpName = '"+ textBox1.Text.ToString() +"' and Month(Date) = '" + dtfn + "'";

                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt1 = new DataTable();
                SqlDataAdapter ad1 = new SqlDataAdapter(query1, con);
                ad1.Fill(dt1);
                int fin = Convert.ToInt32(dt1.Rows[0]["Fine"]);
                int Appr = Convert.ToInt32(dt1.Rows[0]["Appriciation"]);
                int Comp = Convert.ToInt32(dt1.Rows[0]["Compensation"]);
                int id = Convert.ToInt32(dt1.Rows[0]["Eid"]);

                string qry = "select Sum(Fine) as fine from AssigmentsForStaff where StaffName = '" + textBox1.Text + "' and Staus = 'Pending'";
                DataTable dt2 = new DataTable();
                SqlDataAdapter ad2 = new SqlDataAdapter(qry, con);
                ad2.Fill(dt2);
                //con.Close();
                int dprfin = Convert.ToInt32(dt2.Rows[0]["fine"]);

                string qry1 = "select Sum(Insentive) as Insentive from AssigmentsForStaff where StaffName = '" + textBox1.Text + "' and Staus = 'Done' and DateCompleted <= DueDate ";
                DataTable dt21 = new DataTable();
                SqlDataAdapter ad21 = new SqlDataAdapter(qry1, con);
                ad21.Fill(dt21);
                con.Close();
                int dprinsentive = Convert.ToInt32(dt2.Rows[0]["Insentive"]);


                Attendence_Record_Monthly obj = new Attendence_Record_Monthly(textBox1.Text, textBox7.Text, textBox3.Text, comboBox5.SelectedText, fin, Appr, Comp, comboBox1.Text, textBox18.Text, "Attendence_Record", dprfin, dprinsentive,id);
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            Duty_Charter obj = new Duty_Charter(textBox3.Text);
            obj.Show();
        }
        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Before 1:00 PM")
            {
                richTextBox1.Text = "His Salary Wil Be Working days (-0.5 Days)";
            }
        }
        private void Label29_Click(object sender, EventArgs e)
        {
        }
        private void Button4_Click_1(object sender, EventArgs e)
        {
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" )
            {
                try
                {
                    string PicName = Path.GetFileName(textBox20.Text);
                    string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    File.Copy(textBox20.Text, Path.Combine(path + "\\StaffImages\\", Path.GetFileName(textBox20.Text)), true);

                    string query = "INSERT INTO Propertica_Staff_info (Staff_Name, Designation, Department, Fathers_Name, Nic, Address, Mobile, Age, Date_of_Appointment, Salary, Status,Timing,PICName,Increment,IncrementDate,Landline,Date_of_Birth,Ref_Name,Ref_Mob,Ref_Adress,Ref2_Name,Ref2_Mobile,Ref2_Adress,IsActive,AccountNo) VALUES('" + textBox1.Text + "', '" + textBox3.Text + "', '" + comboBox5.SelectedText + "', '" + textBox2.Text + "', '" + textBox5.Text + "', '" + textBox11.Text + "', '" + textBox8.Text + "', '" + textBox12.Text + "', '" + dateTimePicker1.Text + "', '" + textBox7.Text + "', '" + comboBox1.Text + "', '" + comboBox3.Text + "',@img, '" + textBox18.Text + "', '" + textBox19.Text + "','" + textBox10.Text + "','" + textBox13.Text + "','" + textBox6.Text + "','" + textBox9.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "',1,'"+ textBox4.Text + "')";
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@img", PicName));
                    int x = cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show(x.ToString() + " record(s) saved successfully ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                textBox1.Text = "";
                textBox3.Text = "";
                comboBox5.SelectedText = "";
                textBox2.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox11.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox13.Text = "";
                textBox12.Text = "";
                comboBox1.Text = "";
                FineText.Text = "";
                textBox19.Text = "";
                textBox6.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox17.Text = "";
                textBox16.Text = "";
                textBox9.Text = "";
                comboBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Please Enter Name of the employ and other fields carefully. Thankyou!!!");
            }
        }
    }
}
