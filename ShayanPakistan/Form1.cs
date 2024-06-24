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
    public partial class SearchedData : Form
    {
        
        public SearchedData(string name)
        {
           
        InitializeComponent();
            ///////////////////////////////////////////////////////////////////////////////////////
            name = name.Remove(0, 2); //Removes the first 10 characters
            label4.Text = name.Trim();
            label8.Text= DateTime.Now.ToString("MMMM/dd/yyyy");
            
            
            /////////////////////////////////////////////////////////////////////////////////////////

            string query = "SELECT   Date_Completed , Assignment, Date_Assigned, Due_Date, Status   FROM  DPR_assigments_info WHERE (Status = 'Pending')AND (EmployName = '"+label4.Text+"')";
            //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

            ///////////////////////////////////////////////////////////////////////////////////////

           
            //after filling grid check which to  highlight red////////////
            //textBox1.Text = Convert.ToString(r);

            //textBox1.Text = label8.Text;
            
            //////////////////////////////////////////////////////////////////////////////////////



            






        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        



        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Bitmap bit = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);
            //dataGridView2.DrawToBitmap(bit,new Rectangle(0,0, dataGridView2.Width, dataGridView2.Height));
            //e.Graphics.DrawImage(bit, 250, 90);
            
        }


        private void Button2_Click(object sender, EventArgs e)
        {


       

            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sno"].Value = (e.RowIndex + 1).ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();

            this.Hide();
            obj.Show();

        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
             int r = dataGridView1.Rows.Count - 1;

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {



                
                


                    var dat = Convert.ToDateTime(label8.Text);
                    var tt = Convert.ToDateTime(dataGridView1.Rows[i].Cells["Due_Date"].Value);
                    if (Convert.ToString(dataGridView1.Rows[i].Cells["Due_Date"].Value) == label8.Text)
                    {



                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }


                    if ((Convert.ToInt64(dat.Day) - Convert.ToInt64(tt.Day)) > 0)
                    {

                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                    }

                    if ((Convert.ToInt64(dat.Day) + 2) == Convert.ToInt64(tt.Day) || (Convert.ToInt64(dat.Day) + 1) == Convert.ToInt64(tt.Day))
                    {

                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                    }

                
                

                
                    
                ////////////////////////////////////////////////////////////////
                ///

               


            }














        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
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




