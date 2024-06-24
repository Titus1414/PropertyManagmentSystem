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
    public partial class SearchedDataForm : Form
    {

        public SearchedDataForm()
        {

            InitializeComponent();

            //Dynamic Heading Of The Page
            if (BanquitHall.SearchString == "")
            {
                SearchResultLabel.Text = "Search All";
            }
            if (BanquitHall.SearchString != "")
            {
                SearchResultLabel.Text = "Search From of '" + BanquitHall.SearchString + "'";
            }

            //Search Query on the basis of SearchTextBox
            string SearchString = BanquitHall.SearchString;
            string query = "select ID, hall_name as [Hall Name], [location] as [Location], " +
                "owner_name as [Owner Name], mobile_no as [Owner Phone], " +
                "authrise_name as [Manager Name], mobile as [Manager Phone]," +
                "land_line as [Land Line No]  from banquit_hall where hall_name like '%" +
                SearchString +
                 "%' or location like '% " +
                SearchString +
                "%' or owner_name like '%" +
                SearchString +
                "%' or mobile_no like '%" +
                SearchString +
                "%' or land_line like '%" +
                SearchString +
                "%' or authrise_name like '%" +
                SearchString +
                "%' or mobile like '%" +
                SearchString +
                "%' or[Address] like '%" +
                SearchString +
                "%' order by ID";

            //Populating the GridView(SearchedDataGridView) from Baquit_Hall Table
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    SearchedDataGridView.Rows.Add(
                       Convert.ToInt32(SDR["ID"]),
                        SDR["Hall Name"].ToString(),
                        SDR["Location"].ToString(),
                        SDR["Owner Name"].ToString(),
                        SDR["Owner Phone"].ToString(),
                        SDR["Manager Name"].ToString(),
                        SDR["Manager Phone"].ToString(),
                        SDR["Land Line No"].ToString());

                }
                int TotalRows = SearchedDataGridView.RowCount - 1;
                //TotalNumberLabel.Text = TotalRows.ToString();
                TotalRowsLabel.Text = "Showing Total  " + TotalRows + " Search Results";
            }
        }
        private void SearchedDataForm_Load(object sender, EventArgs e)
        {
            // InitializeComponent();
        }
        public static string IDOfSpecificRecord = "";
       
        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IDnumberLabel.Text = SearchedDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            IDOfSpecificRecord = SearchedDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            IDnumberLabel.Visible = true;
            new BanquitHall().Close();
            new BanquitHall().Hide();
            new BanquitHall().Show();
        }

        private void DPRPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //dgv.Columns.Remove("Column1");
           
            int height = SearchedDataGridView.Height;
            int w = SearchedDataGridView.Width;
            SearchedDataGridView.Height = SearchedDataGridView.RowCount * SearchedDataGridView.RowTemplate.Height + 71;
            SearchedDataGridView.Height = SearchedDataGridView.RowCount * SearchedDataGridView.RowTemplate.Height + 251;
            //bmp = new Bitmap(dgv.Width, dgv.Height);
             e.Graphics.DrawString("Propertica (PVT) LTD", new Font("Arial", 21, FontStyle.Bold), Brushes.Black, new Point(293, 9));
            e.Graphics.DrawString("Daily Progress Report (Survey Dep.)", new Font("Arial", 17, FontStyle.Regular), Brushes.Blue, new Point(243, 51));
            e.Graphics.DrawString("31/12/2019", new Font("Arial", 11, FontStyle.Underline), Brushes.Black, new Point(734, 53));
            e.Graphics.DrawString("Area:______________", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(21, 99));
            e.Graphics.DrawString("Name:_______________", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(267, 99));
            e.Graphics.DrawString("Designation:_______________", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(536, 99));
            Rectangle OuterRectangle = new System.Drawing.Rectangle(21, 147, 805, 879);
            e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), OuterRectangle);

            //Internal Table
            //Heading
            int MarginTopHeading = 148;
            Rectangle NoRectangle = new System.Drawing.Rectangle(23, MarginTopHeading, 53, 49);
            e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), NoRectangle);
            e.Graphics.DrawString("No.", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(31, 159));

            Rectangle PropAddressRectangle = new System.Drawing.Rectangle(75, MarginTopHeading, 195, 49);
            e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), PropAddressRectangle);
            e.Graphics.DrawString("Porp. Address", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(85, 159));

            Rectangle OwnerNameRectangle = new System.Drawing.Rectangle(272, MarginTopHeading, 165, 49);
            e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), OwnerNameRectangle);
            e.Graphics.DrawString("Owner's Name", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(275, 159));

            Rectangle PhoneRectangle = new System.Drawing.Rectangle(435, MarginTopHeading, 144, 49);
            e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), PhoneRectangle);
            e.Graphics.DrawString("Phone No.", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(447, 159));

            Rectangle RemarksRectangle = new System.Drawing.Rectangle(580, MarginTopHeading, 245, 49);
            e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), RemarksRectangle);
            e.Graphics.DrawString("Remarks", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(592, 159));


            int CellHeight = 49;
            int CellWidth = 49;
            int MarginTop = CellHeight + 147;
            int MarginTopData = MarginTop + 13;
            for (int i = 0; i < 17; i++)
            {
                string NumberCount = (i + 1).ToString();
            Rectangle NoDataRectangle = new System.Drawing.Rectangle(23, MarginTop, 53, 49);
            e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), NoDataRectangle);
            e.Graphics.DrawString(NumberCount, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(31, MarginTop));
                //    string SearchedDataGridViewValue = SearchedDataGridView.Rows[i].Cells[2].Value.ToString();
                Rectangle PropAddressDataRectangle = new System.Drawing.Rectangle(75, MarginTop, 195, 49);
                    e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), PropAddressDataRectangle);
                    e.Graphics.DrawString("Porp. Address", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(85, MarginTop));

                Rectangle OwnerNameDataRectangle = new System.Drawing.Rectangle(272, MarginTop, 165, 49);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), OwnerNameDataRectangle);
                e.Graphics.DrawString("", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(275, MarginTop));

                Rectangle PhoneDataRectangle = new System.Drawing.Rectangle(435, MarginTop, 144, 49);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), PhoneDataRectangle);
                e.Graphics.DrawString("", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(447, MarginTop));

                Rectangle RemarksDataRectangle = new System.Drawing.Rectangle(580, MarginTop, 245, 49);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), RemarksDataRectangle);
                e.Graphics.DrawString("Remarks", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(592, MarginTop));
                MarginTop += 49;
                MarginTopData = CellHeight + 159;
                MarginTopData += MarginTop;

            }

            //Static Data
            //for (int i = 0; i < 17; i++)
            //{
            //    Rectangle NoDataRectangle = new System.Drawing.Rectangle(23, MarginTop, 53, 49);
            //    e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), NoDataRectangle);
            //    e.Graphics.DrawString("No.", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(31, MarginTopData));

            //    Rectangle PropAddressDataRectangle = new System.Drawing.Rectangle(75, MarginTop, 195, 49);
            //    e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), PropAddressDataRectangle);
            //    e.Graphics.DrawString("Porp. Address", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(85, MarginTopData));

            //    Rectangle OwnerNameDataRectangle = new System.Drawing.Rectangle(272, MarginTop, 165, 49);
            //    e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), OwnerNameDataRectangle);
            //    e.Graphics.DrawString("Owner's Name", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(275, MarginTopData));

            //    Rectangle PhoneDataRectangle = new System.Drawing.Rectangle(435, MarginTop, 144, 49);
            //    e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), PhoneDataRectangle);
            //    e.Graphics.DrawString("Phone No.", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(447, MarginTopData));

            //    Rectangle RemarksDataRectangle = new System.Drawing.Rectangle(580, MarginTop, 245, 49);
            //    e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), RemarksDataRectangle);
            //    e.Graphics.DrawString("Remarks", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(592, MarginTopData));
            //    MarginTop += 49;
            //    MarginTopData = MarginTop + 13;

            //}





            e.Graphics.DrawString("Sign.:_____________________", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(533, 1045));
            e.Graphics.DrawString("Page:1", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(401, 1067));




        }

        internal void PrintButton_Click(object sender, EventArgs e)
        {
            DPRPrintPreviewDialog.Document = DPRPrintDocument;
            (DPRPrintPreviewDialog as Form).WindowState = FormWindowState.Maximized;
            DPRPrintPreviewDialog.Show();
            DPRPrintDocument.Print();
        }

        private void DPRPrintPreviewDialog_Load(object sender, EventArgs e)
        {
            DPRPrintPreviewDialog.Document = DPRPrintDocument;
            DPRPrintPreviewDialog.Show();

        }
    }
}










