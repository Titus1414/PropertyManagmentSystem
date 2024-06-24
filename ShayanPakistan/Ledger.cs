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
    //location 480, 85
    public partial class Ledger : Form
    {
        

        public Ledger(string heading)
        {
            InitializeComponent();
            label6.Text = heading;
        }

        private void Ledger_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("MMMM,yyyy");
            loaddata(label6.Text);

            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // right date click

            label1.Text = (Convert.ToDateTime(label1.Text).AddMonths(1)).ToString("MMMM,yyyy");
            loaddata(null);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //left click date
            label1.Text = (Convert.ToDateTime(label1.Text).AddMonths(-1)).ToString("MMMM,yyyy");
            loaddata(null);
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //date callender
            label1.Text = Convert.ToDateTime(dateTimePicker1.Text).ToString("MMMM,yyyy");
            loaddata(null);

        }


        void loaddata(string a)
        {
            
            
                int n = 0;
                //int n1 = 0;
            //
            //Datagrid 2 mn reciept

            // string query = "SELECT    Day(CAST (Date AS datetime)) AS [Day], SUM( CAST (Ammount_Paid AS int) ) AS [Given] FROM Daily_Expense  WHERE Expense_Account='" + comboBox1.Text + "' AND MONTH(CAST (Date AS datetime))= '" + Convert.ToDateTime(label1.Text).ToString("MM") + "' AND YEAR(CAST (Date AS datetime))='" + Convert.ToDateTime(label1.Text).ToString("yyyy") + "' GROUP BY Expense_Account , Date ";
            string query = "SELECT   CONVERT(VARCHAR(6),(DATENAME(DAY, Date) + ' ' + DATENAME(MONTH, Date)),106) AS [Day], Paid_to AS [Paid TO],Sub_Head AS[Descrip] ,Quantity AS [Qty],Price_per_unit AS [U.P] ,Ammount_Paid  AS [Ammount Paid] FROM Daily_Expense  WHERE  (Expense_Account like '%" + label6.Text.Trim() + "%'  AND MONTH(CAST (Date AS datetime))= '" + Convert.ToDateTime(label1.Text).ToString("MM") + "') AND YEAR(CAST (Date AS datetime))='" + Convert.ToDateTime(label1.Text).ToString("yyyy") + "'   OR Sub_Head like '%" + label6.Text + "%' OR Paid_to like '%" + label6.Text + "%' OR Description_E like '%" + label6.Text.Trim() + "%'";// ORDER BY Date ASC";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
          //  MessageBox.Show(Convert.ToDateTime(label1.Text).ToString("MM"));


                ///
                // Datagrid 1 mn reciepts
                // string query1 = "SELECT   Day(CAST (Date AS datetime)) AS [Day],  SUM( CAST (Ammount_Recieved AS int) ) AS [Recieved] FROM Daily_Reciept_Expense  WHERE Reciept_Account='" + comboBox1.Text + "' AND MONTH(CAST (Date AS datetime))= '" + Convert.ToDateTime(label1.Text).ToString("MM") + "' AND YEAR(CAST (Date AS datetime))='" + Convert.ToDateTime(label1.Text).ToString("yyyy") + "' GROUP BY  Reciept_Account  , Date  ;";
                ////string query1 = "SELECT    Reciept_Account AS [Particulars], SUM( CAST (Ammount_Recieved AS int) ) AS [Debit] FROM Daily_Reciept_Expense  WHERE MONTH(CAST (Date AS datetime))= '" + Convert.ToDateTime(label1.Text).ToString("MM") + "' AND YEAR(CAST (Date AS datetime))='" + Convert.ToDateTime(label1.Text).ToString("yyyy") + "' GROUP BY  Reciept_Account ;";
                //SqlConnection con1 = new SqlConnection(variables.cons);
                //con1.Open();
                //DataTable dt1 = new DataTable();
                //SqlDataAdapter ad1 = new SqlDataAdapter(query1, con1);
                //ad1.Fill(dt1);
                //dataGridView1.DataSource = dt1;
                //con1.Close();

                //for(int i=0;i<dataGridView2.Rows.Count;i++)
                //{

                //       n=n+Convert.ToInt32(dataGridView2.Rows[i].Cells["Given"].Value);


                //}
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{

                //    n1 = n1 + Convert.ToInt32(dataGridView1.Rows[i].Cells["Recieved"].Value);


                //}

                //textBox1.Text = n1.ToString();
                //textBox2.Text = n.ToString();
                //textBox3.Text = (n1 - n).ToString();
               // dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
            //dataGridView1.Columns[0].Width = 65;
            //dataGridView2.Columns[0].Width = 65;




            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                n = n + Convert.ToInt32(dataGridView2.Rows[i].Cells["Ammount Paid"].Value);


            }

            label2.Text = "Grand Total = "+n.ToString();

            dataGridView2.Columns[0].Width = 90;
            dataGridView2.Columns[1].Width = 210;

        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
           // this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }

        private void DataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //this.dataGridView2.Rows[e.RowIndex].Cells["Sr_no1"].Value = (e.RowIndex + 1).ToString();
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            loaddata(null);
            label6.Text = comboBox1.Text;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
