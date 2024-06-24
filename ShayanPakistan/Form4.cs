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
using DGVPrinterHelper;

namespace ShayanPakistan
{
    
    public partial class Form4 : Form
    {

        string s;

        public Form4()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            loaddata();
            filcombo();
        
            
           // textBox9.Text = DateTime.Now.AddDays(-40).ToString("dd/MM/yyyy");
        }
        void filcombo()
        {
            string query = "SELECT DISTINCT  Business FROM Data_Entry_Operator";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            SqlCommand cmd=new SqlCommand(query,con);
            SqlDataReader myread;
            try
            {

                con.Open();
               myread = cmd.ExecuteReader();
                while(myread.Read())
                {
                    if (myread.GetValue(0).ToString().Trim() != "")
                    {
                        Business.Items.Add(myread.GetValue(0).ToString());
                    }
                }
                myread.Close();
            }
            catch(Exception )
            {
            }
            Business.AutoCompleteMode = AutoCompleteMode.Suggest;
            Business.AutoCompleteSource = AutoCompleteSource.ListItems;
            //filcombo1();
        }

        //void filcombo1()
        //{
        //    string query = "SELECT DISTINCT  City FROM Data_Entry_Operator";
        //    // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
        //    SqlConnection con = new SqlConnection(variables.cons);
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataReader myread;
        //    try
        //    {

        //        con.Open();
        //        myread = cmd.ExecuteReader();
        //        while (myread.Read())
        //        {
        //            if (myread.GetValue(0).ToString().Trim() != "")
        //            {
        //                comboBox1.Items.Add(myread.GetValue(0).ToString());
        //            }

        //        }
        //        myread.Close();

        //    }
        //    catch (Exception )
        //    {



        //    }


        //    comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
        //    comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

        //}



        private void Form4_Load(object sender, EventArgs e)
        {
            
           

            ////////////////////////////////////////////////////////
            //string query = "SELECT Company_Name As [Company Name], Business, Owner_Name As [Owner Name], Cell, Address, PhoneLine, E_mail As [E Mail] FROM  Data_Entry_Operator WHERE  (Date = '"+label1.Text+"')";
            ////SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            //SqlConnection con = new SqlConnection(variables.cons);
            //con.Open();
            //DataTable dt = new DataTable();
            //SqlDataAdapter ad = new SqlDataAdapter(query, con);
            //ad.Fill(dt);
            //dataGridView1.DataSource = dt;
            //con.Close();
            //////////////////////////////////
            ///
            loaddata();

            //dataGridView1.Columns[1].Width = 180;
            //dataGridView1.Columns[2].Width = 150;
            //dataGridView1.Columns[3].Width = 150;
            //dataGridView1.Columns[5].Width = 250;
            //dataGridView1.Columns[7].Width = 150;
            //dataGridView1.Columns[4].Width = 120;

            //dataGridView1.RowHeadersVisible = false;


            //label10.Text = "Total Entries   " + (dataGridView1.Rows.Count);


        }

        private void loaddata()
        {


            string query = "SELECT Company_Name As [Company Name], Business, Owner_Name As [Owner Name], Cell,MenagerName AS [M.Name] ,menagerCell[M.Cell] ,Address, PhoneLine AS [Office Phone], E_mail As [E Mail] FROM    Data_Entry_Operator  WHERE  (Date = '" + label1.Text + "')";
            //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            dataGridView1.Columns["Company Name"].Width = 190;
            dataGridView1.Columns["Business"].Width = 80;
            dataGridView1.Columns["Owner Name"].Width = 120;
            dataGridView1.Columns["Cell"].Width = 80;
            dataGridView1.Columns["M.Name"].Width = 120;
            dataGridView1.Columns["M.Cell"].Width = 80;
            dataGridView1.Columns["Address"].Width = 300;
            //dataGridView1.Columns["City"].Width = 90;
            //dataGridView1.Columns["Area"].Width = 120;
            dataGridView1.Columns["Office Phone"].Width = 100;
            dataGridView1.Columns["E Mail"].Width = 180;

            //dataGridView1.Columns[10].Width = 127;



            dataGridView1.ClearSelection();

            dataGridView1.RowHeadersVisible = false;
            label10.Text = "Total Entries   " + (dataGridView1.Rows.Count);
            filcombo();
           


        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["S_no"].Value = (e.RowIndex + 1).ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible=true;
            button3.Visible = true;
            button4.Visible = true;


            groupBox2.Visible=false;
            button5.Visible = textBox9.Visible = false;
            label10.Visible = false;


            textBox1.Text = Business.Text = textBox6.Text = textBox5.Text = textBox2.Text = textBox7.Text = textBox8.Text = "";


        }