//////////////////////////////////////////////////////////////////////////////////////////////////////
//code  for fynalyze

//private void Button1_Click(object sender, EventArgs e)
//{
//    DataTable ds = new DataTable();
//    ds.Columns.Add("EmployName");
//    ds.Columns.Add("Assignment");
//    ds.Columns.Add("Date");
//    ds.Columns.Add("DueDate");
//    ds.Columns.Add("Status");
//    ds.Columns.Add("DateCompleted");
//    ds.Columns.Add("AssigmentCode");

//    foreach (DataGridViewRow row in dataGridView1.Rows)
//    {
//        bool isSelected = Convert.ToBoolean(row.Cells["UpperGrid"].Value);
//        if (isSelected)
//        {
//            ds.Rows.Add(row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value = "done", row.Cells[6].Value = textBox2.Text, row.Cells[7].Value);
//            string a = row.Cells[7].Value.ToString();
//            string q = "UPDATE       DPR_assigments_info SET  Status ='Done', DateCompleted ='" + textBox2.Text + "' WHERE(Assignmentcode = " + a + ")";
//            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-0R1BI80\SQLEXPRESS; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Mujtaba; Password=1234567887654321");
//            con1.Open();
//            SqlCommand cmd = new SqlCommand(q, con1);
//            SqlDataReader read;
//            read = cmd.ExecuteReader();
//            con1.Close();


//        }
//        dataGridView2.DataSource = ds;
//    }
//    MessageBox.Show("Report Saved Successfuly it is not changeable Thankyou");


//}
////////////////////////////////////////////////////////////////////////////////////////////////////////
///
//code to highlight//////////////////////////////////////////////////////

//for (int i = 0; i < dataGridView1.Rows.Count; i++)
//{


//    if (Convert.ToString(dataGridView1.Rows[i].Cells["Due_Date"].Value) == label8.Text)
//    {


//        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
//    }
//}




