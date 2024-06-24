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
using System.IO;

namespace ShayanPakistan
{
    public partial class Form2 : Form
    {

        //CustomProfessionalColors obj = new CustomProfessionalColors();
        public Form2()
        {
            InitializeComponent();
            menuStrip1.BackColor = Color.Black;
            menuStrip1.ForeColor = Color.White;

            menuStrip2.BackColor = Color.FromArgb(105, 105, 105);
            menuStrip2.ForeColor = Color.White;


            menuStrip3.BackColor = Color.FromArgb(230, 172, 0); //FromArgb(160, 153, 153);
            menuStrip3.ForeColor = Color.White;

            menuStrip4.BackColor = Color.Black;//FromArgb(195, 188, 188);
            menuStrip4.ForeColor = Color.White;


            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new ownColorTable());
            menuStrip2.Renderer = new ToolStripProfessionalRenderer(new ownColorTable());
            menuStrip3.Renderer = new ToolStripProfessionalRenderer(new ClassColorForThreeNavBar());
            menuStrip4.Renderer = new ToolStripProfessionalRenderer(new ownColorTable());
        }






        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }



        private void Button1_Click_1(object sender, EventArgs e)
        {

        }



        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //    string nm = row.Cells["Staff_name"].Value.ToString();

            //    //////////////////////////////////////////////////////
            //    ///

            //    Form3 obj = new Form3(nm);
            //    obj.Show();



            //}

        }

        private void SOFTWAREDEVELOPERSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DataEntryOperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 obj = new Form4();
            obj.Show();
        }

        private void DRPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 obj = new Form5();
            obj.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {


            dailyProgressReportDPRToolStripMenuItem3.Click += new SearchedDataForm().PrintButton_Click;

            groupBox1.Visible = false;
            PropertyForSaleLabel.Visible = false;

            textBox1.Text = variables.cons;

            // textBox1.Text=DateTime.Now.ToString("dddd, dd MMMM yyyy");


            // menuStrip1.Renderer = new ToolStripProfessionalRenderer(new TestColorTable());
            // menuStrip1.ForeColor = Color.FromArgb(18,253,237);         //White;
            // menuStrip1.BackColor = Color.FromArgb(34, 36, 49);
            //var d = Convert.ToDateTime("8/25/2019");
            //textBox1.Text = d.DayOfWeek.ToString();




        }



        private void ShaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //stafff toolstrip////
            Form6 obj = new Form6();
            obj.Show();



        }






        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }





        private void MenuStrip1_MouseHover(object sender, EventArgs e)
        {

        }

        private void LeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //staff left



            StaffLeft obj = new StaffLeft();
            obj.Show();

        }

        private void StaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Departments
            Departments obj = new Departments();
            obj.Show();



        }

        private void BasicStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicStaff obj = new BasicStaff();
            obj.Show();
        }

        private void SeniorityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Seniority obj = new Seniority();
            obj.Show();
        }

        private void DailyRecieptsAndExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Daily_Reciepts_And_Expenses obj = new Daily_Reciepts_And_Expenses();
            obj.Show();

        }

        private void ApplicationsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Interviews obj = new Interviews("Applications Data");
            //obj.Show();

        }

        private void DilyInterviewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    Interviews obj = new Interviews("Dialy interviews report");
            //    obj.Show();
        }

        private void LeftServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Interviews obj = new Interviews("Left Services");
            //obj.Show();
        }

        private void WaitingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Interviews obj = new Interviews("Waiting List");
            //obj.Show();
        }

        private void ExpenseLeftServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Interviews obj = new Interviews("Expense Left Services");
            //obj.Show();
        }

        private void TermsConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Interviews obj = new Interviews("Terms and Conditions");
            //obj.Show();
        }

        private void SalaryAndBenefitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    Interviews obj = new Interviews("TSalary and Benefits");
            //    obj.Show();
        }

        private void AccountsToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

        }

        private void InterviewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //interviews options
            InterviewOptions obj = new InterviewOptions();
            obj.Show();

        }

        private void MenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void PropertyBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Property_Services obj = new Property_Services();
            obj.Show();
        }

        private void MenuStrip1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void LedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ledger obj = new Ledger("General");
            obj.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        private void DomainNameAndHostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //

            DomainNameAnDHosting obj = new DomainNameAnDHosting();
            obj.Show();




        }



        private void AssignmentsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Attendence obj = new Attendence();
            obj.Show();
            //stafff toolstrip////
            //AllStaffForAssignments obj = new AllStaffForAssignments();
            //obj.Show();
        }

        private void UtilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities obj = new Utilities();
            obj.Show();
        }

        private void AttendenceRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Attendence obj = new Attendence();
            //obj.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Imagepicker obj = new Imagepicker();
            obj.Show();
        }

        private void GatePassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gate_Pass obj = new Gate_Pass();
            obj.Show();
        }

        private void forSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HeadingLabel.Visible = false;
            EmployeeGroupBox0.Visible = false;
            PropertyForSaleLabel.Visible = true;
            groupBox1.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

            sarways obj = new sarways();
            obj.Show();
            groupBox1.Visible = false;
            PropertyForSaleLabel.Visible = false;

        }

        //private void label4_Click(object sender, EventArgs e)
        //{
        //    sarways_building_sale obj = new sarways_building_sale();
        //    obj.Show();
        //    groupBox1.Visible = false;            PropertyForSaleLabel.Visible = true;

        //}

        private void label5_Click(object sender, EventArgs e)
        {
            BanquitHall obj = new BanquitHall();
            obj.Show();
            groupBox1.Visible = false;
            PropertyForSaleLabel.Visible = false;

        }

        private void label15_Click(object sender, EventArgs e)
        {
            sarways obj = new sarways();
            obj.Show();
            groupBox1.Visible = false;
            PropertyForSaleLabel.Visible = false;


        }

        private void label23_Click(object sender, EventArgs e)
        {
            sarways obj = new sarways();
            obj.Show();
            groupBox1.Visible = false;
            PropertyForSaleLabel.Visible = false;

        }

        private void label12_Click(object sender, EventArgs e)
        {
            sarway_house obj = new sarway_house();
            obj.Show();
            groupBox1.Visible = false;
            PropertyForSaleLabel.Visible = false;

        }

        private void DutyCharterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllStaffForAssignments obj = new AllStaffForAssignments();
            obj.Show();

            //Attendence obj = new Attendence();
            //obj.Show();
        }

        private void SetIconsAttndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imagepicker obj = new Imagepicker();
            obj.Show();
        }

        private void DailyProgressReportDPRToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void HRToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void DPRPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //dgv.Columns.Remove("Column1");

            //int height = SearchedDataGridView.Height;
            //int w = SearchedDataGridView.Width;
            //SearchedDataGridView.Height = SearchedDataGridView.RowCount * SearchedDataGridView.RowTemplate.Height + 71;
            //SearchedDataGridView.Height = SearchedDataGridView.RowCount * SearchedDataGridView.RowTemplate.Height + 251;
            //bmp = new Bitmap(dgv.Width, dgv.Height);
            //e.Graphics.DrawString("Propertica (PVT) LTD", new Font("Arial", 21, FontStyle.Bold), Brushes.Black, new Point(293, 9));
            //e.Graphics.DrawString("Daily Progress Report (Survey Dep.)", new Font("Arial", 17, FontStyle.Regular), Brushes.Blue, new Point(243, 51));
            //e.Graphics.DrawString("30/12/2019", new Font("Arial", 11, FontStyle.Underline), Brushes.Black, new Point(737, 53));
            //e.Graphics.DrawString("Area:______________", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(21, 99));
            //e.Graphics.DrawString("Name:_______________", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(267, 99));
            //e.Graphics.DrawString("Designation:_______________", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(537, 99));

            //Rectangle OuterRectangle = new System.Drawing.Rectangle(21, 147, 805, 877);
            //e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), OuterRectangle);

            //Internal Table

            //Heading
            Rectangle NoRectangle = new System.Drawing.Rectangle(21, 147, 9, 9);
            e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), NoRectangle);
            e.Graphics.DrawString("No.", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(31, 39));

            //Rectangle PropAddressRectangle = new System.Drawing.Rectangle(109, 147, 105, 87);
            //e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), PropAddressRectangle);
            //e.Graphics.DrawString("Porp. Address", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(101, 199));

            //Rectangle OwnerNameRectangle = new System.Drawing.Rectangle(21, 147, 105, 87);
            //e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), OwnerNameRectangle);
            //e.Graphics.DrawString("Owner's Name", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(101, 199));

            //Rectangle PhoneRectangle = new System.Drawing.Rectangle(21, 147, 105, 87);
            //e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), PhoneRectangle);
            //e.Graphics.DrawString("Phone No.", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(101, 199));

            //Rectangle RemarksRectangle = new System.Drawing.Rectangle(21, 147, 105, 87);
            //e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), RemarksRectangle);
            //e.Graphics.DrawString("Remarks", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(101, 199));






            e.Graphics.DrawString("Sign.:_____________________", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(535, 1041));




        }

        private void DailyProgressReportDPRToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            PropertyForSaleLabel.Visible = false;
            groupBox1.Visible = false;
            HeadingLabel.Visible = true;
            HeadingLabel.Text = "Employees of Legal Department";

            //    EmployeePictureBox0.Visible = true;
            //    NameLabel0.Visible = true;
            //    DesignationLabel0.Visible = true;
            //    DepartmentLabel0.Visible = true;
            //    JobStatus0.Visible = true;

            EmployeeGroupBox0.Visible = true;
            EmployeePictueBox0.Visible = true;
            NameLabel0.Visible = true;
            DesignationLabel0.Visible = true;
            DepartmentLabel0.Visible = true;
            JobStatus0.Visible = true;
            LoadData("Legal Department");

        }
        private void WebDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WholeGroupBox0.Visible = true;
            WholeGroupBox1.Visible = true;
            PropertyForSaleLabel.Visible = false;
            groupBox1.Visible = false;
            HeadingLabel.Visible = true;
            HeadingLabel.Text = "Employees of I.T Department";

            EmployeeGroupBox0.Visible = true;
            EmployeePictueBox0.Visible = true;
            NameLabel0.Visible = true;
            DesignationLabel0.Visible = true;
            DepartmentLabel0.Visible = true;
            JobStatus0.Visible = true;

            //Showing Heads of Particulars
            DesignationHeadingLabel0.Visible = true;
            DepartmentHeadingLabel0.Visible = true;
            JobHeadingStatus0.Visible = true;

            DesignationHeadingLabel1.Visible = true;
            DepartmentHeadingLabel1.Visible = true;
            JobHeadingStatus1.Visible = true;

            DesignationHeadingLabel2.Visible = true;
            DepartmentHeadingLabel2.Visible = true;
            JobHeadingStatus2.Visible = true;

            DesignationHeadingLabel2.Visible = true;
            DepartmentHeadingLabel2.Visible = true;
            JobHeadingStatus2.Visible = true;

            DesignationHeadingLabel3.Visible = true;
            DepartmentHeadingLabel3.Visible = true;
            JobHeadingStatus3.Visible = true;

            DesignationHeadingLabel4.Visible = true;
            DepartmentHeadingLabel4.Visible = true;
            JobHeadingStatus4.Visible = true;

            DesignationHeadingLabel5.Visible = true;
            DepartmentHeadingLabel5.Visible = true;
            JobHeadingStatus5.Visible = true;

            EmployeeGroupBox1.Visible = true;
            EmployeePictueBox1.Visible = true;
            NameLabel1.Visible = true;
            DesignationLabel1.Visible = true;
            DepartmentLabel1.Visible = true;
            JobStatus1.Visible = true;

            EmployeeGroupBox2.Visible = true;
            EmployeePictueBox2.Visible = true;
            NameLabel2.Visible = true;
            DesignationLabel2.Visible = true;
            DepartmentLabel2.Visible = true;
            JobStatus2.Visible = true;

            EmployeeGroupBox4.Visible = true;
            EmployeePictueBox4.Visible = true;
            NameLabel4.Visible = true;
            DesignationLabel4.Visible = true;
            DepartmentLabel4.Visible = true;
            JobStatus4.Visible = true;

            LoadData("I.T");
        }

        //Loading Data in EmployeeGroupBoxes
        private void LoadData(string Department)
        {
            string query = "";
            if (Department == "Legal Department")
            {
                query = "SELECT ID, Staff_Name AS [Name], Department," +
                   " Designation, status, Image FROM Propertica_Staff_info " +
                   "WHERE Department = '" + Department + "' and status!='left' ;";
            }

            if (Department == "I.T")
            {
                query = "SELECT ID, Staff_Name AS [Name], Department," +
                   " Designation, status, Image FROM Propertica_Staff_info " +
                   "WHERE Department = '" + Department + "' and status!='left' ;";
            }

            if (Department == "Legal Department")
            {
                query = "SELECT ID, Staff_Name AS [Name], Department," +
                   " Designation, status, Image FROM Propertica_Staff_info " +
                   "WHERE Department = '" + Department + "' and status!='left' ;";
            }

            if (Department == "Legal Department")
            {
                query = "SELECT ID, Staff_Name AS [Name], Department," +
                   " Designation, status, Image FROM Propertica_Staff_info " +
                   "WHERE Department = '" + Department + "' and status!='left' ;";
            }
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            DataTable dt = new DataTable();
            SqlCommand SqlCommand = new SqlCommand(query, con);
            con.Open();
            using (con)
            {
                SqlDataReader SDR = SqlCommand.ExecuteReader();
                // string SDRObj = SDR.Read().ToString();
                while (SDR.Read())
                {
                    if ("Shabir Hussain Chattah" == SDR["Name"].ToString())
                    {
                        IDNumberTextBox.Text = SDR["ID"].ToString();
                        //  EmployeePictureBox0.Image = new Bitmap(SDR["Image"].ToString()); 
                        NameLabel0.Text = SDR["Name"].ToString();
                        DesignationLabel0.Text = SDR["Designation"].ToString();
                        DepartmentLabel0.Text = SDR["Department"].ToString();
                        JobStatus0.Text = SDR["status"].ToString();
                        //byte[] imageData = (byte[]) SDR["Image"].ToString(); ;
                        byte[] img = (byte[])(SDR[5]);
                        //if (img == null)
                        //{
                        //    EmployeePictue.Image = null;
                        //}
                        //else
                        //{
                        MemoryStream ms = new MemoryStream(img);
                        EmployeePictueBox0.Image = Image.FromStream(ms);
                        //}
                    }

                    //I.T Department
                    if ("Rana Haider Ali" == SDR["Name"].ToString())
                    {
                        IDNumberTextBox.Text = SDR["ID"].ToString();
                        //  EmployeePictureBox0.Image = new Bitmap(SDR["Image"].ToString()); 
                        NameLabel0.Text = SDR["Name"].ToString();
                        DesignationLabel0.Text = SDR["Designation"].ToString();
                        DepartmentLabel0.Text = SDR["Department"].ToString();
                        JobStatus0.Text = SDR["status"].ToString();
                        //byte[] imageData = (byte[]) SDR["Image"].ToString(); ;
                        byte[] img = (byte[])(SDR[5]);
                        //if (img == null)
                        //{
                        //    EmployeePictue.Image = null;
                        //}
                        //else
                        //{
                        MemoryStream ms = new MemoryStream(img);
                        EmployeePictueBox0.Image = Image.FromStream(ms);
                        //}
                    }
                    if ("Titus Zaman" == SDR["Name"].ToString())
                    {
                        IDNumberTextBox.Text = "";
                        IDNumberTextBox.Text = SDR["Name"].ToString();
                        NameLabel1.Text = SDR["Name"].ToString();
                        DesignationLabel1.Text = SDR["Designation"].ToString();
                        DepartmentLabel1.Text = SDR["Department"].ToString();
                        JobStatus1.Text = SDR["status"].ToString();
                        //byte[] imageData = (byte[]) SDR["Image"].ToString(); ;
                        byte[] img = (byte[])(SDR[5]);
                        //if (img == null)
                        //{
                        //    EmployeePictue.Image = null;
                        //}
                        //else
                        //{
                        MemoryStream ms = new MemoryStream(img);
                        EmployeePictueBox1.Image = Image.FromStream(ms);
                        //}
                    }

                    if ("Syed Muhammad Hamza" == SDR["Name"].ToString())
                    {
                        IDNumberTextBox.Text = "";
                        IDNumberTextBox.Text = SDR["Name"].ToString();
                        NameLabel2.Text = SDR["Name"].ToString();
                        DesignationLabel2.Text = SDR["Designation"].ToString();
                        DepartmentLabel2.Text = SDR["Department"].ToString();
                        JobStatus2.Text = SDR["status"].ToString();
                        //byte[] imageData = (byte[]) SDR["Image"].ToString(); ;
                        byte[] img = (byte[])(SDR[5]);
                        //if (img == null)
                        //{
                        //    EmployeePictue.Image = null;
                        //}
                        //else
                        //{
                        MemoryStream ms = new MemoryStream(img);
                        EmployeePictueBox2.Image = Image.FromStream(ms);
                        //}
                    }

                    if ("Faheem Nasir" == SDR["Name"].ToString())
                    {
                        IDNumberTextBox.Text = "";
                        IDNumberTextBox.Text = SDR["Name"].ToString();
                        NameLabel4.Text = SDR["Name"].ToString();
                        DesignationLabel4.Text = SDR["Designation"].ToString();
                        DepartmentLabel4.Text = SDR["Department"].ToString();
                        JobStatus4.Text = SDR["status"].ToString();
                        //byte[] imageData = (byte[]) SDR["Image"].ToString(); ;
                        byte[] img = (byte[])(SDR[5]);
                        //if (img == null)
                        //{
                        //    EmployeePictue.Image = null;
                        //}
                        //else
                        //{
                        MemoryStream ms = new MemoryStream(img);
                        EmployeePictueBox4.Image = Image.FromStream(ms);
                        //}
                    }



                }
            }

        }

        //Click Event for linking to Staff Form
        public static string IDNumber = "";
        private void EmployeePictue_Click(object sender, EventArgs e)
        {
            IDNumber = "";
            IDNumber = IDNumberTextBox.Text;
            new Form3("Rana Haider Ali", "", "").Show();

        }

        private void EmployeePictueBox1_Click(object sender, EventArgs e)
        {
            new Form3("Titus Zaman", "", "").Show();
        }
       
        private void EmployeePictueBox2_Click(object sender, EventArgs e)
        {
            new Form3("Syed Muhammad Hamza", "", "").Show();
        }
        private void EmployeePictueBox3_Click(object sender, EventArgs e)
        {
           // new Form3("Faheem Nasir", "", "").Show();
        }
        private void EmployeePictueBox4_Click(object sender, EventArgs e)
        {
            new Form3("Faheem Nasir", "", "").Show();
        }
        private void EmployeePictueBox5_Click(object sender, EventArgs e)
        {
            //new Form3("Titus Zaman", "", "").Show();
        }

        private void DesignationLabel0_Click(object sender, EventArgs e)
        {

        }

        private void Label59_Click(object sender, EventArgs e)
        {

        }

        private void MonthlySalariesRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void AssetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssetsReport assetsReport = new AssetsReport();
            assetsReport.Show();
        }

        private void AssetsAndFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DCFBRRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BooksAndMagzieneToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseWin purchaseWin = new PurchaseWin();
            purchaseWin.Show();
        }

        private void StaffSalariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlySalariesRecord mnth = new MonthlySalariesRecord();
            mnth.Show();
        }
    }

}














































































































