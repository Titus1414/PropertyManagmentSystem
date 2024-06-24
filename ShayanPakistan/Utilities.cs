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
    public partial class Utilities : Form
    {
        public Utilities()
        {
            InitializeComponent();
           // loaddata();

            //

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        






        void loaddata()
        {try
            {

                string query1;//, query2, query3, query4;
                              // query1 = "SELECT        PhoneNumber, Owner, Address, BillAmmount AS [B.A], Status, LateSurcharge, ID FROM Utilities ORDER BY CASE WHEN Category='Telephone Bill'";
                              //query2 = "SELECT       MeterNo , Owner, Address, BillAmmount AS [B.A], Status, LateSurcharge, ID FROM Utilities WHERE(Category = 'SuiGas Bill')";
                              //query3 = "SELECT       MeterNo , Owner, Address, BillAmmount AS [B.A], Status, LateSurcharge, ID FROM Utilities WHERE(Category = 'Water Bill')";
                              //query4 = "SELECT       MeterNo , Owner, Address, BillAmmount AS [B.A], Status, LateSurcharge, ID FROM Utilities WHERE(Category = 'Electricity Bill')";
                query1 = "SELECT        PhoneNumber AS [Phone/Meter-No], Owner, Address, BillAmmount AS [Ammount], Status, LateSurcharge, ID  FROM Utilities  WHERE        (Month = '"+label3.Text+ "' OR Month = '')  ORDER BY CASE WHEN Category='Telephone Bill1' THEN 0 WHEN Category='Telephone Bill' THEN 1  WHEN Category='1' THEN 2	 WHEN Category='SuiGas Bill1' THEN 3 WHEN Category='SuiGas Bill' THEN 4  WHEN Category='2' THEN 5  WHEN Category='Water Bill1' THEN 6 WHEN Category='Water Bill' THEN 7 WHEN Category='3' THEN 8  WHEN Category='Electricity Bill1' THEN 9 WHEN Category='Electricity Bill'   THEN 10 END ";


                  SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt1 = new DataTable();
                //DataTable dt2 = new DataTable();
                //DataTable dt3 = new DataTable();
                //DataTable dt4 = new DataTable();


                SqlDataAdapter ad1 = new SqlDataAdapter(query1, con);
                //SqlDataAdapter ad2 = new SqlDataAdapter(query2, con);
                //SqlDataAdapter ad3 = new SqlDataAdapter(query3, con);
                //SqlDataAdapter ad4 = new SqlDataAdapter(query4, con);



                ad1.Fill(dt1);
                //ad2.Fill(dt2);
                //ad3.Fill(dt3);
                //ad4.Fill(dt4);

                telephoneGrid.DataSource = dt1;
                //gasGrid.DataSource = dt2;
                //waterGrid.DataSource = dt3;
                //electricgrid.DataSource = dt4;

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            telephoneGrid.Columns["ID"].Visible = false;
            //gasGrid.Columns["ID"].Visible = false;
            //waterGrid.Columns["ID"].Visible = false;
            //electricgrid.Columns["ID"].Visible = false;

            telephoneGrid.Columns["Address"].Width = 300;
            telephoneGrid.Columns["Ammount"].Width = 70;
            telephoneGrid.Columns["Status"].Width = 60;
            telephoneGrid.Columns["LateSurcharge"].Width = 80;
            telephoneGrid.Columns["Phone/Meter-No"].Width = 180;




            //gasGrid.Columns["Address"].Width = 300;
            //gasGrid.Columns["B.A"].Width = 60;
            //gasGrid.Columns["Status"].Width = 60;
            //gasGrid.Columns["LateSurcharge"].Width = 80;



            //waterGrid.Columns["Address"].Width = 300;
            //waterGrid.Columns["B.A"].Width = 60;
            //waterGrid.Columns["Status"].Width = 60;
            //waterGrid.Columns["LateSurcharge"].Width = 80;


            //electricgrid.Columns["Address"].Width = 300;
            //electricgrid.Columns["B.A"].Width = 60;
            //electricgrid.Columns["Status"].Width = 60;
            //electricgrid.Columns["LateSurcharge"].Width = 80;




            /////////////////////////////////// 
            telephoneGrid.EnableHeadersVisualStyles = false;
           // gasGrid.EnableHeadersVisualStyles = false;
            //waterGrid.EnableHeadersVisualStyles = false;
            //electricgrid.EnableHeadersVisualStyles = false;


            foreach (DataGridViewColumn column in telephoneGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //foreach (DataGridViewColumn column in gasGrid.Columns)
            //{
            //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
            //foreach (DataGridViewColumn column in waterGrid.Columns)
            //{
            //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
            //foreach (DataGridViewColumn column in electricgrid.Columns)
            //{
            //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            telephoneGrid.ClearSelection();
            //gasGrid.ClearSelection();
            //waterGrid.ClearSelection();
            //electricgrid.ClearSelection();



            foreach (DataGridViewRow row in telephoneGrid.Rows)
            {
                if (row.Cells["Phone/Meter-No"].Value.ToString() == "Telephone Bill" || row.Cells["Phone/Meter-No"].Value.ToString() == "SuiGas Bill" || row.Cells["Phone/Meter-No"].Value.ToString() == "Water Bill" || row.Cells["Phone/Meter-No"].Value.ToString() == "Electricity Bill")
                {
                    row.DefaultCellStyle.BackColor = Color.BurlyWood;
                }
            }




        }

        private void TelephoneGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.telephoneGrid.Rows[e.RowIndex].Cells["Tno"].Value = (e.RowIndex + 1).ToString();
        }

        private void GasGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.gasGrid.Rows[e.RowIndex].Cells["Gno"].Value = (e.RowIndex + 1).ToString();
        }

        private void WaterGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.waterGrid.Rows[e.RowIndex].Cells["Wno"].Value = (e.RowIndex + 1).ToString();
        }

        private void Electricgrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.electricgrid.Rows[e.RowIndex].Cells["Eno"].Value = (e.RowIndex + 1).ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {


                string query = "INSERT INTO Utilities (PhoneNumber, MeterNo, Category, BillAmmount, Status, Owner, Address, Month, LateSurcharge) VALUES('" + textBox1.Text.Trim() + "', '" + textBox1.Text.Trim() + "', '" + comboBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "', '" + comboBox2.Text.Trim() + "', '" + textBox3.Text.Trim() + "', '" + textBox4.Text.Trim() + "', '" + dateTimePicker1.Text + "', '" + textBox5.Text.Trim() + "')";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read;
                read = cmd.ExecuteReader();
                con.Close();

                MessageBox.Show("Inserted Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            loaddata();
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            loaddata();
            groupBox1.Visible = false;
            groupBox2.Visible = true;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void Utilities_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("MMMM yyyy");

            loaddata();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            label3.Text = Convert.ToDateTime(label3.Text).AddMonths(1).ToString("MMMM yyyy");
            loaddata();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            label3.Text = Convert.ToDateTime(label3.Text).AddMonths(-1).ToString("MMMM yyyy");
            loaddata();
        }
    }






}


    

