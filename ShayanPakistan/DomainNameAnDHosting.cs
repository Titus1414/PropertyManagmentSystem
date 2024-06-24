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
using DGVPrinterHelper;

namespace ShayanPakistan
{
    public partial class DomainNameAnDHosting : Form
    {
        int j, k = 0;
       
        public DomainNameAnDHosting()
        {
            InitializeComponent();
        }

        private void DomainNameAnDHosting_Load(object sender, EventArgs e)
        {
            loaddata();

        }


        void loaddata()
        {
            label14.UseMnemonic = false;

            string query = "SELECT DomainName, ExpiryDate, RenewalDate, OwnerName, ServerName, Status,ID FROM Domain_Names where Status = 'Ok'";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            dataGridView1.Columns["DomainName"].Width = 200;
            dataGridView1.Columns["OwnerName"].Width = 140;
            dataGridView1.Columns["ServerName"].Width = 150;
            dataGridView1.Columns["ExpiryDate"].Width = 150;
            dataGridView1.Columns["RenewalDate"].Width = 150;
            dataGridView1.Columns["RD"].Width = 150;

            dataGridView1.Columns["RD"].DisplayIndex = 7;
            dataGridView1.Columns["ID"].Visible = false;

            dataGridView1.ClearSelection();
            j = 0; k = 0;
            for(int i =0;i<dataGridView1.Rows.Count;i++)
            {
                if(dataGridView1.Rows[i].Cells["Status"].Value.ToString()=="OK")
                {
                    j++;
                }
                else
                {
                    k++;

                }

            }

            label10.Text = "Active Domains   " + j;
            label11.Text = "Unactive And Other  Domains " + k;
            label13.Text = "Total Domains  " + dataGridView1.Rows.Count;
            remainingdays();


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button5.Visible = false;
            groupBox1.Visible = true;

            button6.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            groupBox1.Visible = false;

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            insertdata();
            loaddata();

            button1.Visible = true;
            button5.Visible = true;
            groupBox1.Visible = false;


           
        }



        void insertdata()
        {
            if (textBox1.Text != "")
            {

                string query = "INSERT INTO Domain_Names (DomainName, OwnerName, ServerName, RenewalDate, ExpiryDate, Status) VALUES('" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "', '" + textBox3.Text.Trim() + "', '" + dateTimePicker1.Text + "', '" + dateTimePicker2.Text + "', '" + comboBox1.Text.Trim() + "')";
                try
                {

                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read;
                    read = cmd.ExecuteReader();

                    con.Close();

                    MessageBox.Show("Record(s) Saved Successfully");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Kindly Enter Domain Name Please");
            }

        }

        void remainingdays()
        {
            for(int i=0;i<dataGridView1.Rows.Count;i++)
            {
                
                DateTime expirydate = new DateTime(); 
                expirydate = Convert.ToDateTime(dataGridView1.Rows[i].Cells["ExpiryDate"].Value).Date;
                DateTime curdate = DateTime.Now.Date;

                TimeSpan t = expirydate.Subtract(curdate);


                dataGridView1.Rows[i].Cells["RD"].Value = t.TotalDays.ToString();

                if (Convert.ToInt64(dataGridView1.Rows[i].Cells["RD"].Value.ToString()) <= Convert.ToInt64("60") && Convert.ToInt64(dataGridView1.Rows[i].Cells["RD"].Value.ToString()) > Convert.ToInt64("0"))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(255, 69, 0);
                }
                else if(Convert.ToInt64(dataGridView1.Rows[i].Cells["RD"].Value.ToString()) < Convert.ToInt64("1"))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(220, 20, 60);
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }





            }



        }

        private void Button4_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            groupBox1.Visible = false;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                idbox.Text=row.Cells["ID"].Value.ToString();
                textBox1.Text = row.Cells["DomainName"].Value.ToString();
                textBox2.Text = row.Cells["OwnerName"].Value.ToString();
                textBox3.Text = row.Cells["ServerName"].Value.ToString();
                comboBox1.Text = row.Cells["Status"].Value.ToString();
                dateTimePicker1.Text =   row.Cells["RenewalDate"].Value.ToString();
                dateTimePicker2.Text =   row.Cells["ExpiryDate"].Value.ToString();

                button5.Visible = true;
                


             }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button5.Visible = false;
            groupBox1.Visible = true;
            button3.Visible = false;

        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            editdata();
            loaddata();


            button1.Visible = true;
            button5.Visible = true;
            groupBox1.Visible = false;





        }

        private void Button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns["DomainName"].AutoSizeMode= DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["OwnerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; 
            dataGridView1.Columns["ServerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; 
            dataGridView1.Columns["ExpiryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; 
            dataGridView1.Columns["RenewalDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; 
            dataGridView1.Columns["RD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


            //
            MessageBox.Show("Sent For Printing Successfully");
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Domain Name & Hosting";
            printer.SubTitle = String.Format(DateTime.Now.Date.ToString("dddd , MMMM  dd,yyyy"));
           // printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PrintDataGridView(dataGridView1);



            dataGridView1.Columns["DomainName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["OwnerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["ServerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["ExpiryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["RenewalDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["RD"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns["DomainName"].Width = 200;
            dataGridView1.Columns["OwnerName"].Width = 140;
            dataGridView1.Columns["ServerName"].Width = 150;
            dataGridView1.Columns["ExpiryDate"].Width = 150;
            dataGridView1.Columns["RenewalDate"].Width = 150;
            dataGridView1.Columns["RD"].Width = 150;

        
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            ExpireDomains exp = new ExpireDomains();
            exp.Show();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            OtherDomains ot = new OtherDomains();
            ot.Show();
        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Idbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void editdata()
        {
            try
            {
                string query = "UPDATE       Domain_Names SET                DomainName = '"+textBox1.Text+"', ExpiryDate = '"+dateTimePicker2.Text+ "', RenewalDate = '" + dateTimePicker1.Text + "', OwnerName = '"+textBox2.Text.Trim()+ "', ServerName = '" + textBox3.Text.Trim() + "', Status = '"+comboBox1.Text.Trim()+"' WHERE  (ID = '" + idbox.Text+"')";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read;
                read = cmd.ExecuteReader();

                con.Close();
                MessageBox.Show("Updated Successfully");


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }





    }
}
