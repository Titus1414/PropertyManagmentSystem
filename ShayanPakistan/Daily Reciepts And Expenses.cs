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


namespace ShayanPakistan
{
   
    public partial class Daily_Reciepts_And_Expenses : Form
    {
        int reciepts = 0;
        int expense = 0;
        DataTable t2 = new DataTable();
        string a = "", b = "";
        bool monthly, yearly=false;
        bool daily = false;

        public Daily_Reciepts_And_Expenses()
        {
            InitializeComponent();
        }
        
        private void Daily_Reciepts_And_Expenses_Load(object sender, EventArgs e)
        {
            filcombo();
           groupBox1.Text=groupBox1.Text+DateTime.Now.ToString("M/dd/yyyy");
            groupBox2.Text = groupBox2.Text + DateTime.Now.ToString("M/dd/yyyy");
         //label25.Text= Convert.ToDateTime( groupBox1.Text.Remove(0, 10)).ToString("MMMM  dd , yyyy");
            var s  = Convert.ToDateTime(groupBox1.Text.Remove(0, 10));
            

            ///////////////////
            ///


            loaddata_R();
            loaddata_E();

            if(Convert.ToInt32(textBox4.Text)>0)
            {
                textBox1.Text = textBox4.Text;
            }
            else
            {
                textBox1.Text = "0";

            }


            //////

            //string query = "SELECT        Cash_Forward, Date FROM Daily_Cash_Forward WHERE(Date = '" + s.AddDays(-1).ToString("M/dd/yyyy") + "')";
            //SqlConnection con1 = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            //con1.Open();
            
            //SqlDataAdapter ad1 = new SqlDataAdapter(query, con1);
            //ad1.Fill(t2);
            //dataGridView1.DataSource = t2;
            //con1.Close();


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            a = groupBox1.Text.Remove(0, 10);
            b = groupBox2.Text.Remove(0, 10);

            var n = Convert.ToDateTime(a);
            var n1 = Convert.ToDateTime(b);

            label27.Text = "Reciepts " + n.ToLongDateString();



            groupBox1.Text = "[Reciepts]" + n.AddDays(-1).ToString("M/dd/yyyy");
            groupBox2.Text = "[Expenses]" + n.AddDays(-1).ToString("M/dd/yyyy");

            var q = Convert.ToDateTime(groupBox1.Text.Remove(0, 10));
           // label25.Text = Convert.ToDateTime(groupBox1.Text.Remove(0, 10)).ToString("MMMM  dd , yyyy");



            loaddata_R();
            loaddata_E();


            if (q.DayOfWeek.ToString() == "Sunday")
            {
                label15.Visible = true;


            }
            else
            {
                label15.Visible = false;

            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {

            comboBox1.Text = "";
            textBox6.Text = "";
            dateTimePicker2.Text = "";
            textBox7.Text = "";
            textBox14.Text = "";



            ///


            groupBox3.Visible = true;
            button22.Visible = false;

            ///////
            button3.Visible = false;
            dataGridView1.Visible = false;

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            button20.Visible = false;
            button21.Visible = false;

            button7.Visible = true;
            button22.Visible = true;
            /////

            button3.Visible = true;
            dataGridView1.Visible = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            comboBox6.Text = "";
            comboBox4.Text = "";
            textBox9.Text = "";
            dateTimePicker3.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";






            groupBox4.Visible = true;

           // textBox10.Visible = true;
            button18.Visible = false;
            /////
            button4.Visible = false;
            dataGridView2.Visible = false;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            button10.Visible = true;
            button18.Visible = true;
            button19.Visible = false;
            button17.Visible = false;




            /////
            button4.Visible = true;
            dataGridView2.Visible = true;
            loaddata_E();


        }

        private void Button7_Click(object sender, EventArgs e)
        {
            //Save Reciepts //

            // loaddata(date);
            if(comboBox1.Text !=""&& textBox6.Text!=""&& comboBox2.Text !="" && textBox7.Text!="")
            {
                string query = "INSERT INTO Daily_Reciept_Expense (Reciept_Account, Ammount_Recieved, Payment_Mode_R, Description_R, Date) VALUES('" + comboBox1.Text + "', '" + textBox6.Text + "', '" + comboBox2.Text + "', '" + textBox7.Text + "', '"+ Convert.ToDateTime( dateTimePicker2.Text).ToString("M/dd/yyyy") +"')";
                //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read;
                read = cmd.ExecuteReader();

                con.Close();

                MessageBox.Show("Data Entered Successfuly");

                loaddata_R();

            }
            else
            {

                MessageBox.Show("Please Fill All Things ");
            }

            //
            groupBox3.Visible = false;
            button20.Visible = false;
            button21.Visible = false;

            button7.Visible = true;
            button22.Visible = true;
            /////

            button3.Visible = true;
            dataGridView1.Visible = true;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            a = groupBox1.Text.Remove(0,10);
            b = groupBox2.Text.Remove(0, 10);

            var n = Convert.ToDateTime(a);
            var n1 = Convert.ToDateTime(b);



            groupBox1.Text ="[Reciepts]"+n.AddDays(+1).ToString("M/dd/yyyy");
            groupBox2.Text = "[Expenses]" + n.AddDays(+1).ToString("M/dd/yyyy");

            var q = Convert.ToDateTime(groupBox1.Text.Remove(0, 10));
           // label25.Text = Convert.ToDateTime(groupBox1.Text.Remove(0, 10)).ToString("MMMM  dd , yyyy");


            loaddata_R();
            loaddata_E();

            if (q.DayOfWeek.ToString() == "Sunday")
            {
                label15.Visible = true;


            }
            else
            {
                label15.Visible = false;

            }
            //button2.Visible = false;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            /////////////////////////////////
            ///
            //This IS Expense Save
            if (comboBox6.Text != "" && textBox9.Text != "" && comboBox5.Text != "" && textBox8.Text != "")
            {
                string query = "INSERT INTO  Daily_Expense    (Expense_Account, Ammount_Paid, Payment_Mode_E, Description_E, Date , Quantity , Price_per_unit,Sub_Head,Paid_to) VALUES('" + comboBox6.Text + "', '" + textBox9.Text + "', '" + comboBox5.Text + "', '" + textBox8.Text + "', '" + Convert.ToDateTime(dateTimePicker3.Text).ToString("M/dd/yyyy") + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + comboBox4.Text + "','"+textBox12.Text+"')";
                //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read;
                read = cmd.ExecuteReader();

                con.Close();

                MessageBox.Show("Data Entered Successfuly");

                loaddata_E();

            }
            else
            {

                MessageBox.Show("Please Fill All Things ");
            }


            groupBox4.Visible = false;
            button10.Visible = true;
            button18.Visible = true;
            button17.Visible = false;



            /////
            button4.Visible = true;
            dataGridView2.Visible = true;
            button19.Visible = false;

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            //a = groupBox1.Text.Remove(0, 10);
            //b = groupBox2.Text.Remove(0, 10);

            //var n = Convert.ToDateTime(a);
            //var n1 = Convert.ToDateTime(b);

            var d =Convert.ToDateTime(dateTimePicker1.Text).ToString("M/dd/yyyy");
            groupBox1.Text = "[Reciepts]" + d.ToString();
            groupBox2.Text = "[Expenses]" + d.ToString();

            var q = Convert.ToDateTime(groupBox1.Text.Remove(0, 10));
            //label25.Text = Convert.ToDateTime(groupBox1.Text.Remove(0, 10)).ToString("MMMM  dd , yyyy");

            loaddata_R();
            loaddata_E();

            if (q.DayOfWeek.ToString() == "Sunday")
            {
                label15.Visible = true;


            }
            else
            {
                label15.Visible = false;

            }


        }

        //bool
        void loaddata_R()
        {
            string date = groupBox1.Text.Remove(0, 10);
            var n = Convert.ToDateTime(date);

            label27.Text = "[Reciepts] " + n.ToLongDateString();

            reciepts = 0;
            //bool a=false;
            string query = "SELECT        Reciept_Account AS [Reciept Account], Ammount_Recieved AS [Ammount Recieved],Payment_Mode_R,Description_R,Date,ID FROM Daily_Reciept_Expense WHERE(Date = '" + date + "')";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable t = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(t);

            dataGridView1.DataSource = t;
            con.Close();
            dataGridView1.Columns["Payment_Mode_R"].Visible = false;
            dataGridView1.Columns["Description_R"].Visible = false;
            dataGridView1.Columns["Date"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;

            dataGridView1.Columns[1].Width = 230;
            dataGridView1.Columns[2].Width = 150;

            dataGridView1.ClearSelection();


            for(int i=0;i<=dataGridView1.Rows.Count-1;i++)
            {

                reciepts = reciepts + Convert.ToInt32(dataGridView1.Rows[i].Cells["Ammount Recieved"].Value);



            }
            label6.Text = "Total Ammount  " + reciepts;
            textBox2.Text = reciepts.ToString();

            textBox4.Text = Convert.ToString(Convert.ToInt64(textBox2.Text) - Convert.ToInt64(textBox3.Text));

            if (Convert.ToInt64(textBox4.Text) > 0)
            {
                textBox1.Text = textBox4.Text;
            }
            else
            {
                textBox1.Text = "0";

            }

            textBox14.Text = "";

        }
        void loaddata_E()
        {
            daily = true;
            string date = groupBox2.Text.Remove(0, 10);
            
            var n = Convert.ToDateTime(date);
            label28.Text = "[Expenses] " + n.ToLongDateString();
            expense = 0;
            //bool a=false;
            //string query = "SELECT    Expense_Account AS [Expense Account], SUM( CAST (Ammount_Paid AS int) ) AS [Paid Ammount],Description_E,Date,Sub_Head FROM Daily_Expense   WHERE(Date = '" + date + "') GROUP BY Expense_Account ";
            string query = "SELECT    Expense_Account AS [Expense Account], Ammount_Paid  AS [Paid Ammount],Description_E,Date,Sub_Head,Quantity,Price_per_unit,Paid_to,ID FROM Daily_Expense   WHERE(Date = '" + date + "') ";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable t1 = new DataTable();
            SqlDataAdapter ad1 = new SqlDataAdapter(query, con);
            ad1.Fill(t1);
            dataGridView2.DataSource = t1;
            con.Close();

            dataGridView2.Columns[1].Width = 210;
            dataGridView2.Columns[2].Width = 160;

            dataGridView2.Columns["Description_E"].Visible = false;
            dataGridView2.Columns["Date"].Visible = false;
            dataGridView2.Columns["Sub_Head"].Visible = false;
            dataGridView2.Columns["Quantity"].Visible = false;
            dataGridView2.Columns["Price_per_unit"].Visible = false;
            dataGridView2.Columns["Paid_to"].Visible = false;
            dataGridView2.Columns["ID"].Visible = false;


            dataGridView2.ClearSelection();


            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {

                expense = expense + Convert.ToInt32(dataGridView2.Rows[i].Cells["Paid Ammount"].Value);



            }
            label7.Text = "Total Ammount  " + expense;
            textBox3.Text = expense.ToString();


            textBox4.Text = Convert.ToString(Convert.ToInt64(textBox2.Text) - Convert.ToInt64(textBox3.Text));
            textBox1.Text = textBox4.Text;

            textBox13.Text = "";
            //if (Convert.ToInt64(textBox4.Text) > 0)
            //{
            //    textBox1.Text = textBox4.Text;
            //}
            //else
            //{
            //   textBox1.Text = "0";

            //}

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var dta = Convert.ToDateTime(groupBox1.Text.Remove(0, 10));
            string de = dta.AddDays(1).ToString("M/dd/yyyy");
            //textBox1.Text = de;
            //string query = "INSERT INTO Daily_Cash_Forward (Cash_Forward, Date) VALUES('" + textBox1.Text + "', '" + groupBox2.Text.Remove(0, 10) + "')";
            string query = "INSERT INTO Daily_Reciept_Expense (Reciept_Account, Ammount_Recieved, Date) VALUES('Cash Forward', '" + textBox1.Text + "', '"+de+"')";
            /// SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read;
            read = cmd.ExecuteReader();

            con.Close();

            MessageBox.Show("Cash Forwarded Successfuly");

            /////////////////////////////////////
            ///











            loaddata_E();





        }

        void filcombo()
        {
            string query = "SELECT        Expenses_Head FROM Expense_Heads";
            //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader myread;
            try
            {

                con.Open();
                myread = cmd.ExecuteReader();
                while (myread.Read())
                {
                    if (myread.GetValue(0).ToString().Trim() != "")
                    {
                        comboBox6.Items.Add(myread.GetValue(0).ToString());
                    }

                }
                myread.Close();

            }
            catch (Exception )
            {



            }

            comboBox6.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox6.AutoCompleteSource = AutoCompleteSource.ListItems;

            filcombo2();
        }


       void filcombo2()
        {

            string query = "SELECT    DISTINCT   Sub_Head, Expense_Account FROM Daily_Expense WHERE(Expense_Account = '" + comboBox6.Text+"')";
            //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader myread;
            try
            {

                con.Open();
                myread = cmd.ExecuteReader();
                while (myread.Read())
                {
                    if (myread.GetValue(0).ToString().Trim() != "")
                    {
                        comboBox4.Items.Add(myread.GetValue(0).ToString());
                    }

                }
                myread.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

            comboBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox4.AutoCompleteSource = AutoCompleteSource.ListItems;


        }

        private void DataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // expense double click
            if (e.RowIndex >= 0)
            {

                if (monthly==true)
                {
                    groupBox5.Visible = true;

                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    string nm = row.Cells["Expense Account"].Value.ToString();
                    string date = groupBox2.Text.Remove(0, 10);
                    DateTime n = Convert.ToDateTime(date);

                    string query = "SELECT        Sub_Head AS[Descrip], Quantity[Qty], Price_per_unit AS [U.P],Ammount_Paid AS [Total],Paid_to AS [Paid To],Description_E AS [Expense Head] FROM Daily_Expense WHERE(Expense_Account = '" + nm + "') AND(MONTH(Date) ='" + n.Month.ToString() + "')";
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    DataTable t1 = new DataTable();
                    SqlDataAdapter ad1 = new SqlDataAdapter(query, con);
                    ad1.Fill(t1);
                    dataGridView3.DataSource = t1;
                    con.Close();

                    this.dataGridView3.Columns["Expense Head"].Width = 120;
                    this.dataGridView3.Columns["Paid To"].Width = 80;
                    this.dataGridView3.Columns["Qty"].Width = 30;
                    this.dataGridView3.Columns["U.P"].Width = 30;

                   // this.dataGridView3.Columns["Descrip"].Visible = false;
                    dataGridView3.Columns["Expense Head"].DisplayIndex = 0;
                    dataGridView3.Columns["Paid To"].DisplayIndex = 1;

                    //this.dataGridView3.Columns[4].Width = 70;
                    int total = 0;
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        total = total + Convert.ToInt32(dataGridView3.Rows[i].Cells["Total"].Value.ToString());


                    }

                    lbl_total.Text = "Grand Total = " + total.ToString();
                    label23.Text = "Voucher  " + nm;
                    dataGridView3.ClearSelection();
                    

                }
                else if(yearly==true)
                {
                    groupBox5.Visible = true;

                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    string nm = row.Cells["Expense Account"].Value.ToString();
                    string date = groupBox2.Text.Remove(0, 10);
                    DateTime n = Convert.ToDateTime(date);

                    string query = "SELECT        Sub_Head AS[Descrip], Quantity[Qty], Price_per_unit AS [U.P],Ammount_Paid AS [Total],Paid_to AS [Paid To],Description_E AS [Expense Head] FROM Daily_Expense WHERE(Expense_Account = '" + nm + "') AND(YEAR(Date) ='" + n.Year.ToString() + "')";
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    DataTable t1 = new DataTable();
                    SqlDataAdapter ad1 = new SqlDataAdapter(query, con);
                    ad1.Fill(t1);
                    dataGridView3.DataSource = t1;
                    con.Close();

                    this.dataGridView3.Columns["Expense Head"].Width = 120;
                    this.dataGridView3.Columns["Paid To"].Width = 80;
                    this.dataGridView3.Columns["Qty"].Width = 30;
                    this.dataGridView3.Columns["U.P"].Width = 30;

                    // this.dataGridView3.Columns["Descrip"].Visible = false;
                    dataGridView3.Columns["Expense Head"].DisplayIndex = 0;
                    dataGridView3.Columns["Paid To"].DisplayIndex = 1;

                    //this.dataGridView3.Columns[4].Width = 70;
                    int total = 0;
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        total = total + Convert.ToInt32(dataGridView3.Rows[i].Cells["Total"].Value.ToString());


                    }

                    lbl_total.Text = "Grand Total = " + total.ToString();
                    label23.Text = "Voucher  " + nm;
                    dataGridView3.ClearSelection();

                }
                else
                {

                    groupBox5.Visible = true;

                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                    string nm = row.Cells["Expense Account"].Value.ToString();
                    string date = groupBox2.Text.Remove(0, 10);

                    string query = "SELECT        Sub_Head AS[Descrip], Quantity[Qty], Price_per_unit AS [U.P],Ammount_Paid AS [Total],Paid_to AS [Paid To],Description_E AS [Expense Head] FROM Daily_Expense WHERE(Expense_Account = '" + nm + "') AND(Date ='" + date + "')";
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    DataTable t1 = new DataTable();
                    SqlDataAdapter ad1 = new SqlDataAdapter(query, con);
                    ad1.Fill(t1);
                    dataGridView3.DataSource = t1;
                    con.Close();

                    this.dataGridView3.Columns["Expense Head"].Width = 110;
                    this.dataGridView3.Columns["Paid To"].Width = 90;
                    this.dataGridView3.Columns["Qty"].Width = 30;
                    this.dataGridView3.Columns["U.P"].Width = 30;
                    this.dataGridView3.Columns["Total"].Width = 40;

                    // this.dataGridView3.Columns["Descrip"].Visible = false;
                    dataGridView3.Columns["Expense Head"].DisplayIndex = 0;
                    dataGridView3.Columns["Paid To"].DisplayIndex = 1;

                    //this.dataGridView3.Columns[4].Width = 70;
                    int total = 0;
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        total = total + Convert.ToInt32(dataGridView3.Rows[i].Cells["Total"].Value.ToString());


                    }

                    lbl_total.Text = "Grand Total = " + total.ToString();
                    label23.Text = "Voucher  " + nm;
                    dataGridView3.ClearSelection();
                }






                //

                //if (e.RowIndex >= 0)
                //{
                //    groupBox5.Visible = true;

                //    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                //    string nm = row.Cells["Expense Account"].Value.ToString();
                //    string date = groupBox2.Text.Remove(0, 10);

                //    string query = "SELECT        Sub_Head AS[S.H], Quantity[Qty], Price_per_unit AS [U.P],Ammount_Paid AS [Total],Paid_to AS [Paid To],Description_E AS [Particulars] FROM Daily_Expense WHERE(Expense_Account = '" + nm+"') AND(Date ='"+date+"')";
                //     SqlConnection con = new SqlConnection(variables.cons);
                //    con.Open();
                //    DataTable t1 = new DataTable();
                //    SqlDataAdapter ad1 = new SqlDataAdapter(query, con);
                //    ad1.Fill(t1);
                //    dataGridView3.DataSource = t1;
                //    con.Close();

                //    this.dataGridView3.Columns["Particulars"].Width = 150;
                //    this.dataGridView3.Columns["Paid To"].Width =80;
                //    this.dataGridView3.Columns["Qty"].Width=35;
                //    this.dataGridView3.Columns["U.P"].Width = 40;

                //    this.dataGridView3.Columns["S.H"].Visible = false;
                //    dataGridView3.Columns["Particulars"].DisplayIndex = 0;
                //    dataGridView3.Columns["Paid To"].DisplayIndex = 1;

                //    //this.dataGridView3.Columns[4].Width = 70;
                //    int total = 0;
                //    for(int i =0;i<dataGridView3.Rows.Count;i++)
                //    {
                //        total = total + Convert.ToInt32(dataGridView3.Rows[i].Cells["Total"].Value.ToString());


                //    }

                //    lbl_total.Text = "Grand Total = " + total.ToString();
                //    label23.Text = "Voucher  "+nm;
                //    dataGridView3.ClearSelection();

                ////////////////////////////////////////////////////////////////////////////


                //////////////////////////////////////////////////
                //string query = "SELECT        Description_E, Expense_Account, Date FROM Daily_Expense WHERE(Expense_Account = '"+nm+"') AND(Date = '"+date+"')";
                ////SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                //SqlConnection con = new SqlConnection(variables.cons);
                //try
                //{

                //    con.Open();

                //    SqlCommand command = new SqlCommand(query, con);
                //    SqlDataReader read = command.ExecuteReader();
                //    read.Read();
                //    if (read.HasRows)
                //    {

                //        richTextBox1.Text = read[0].ToString();







                //  }


                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);

                //}




                // }



            }
        }

       