        private void Button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;


            groupBox2.Visible = true;
            button5.Visible = textBox9.Visible = true;
            label10.Visible = true;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dataGridView1.DataSource = dt;

            string query1 = " SELECT        Company_Name, Business, Owner_Name, Cell, Address, PhoneLine, E_mail FROM            Data_Entry_Operator WHERE(Address = '" + textBox2.Text + "')";// AND(Owner_Name = '"+textBox6.Text+ "') AND(Company_Name = '"+textBox1.Text+"')";
                                                                                                                                                                                               //SqlConnection con1 = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con1 = new SqlConnection(variables.cons);
            con1.Open();
            //DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query1, con1);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con1.Close();
            

            if (dataGridView1.Rows.Count == 3)
            {

                MessageBox.Show("Data Is Already Enterd!!!");

                groupBox1.Visible = false;
                button3.Visible = false;
                button4.Visible = false;


                groupBox2.Visible = true;
                button5.Visible = textBox9.Visible = true;
                label10.Visible = true;


                label10.Text = "Total Entries   " + (dataGridView1.Rows.Count);

            }
            else
            {

                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    string query = "INSERT INTO Data_Entry_Operator (Company_Name, Business, Owner_Name, Cell, Address, PhoneLine, E_mail, Date,MenagerName,menagerCell) VALUES('" + textBox1.Text.Trim() + "', '" + Business.Text.Trim() + "', '" + textBox6.Text.Trim() + "', '" + textBox5.Text.Trim() + "', '" + textBox2.Text.Trim() + "', '" + textBox7.Text.Trim() + "', '" + textBox8.Text.Trim() + "', '" + DateTime.Now.ToString("dddd, dd MMMM yyyy") + "' , '" + textBox3.Text.Trim() + "', '" + textBox10.Text.Trim() + "')";
                    // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read;
                    read = cmd.ExecuteReader();

                    con.Close();
                    //////////
                    //groupBox1.Visible = false;
                    //button3.Visible = false;
                    //button4.Visible = false;


                    //groupBox2.Visible = true;
                    //button5.Visible = textBox9.Visible = true;
                    //label10.Visible = true;
                    //loaddata();

                    /////////
                    ///textBox1.Text = "";
                    ///
                    MessageBox.Show("Successfuly Saved");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    Business.Text = "";
                    textBox6.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox10.Text = "";
                }
                else
                {

                    MessageBox.Show("Please enter data carefully tankyou");

                    groupBox1.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;


                    groupBox2.Visible = true;
                    button5.Visible = textBox9.Visible = true;
                    label10.Visible = true;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    Business.Text = "";
                    textBox6.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox10.Text = "";
                    //loaddata();
                }

                



            }






        }

        private void Button1_Click(object sender, EventArgs e)
        {
            loaddata();
            //dataGridView1.Columns[1].Width = 180;
            //dataGridView1.Columns[2].Width = 150;
            //dataGridView1.Columns[3].Width = 150;
            //dataGridView1.Columns[5].Width = 250;
            //dataGridView1.Columns[7].Width = 150;
            //dataGridView1.Columns[4].Width = 120;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            var n = Convert.ToDateTime(label1.Text);

            

            label1.Text=n.AddDays(+1).ToString("dddd, dd MMMM yyyy");




            loaddata();

            
        }

        private void Button7_Click(object sender, EventArgs e)
        {

            var n = Convert.ToDateTime(label1.Text);
            
            label1.Text = n.AddDays(-1).ToString("dddd, dd MMMM yyyy");

            loaddata();

        }

       

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = dateTimePicker1.Value.ToString("dddd, dd MMMM yyyy");
            loaddata();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
             s = textBox9.Text;
             string query = "SELECT Company_Name As [Company Name], Business, Owner_Name As [Owner Name], Cell,MenagerName[M.Name],menagerCell AS [M.Cell],Address,City, PhoneLine, E_mail As [E Mail] FROM    Data_Entry_Operator  WHERE(Company_Name like '%" + textBox9.Text.Trim() + "%') OR(Owner_Name like '%" + textBox9.Text.Trim() + "%') OR(Business like '%" + textBox9.Text.Trim() + "%') OR(Address LIKE '%" + textBox9.Text.Trim() + "%') OR(Cell like '%" + textBox9.Text.Trim() + "%') OR(PhoneLine like '%" + textBox9.Text.Trim() + "%') OR(E_mail like '%" + textBox9.Text.Trim() + "%') OR(MenagerName like '%" + textBox9.Text.Trim() + "%') OR(menagerCell like '%" + textBox9.Text.Trim() + "%')";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            label10.Text = "Total Entries   " + (dataGridView1.Rows.Count);
            textBox9.Text = "";
            dataGridView1.ClearSelection();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            //dataGridView1.Columns["M.Name"].Visible = false;
            //dataGridView1.Columns["M.Cell"].Visible = false;
            dataGridView1.Columns["Address"].Visible = false;
            dataGridView1.Columns["City"].Visible = false;
            dataGridView1.Columns["E Mail"].Visible = false;
            //dataGridView1.Columns["M.Name"].Visible = false;
            dataGridView1.Columns["S_no"].Visible = false;
            dataGridView1.Columns["Area"].Visible = false;

            DGVPrinter printer = new DGVPrinter();
            printer.Title =s;
            printer.SubTitle = String.Format( DateTime.Now.Date.ToString("dddd , MMMM  dd,yyyy"));
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PrintDataGridView(dataGridView1);

            //dataGridView1.Columns["M.Name"].Visible = true;
            //dataGridView1.Columns["M.Cell"].Visible = true;
            dataGridView1.Columns["Address"].Visible = true;
            dataGridView1.Columns["City"].Visible = true;
            dataGridView1.Columns["E Mail"].Visible = true;
            //dataGridView1.Columns["M.Name"].Visible = true;
            dataGridView1.Columns["S_no"].Visible = true;
            dataGridView1.Columns["Area"].Visible = true;

        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TextBox9_MouseClick(object sender, MouseEventArgs e)
        {
            textBox9.Text = "";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            label15.Visible = true;
            progressBar1.Visible = true;
            for(int i=0;i<dataGridView1.Rows.Count;i++)
            {
                progressBar1.Increment(i);

                String cn = "";
                String bus = "";
                String on = "";
                String ocell = "";
                String mn = "";
                String mc = "";
                String adr = "";
                String cit = "";
                String Area = "";
                String Offph = "";
                String mail = "";

                try
                {
                 cn = dataGridView1.Rows[i].Cells["Company Name"].Value.ToString();
                 bus = dataGridView1.Rows[i].Cells["Business"].Value.ToString();
                 on = dataGridView1.Rows[i].Cells["Owner Name"].Value.ToString();
                 ocell = dataGridView1.Rows[i].Cells["Cell"].Value.ToString();
                 mn = dataGridView1.Rows[i].Cells["M.Name"].Value.ToString();
                 mc = dataGridView1.Rows[i].Cells["M.Cell"].Value.ToString();
                 adr = dataGridView1.Rows[i].Cells["Address"].Value.ToString();
                 cit = dataGridView1.Rows[i].Cells["City"].Value.ToString();
                 Area = dataGridView1.Rows[i].Cells["Area"].Value.ToString();
                 Offph = dataGridView1.Rows[i].Cells["Office Phone"].Value.ToString();
                 mail = dataGridView1.Rows[i].Cells["E Mail"].Value.ToString();

                }
                catch (Exception )
                {


                    MessageBox.Show("Error ");
                }

                string query = "UPDATE Data_Entry_Operator SET Company_Name = '"+cn+"', Business = '"+bus+"', Owner_Name = '"+on+"', Cell = '"+ocell+"', PhoneLine = '"+Offph+"', E_mail = '"+mail+"', Address = '"+adr+"', City = '"+cit+"', MenagerName = '"+mn+"', menagerCell = '"+mc+"', Area = '"+Area+"' WHERE(Company_Name = '"+cn+"') ";

                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read;
                read = cmd.ExecuteReader();

                con.Close();
            }

            label15.Visible = false;
            progressBar1.Value = 0;
            progressBar1.Visible = false;




        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