        private void Button12_Click_1(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            filcombo2();
        }

        private void DataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ///
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                // string nm = row.Cells["Particulars"].Value.ToString();
               string nm = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();

               Ledger obj = new Ledger(nm);
                obj.Show();


            }








            }

        private void Label23_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string nm= label23.Text.Remove(0,7).Trim();
            Ledger obj = new Ledger(nm);
            obj.Show();

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //[Reciept Account], Ammount_Recieved AS [Ammount Recieved],Payment_Mode_R,Description_R,Date
            if (e.RowIndex>=0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["Reciept Account"].Value.ToString();
                textBox6.Text = row.Cells["Ammount Recieved"].Value.ToString();
                dateTimePicker2.Text = row.Cells["Date"].Value.ToString();
                textBox7.Text = row.Cells["Description_R"].Value.ToString();
                textBox14.Text = row.Cells["ID"].Value.ToString();

                button20.Visible = true;
                button21.Visible = true;
            }







        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ////Cell Click ///
            /// Expense_Account AS [Expense Account], Ammount_Paid  AS [Paid Ammount],Description_E,Date,Sub_Head FROM 
            if (daily == true)
            {

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                    button17.Visible = true;
                    button19.Visible = true;
                    comboBox6.Text = row.Cells["Expense Account"].Value.ToString();
                    comboBox4.Text = row.Cells["Sub_Head"].Value.ToString();
                    textBox9.Text = row.Cells["Paid Ammount"].Value.ToString();
                    dateTimePicker3.Text = row.Cells["Date"].Value.ToString();
                    textBox10.Text = row.Cells["Quantity"].Value.ToString();
                    textBox11.Text = row.Cells["Price_per_unit"].Value.ToString();
                    textBox12.Text = row.Cells["Paid_to"].Value.ToString();
                    textBox13.Text = row.Cells["ID"].Value.ToString();
                    daily = false;




                }

            }



        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

            //    string acc = row.Cells["Expense Account"].Value.ToString();
            //    string amm = row.Cells["Paid Ammount"].Value.ToString();
            //    string sh = row.Cells["Sub_Head"].Value.ToString();
            //    string desc = row.Cells["Description_E"].Value.ToString();
            //    string dat = row.Cells["Date"].Value.ToString();






            //    try
            //    {
            //        DialogResult dialogResult = MessageBox.Show("Do you Really Want To delete this Record", "Choose One", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            // MessageBox.Show("Yeah It Came Here");
            //            string query = "DELETE FROM Daily_Expense WHERE(Expense_Account = '" + acc + "') AND(Ammount_Paid = '" + amm + "') AND(Description_E = '" + desc + "') AND(Date = '" + dat + "') AND(Sub_Head = '" + sh + "')";
            //            SqlConnection con = new SqlConnection(variables.cons);
            //            con.Open();
            //            SqlCommand cmd = new SqlCommand(query, con);
            //            SqlDataReader read;
            //            read = cmd.ExecuteReader();

            //            con.Close();
            //            loaddata_E();

            //            MessageBox.Show("Expense Deleted Successfuly");


            //        }
            //        else if (dialogResult == DialogResult.No)
            //        {
            //            //do something else
            //        }







            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }










            //}


        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            //    string acc = row.Cells["Reciept Account"].Value.ToString();
            //    string amm = row.Cells["Ammount Recieved"].Value.ToString();
            //    string pm = row.Cells["Payment_Mode_R"].Value.ToString();
            //    string desc = row.Cells["Description_R"].Value.ToString();
            //    string dat = row.Cells["Date"].Value.ToString();



            //    if (pm!=""&&desc!="")
            //    {


            //        try
            //        {


            //            DialogResult dialogResult = MessageBox.Show("Do you Really Want To delete this Record", "Choose One", MessageBoxButtons.YesNo);
            //            if (dialogResult == DialogResult.Yes)
            //            {
            //                // MessageBox.Show("Yeah It Came Here");
            //                string query = "DELETE FROM Daily_Reciept_Expense WHERE(Reciept_Account = '" + acc + "') AND(Ammount_Recieved = '" + amm + "') AND(Payment_Mode_R = '" + pm + "') AND(Description_R = '" + desc + "') AND(Date = '" + dat + "')";
            //                SqlConnection con = new SqlConnection(variables.cons);
            //                con.Open();
            //                SqlCommand cmd = new SqlCommand(query, con);
            //                SqlDataReader read;
            //                read = cmd.ExecuteReader();

            //                con.Close();
            //                loaddata_R();

            //                MessageBox.Show("Reciept Deleted Successfuly");


            //            }
            //            else if (dialogResult == DialogResult.No)
            //            {
            //                //do something else
            //            }







            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }

            //    }
            //    else
            //    {
            //        if (acc == "Cash Forward")
            //        {

            //            try
            //            {


            //                DialogResult dialogResult = MessageBox.Show("Do you Really Want To delete this Cash Forward", "Choose One", MessageBoxButtons.YesNo);
            //                if (dialogResult == DialogResult.Yes)
            //                {
            //                    // MessageBox.Show("Yeah It Came Here");
            //                    string query = "DELETE FROM Daily_Reciept_Expense WHERE(Reciept_Account = '" + acc + "') AND(Ammount_Recieved = '" + amm + "')  AND(Date = '" +dat+ "')";
            //                    SqlConnection con = new SqlConnection(variables.cons);
            //                    con.Open();
            //                    SqlCommand cmd = new SqlCommand(query, con);
            //                    SqlDataReader read;
            //                    read = cmd.ExecuteReader();

            //                    con.Close();
            //                    loaddata_R();

            //                    MessageBox.Show("Reciept Deleted Successfuly");


            //                }
            //                else if (dialogResult == DialogResult.No)
            //                {
            //                    //do something else
            //                }







            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message);
            //            }

            //        }




            //    }








            //}


        }

        private void DataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            this.dataGridView2.Rows[e.RowIndex].Cells["Sr_no1"].Value = (e.RowIndex + 1).ToString();

        }

        private void Label25_Click(object sender, EventArgs e)
        {
            yearly = false;
            monthlyload();
            
        }

        private void Label26_Click(object sender, EventArgs e)
        {
            monthly = false;
            yearlyload();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            //monthly left date
            a = groupBox1.Text.Remove(0, 10);
            b = groupBox2.Text.Remove(0, 10);

            var n = Convert.ToDateTime(a);
            var n1 = Convert.ToDateTime(b);

           
            groupBox1.Text = "[Reciepts]" + n.AddMonths(-1).ToString("M/dd/yyyy");
            groupBox2.Text = "[Expenses]" + n.AddMonths(-1).ToString("M/dd/yyyy");
            monthlyload();


        }

        private void Button14_Click(object sender, EventArgs e)
        {
            //monthly right month

            a = groupBox1.Text.Remove(0, 10);
            b = groupBox2.Text.Remove(0, 10);

            var n = Convert.ToDateTime(a);
            var n1 = Convert.ToDateTime(b);


            groupBox1.Text = "[Reciepts]" + n.AddMonths(1).ToString("M/dd/yyyy");
            groupBox2.Text = "[Expenses]" + n.AddMonths(1).ToString("M/dd/yyyy");
            monthlyload();

        }

        private void Button15_Click(object sender, EventArgs e)
        {
            //yerly acc right year
            a = groupBox1.Text.Remove(0, 10);
            b = groupBox2.Text.Remove(0, 10);

            var n = Convert.ToDateTime(a);
            var n1 = Convert.ToDateTime(b);


            groupBox1.Text = "[Reciepts]" + n.AddYears (1).ToString("M/dd/yyyy");
            groupBox2.Text = "[Expenses]" + n.AddYears(1).ToString("M/dd/yyyy");
            yearlyload();

        }

        private void Button16_Click(object sender, EventArgs e)
        {
            //yarly Left Year
            a = groupBox1.Text.Remove(0, 10);
            b = groupBox2.Text.Remove(0, 10);

            var n = Convert.ToDateTime(a);
            var n1 = Convert.ToDateTime(b);


            groupBox1.Text = "[Reciepts]" + n.AddYears(-1).ToString("M/dd/yyyy");
            groupBox2.Text = "[Expenses]" + n.AddYears(-1).ToString("M/dd/yyyy");
            yearlyload();

        }

        private void DateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            //monthly date picker

            DateTime n = Convert.ToDateTime(dateTimePicker4.Text);
            groupBox1.Text = "[Reciepts]" + n.ToString("M/dd/yyyy");
            groupBox2.Text = "[Expenses]" + n.ToString("M/dd/yyyy");

            label27.Text = n.ToString("MMMM  yyyy");
            label28.Text = n.ToString("MMMM  yyyy");

            monthlyload();
        }

        private void DateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            //yearly date time pick

            DateTime n = Convert.ToDateTime(dateTimePicker5.Text);
            groupBox1.Text = "[Reciepts]" + n.ToString("M/dd/yyyy");
            groupBox2.Text = "[Expenses]" + n.ToString("M/dd/yyyy");

            label27.Text = n.ToString("yyyy");
            label28.Text = n.ToString("yyyy");

            yearlyload();

        }

        private void ComboBox6_TextChanged(object sender, EventArgs e)
        {
            textBox8.Text = comboBox6.Text;
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            
            groupBox4.Visible = true;

            button10.Visible = false;
            //button18.Visible = true;
            /////
            button4.Visible = false;
            dataGridView2.Visible = false;
        }

        private void Button18_Click(object sender, EventArgs e)
        {
            editData();
            loaddata_E();









            groupBox4.Visible = false;
            button10.Visible = true;
            button18.Visible = true;
            button19.Visible = false;
            button17.Visible = false;



            /////
            button4.Visible = true;
            dataGridView2.Visible = true;
        }

        void monthlyload()
        {
            daily = false;
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            monthly = true;

            string date = groupBox1.Text.Remove(0, 10);
            var n = Convert.ToDateTime(date);
            label27.Text = n.ToString("MMMM  yyyy");
            label28.Text = n.ToString("MMMM  yyyy");
            reciepts = 0;
            expense = 0;

            //SELECT    Expense_Account AS [Expense Account], Ammount_Paid  AS [Paid Ammount],Description_E,Date,Sub_Head,Quantity,Price_per_unit,Paid_to,ID FROM Daily_Expense   WHERE(Date = '" + date + "') ";

            string query = "SELECT        Reciept_Account , SUM( CAST( Ammount_Recieved AS int)) AS [Recieved] FROM Daily_Reciept_Expense   WHERE ( MONTH(Date) = '" + n.Month.ToString() + "' AND NOT  Reciept_Account='Cash Forward')OR(MONTH(Date) ='" + n.Month.ToString() + "'AND DAY(Date)=1 AND Reciept_Account  ='Cash Forward'  ) GROUP BY Reciept_Account; ";



            string query1 = "SELECT  Expense_Account AS [Expense Account] ,   SUM( CAST( Ammount_Paid AS int)) AS [Paid]  FROM Daily_Expense  WHERE MONTH(Date) = '" + n.Month.ToString() + "'  GROUP BY Expense_Account; ";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();

            DataTable t = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);

            DataTable t1 = new DataTable();
            SqlDataAdapter ad1 = new SqlDataAdapter(query1, con);

            ad.Fill(t);
             ad1.Fill(t1);

            dataGridView1.DataSource = t;
            dataGridView2.DataSource = t1;











            /////////////////
            //Total for Reciepts



            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {

                reciepts = reciepts + Convert.ToInt32(dataGridView1.Rows[i].Cells["Recieved"].Value);



            }
            label6.Text = "Total Ammount  " + reciepts;
            textBox2.Text = reciepts.ToString();

            textBox4.Text = Convert.ToString(Convert.ToInt64(textBox2.Text) - Convert.ToInt64(textBox3.Text));

            if (Convert.ToInt64(textBox4.Text) > 0)
            {
                textBox1.Text = textBox4.Text;
            }
            else
            {
                textBox1.Text = "0";

            }



            //////////
            //Total For Expenses

            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {

                expense = expense + Convert.ToInt32(dataGridView2.Rows[i].Cells["Paid"].Value);



            }
            label7.Text = "Total Ammount  " + expense;
            textBox3.Text = expense.ToString();


            textBox4.Text = Convert.ToString(Convert.ToInt64(textBox2.Text) - Convert.ToInt64(textBox3.Text));

            if (Convert.ToInt64(textBox4.Text) > 0)
            {
                textBox1.Text = textBox4.Text;
            }
            else
            {
                textBox1.Text = "0";

            }













        }



        /////

      void yearlyload()
        {
            yearly = true;
            string date = groupBox1.Text.Remove(0, 10);
            var n = Convert.ToDateTime(date);
            label27.Text = n.ToString("yyyy");
            label28.Text = n.ToString("yyyy");
            reciepts = 0;
            expense = 0;



            string query = "SELECT        Reciept_Account , SUM( CAST( Ammount_Recieved AS int)) AS [Recieved] FROM Daily_Reciept_Expense   WHERE (YEAR(Date) = '" + n.Year.ToString() + "' AND NOT  Reciept_Account='Cash Forward') OR(YEAR(Date) ='" + n.Year.ToString() + "'AND DAY(Date)=1 AND Reciept_Account  ='Cash Forward'  )   GROUP BY Reciept_Account; ";



            string query1 = "SELECT  Expense_Account AS [Expense Account] ,   SUM( CAST( Ammount_Paid AS int)) AS [Paid]  FROM Daily_Expense  WHERE Year(Date) = '" + n.Year.ToString() + "'  GROUP BY Expense_Account; ";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();

            DataTable t = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);

            DataTable t1 = new DataTable();
            SqlDataAdapter ad1 = new SqlDataAdapter(query1, con);

            ad.Fill(t);
            ad1.Fill(t1);

            dataGridView1.DataSource = t;
            dataGridView2.DataSource = t1;











            /////////////////
            //Total for Reciepts



            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {

                reciepts = reciepts + Convert.ToInt32(dataGridView1.Rows[i].Cells["Recieved"].Value);



            }
            label6.Text = "Total Ammount  " + reciepts;
            textBox2.Text = reciepts.ToString();

            textBox4.Text = Convert.ToString(Convert.ToInt64(textBox2.Text) - Convert.ToInt64(textBox3.Text));

            if (Convert.ToInt64(textBox4.Text) > 0)
            {
                textBox1.Text = textBox4.Text;
            }
            else
            {
                textBox1.Text = "0";

            }



            //////////
            //Total For Expenses

            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {

                expense = expense + Convert.ToInt32(dataGridView2.Rows[i].Cells["Paid"].Value);



            }
            label7.Text = "Total Ammount  " + expense;
            textBox3.Text = expense.ToString();


            textBox4.Text = Convert.ToString(Convert.ToInt64(textBox2.Text) - Convert.ToInt64(textBox3.Text));

            if (Convert.ToInt64(textBox4.Text) > 0)
            {
                textBox1.Text = textBox4.Text;
            }
            else
            {
                textBox1.Text = "0";

            }












        }

        private void Button19_Click(object sender, EventArgs e)
        {
            deleteData();
            loaddata_E();

            groupBox4.Visible = false;
            button10.Visible = true;
            button18.Visible = true;
            button19.Visible = false;
            button17.Visible = false;



            /////
            button4.Visible = true;
            dataGridView2.Visible = true;

        }

        private void Button20_Click(object sender, EventArgs e)
        {


            //
            groupBox3.Visible = true;
            button7.Visible = false;

            ///////
            button3.Visible = false;
            dataGridView1.Visible = false;
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            deletedataR();
            loaddata_R();


            //
            //
            groupBox3.Visible = false;
            button20.Visible = false;
            button21.Visible = false;

            button7.Visible = true;
            button22.Visible = true;
            /////

            button3.Visible = true;
            dataGridView1.Visible = true;

        }

        void editData()
        {
            try
            {
                string query = "UPDATE       Daily_Expense SET                Expense_Account = '"+comboBox6.Text+"', Ammount_Paid = '"+textBox9.Text+"', Description_E = '"+textBox8.Text+"', Date = '"+ Convert.ToDateTime(dateTimePicker3.Text).ToString("M/dd/yyyy") + "', Sub_Head = '"+comboBox4.Text+"', Quantity = '"+textBox10.Text+"', Paid_to = '"+textBox12.Text+"', Price_per_unit = '"+textBox11.Text+"' WHERE        (ID = '"+textBox13.Text+"')";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read;
                read = cmd.ExecuteReader();

                con.Close();
                MessageBox.Show("Updated Successfully");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void Button22_Click(object sender, EventArgs e)
        {
            editdataR();
            loaddata_R();
            
            
            
            //
            groupBox3.Visible = false;
            button20.Visible = false;
            button21.Visible = false;

            button7.Visible = true;
            button22.Visible = true;
            /////

            button3.Visible = true;
            dataGridView1.Visible = true;
        }

        void deleteData()
        {
            if (textBox13.Text != "")
            {
                try
                {
                    string query = "DELETE FROM Daily_Expense WHERE (ID = '"+ textBox13.Text + "')";
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read;
                    read = cmd.ExecuteReader();

                    con.Close();
                    MessageBox.Show("Deleted Successfully");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

         }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void editdataR()
        {
            try
            {
                string query = "UPDATE   Daily_Reciept_Expense SET   Reciept_Account = '"+comboBox1.Text+"', Ammount_Recieved = '"+textBox6.Text+ "', Date = '" + Convert.ToDateTime(dateTimePicker2.Text).ToString("M/dd/yyyy") + "', Description_R = '"+textBox7.Text+"' WHERE  (ID = '"+textBox14.Text+"')";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read;
                read = cmd.ExecuteReader();

                con.Close();
                MessageBox.Show("Updated Successfully");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void deletedataR()
        {
            try
            {
                string query = "DELETE FROM Daily_Reciept_Expense WHERE(ID = '"+textBox14.Text+"')";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read;
                read = cmd.ExecuteReader();

                con.Close();
                MessageBox.Show("Deleted Successfully");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }






    }
}
