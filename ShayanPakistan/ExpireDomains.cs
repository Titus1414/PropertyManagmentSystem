using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShayanPakistan
{
    public partial class ExpireDomains : Form
    {
        int j, k = 0;
        public ExpireDomains()
        {
            InitializeComponent();
        }

        void loaddata()
        {
            groupBox1.Visible = false;
            label14.UseMnemonic = false;

            string query = "SELECT OwnerName,DomainName,ServerName,ExpiryDate,RenewalDate, Status,ID FROM Domain_Names where Status = 'Expire'";
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
            //dataGridView1.Columns["RD"].Width = 150;
            
            //dataGridView1.Columns["RD"].DisplayIndex = 7;
            dataGridView1.Columns["ID"].Visible = false;

            dataGridView1.ClearSelection();
            j = 0; k = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Status"].Value != null)
                {
                    if (dataGridView1.Rows[i].Cells["Status"].Value.ToString() == "Expire")
                    {
                        j++;
                    }
                    else if (dataGridView1.Rows[i].Cells["Status"].Value.ToString() == "OK")
                    {
                        k++;
                    }
                }
            }

            label10.Text = "Expire Domains   " + j;
            //label11.Text = "Unactive And Other  Domains " + k;
            //label13.Text = "Total Domains  " + dataGridView1.Rows.Count;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            DomainNameAnDHosting dmd = new DomainNameAnDHosting();
            dmd.Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            OtherDomains ot = new OtherDomains();
            ot.Show();
        }

        private void ExpireDomains_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //button1.Visible = false;
            //button5.Visible = false;
            groupBox1.Visible = true;
            //button3.Visible = false;
        }
        void editdata()
        {
            try
            {
                string query = "UPDATE       Domain_Names SET                DomainName = '" + textBox1.Text + "', ExpiryDate = '" + dateTimePicker2.Text + "', RenewalDate = '" + dateTimePicker1.Text + "', OwnerName = '" + textBox2.Text.Trim() + "', ServerName = '" + textBox3.Text.Trim() + "', Status = '" + comboBox1.Text.Trim() + "' WHERE  (ID = '" + idbox.Text + "')";
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

        private void Button6_Click(object sender, EventArgs e)
        {
            editdata();
            loaddata();
            groupBox1.Visible = false;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                idbox.Text = row.Cells["ID"].Value.ToString();
                textBox1.Text = row.Cells["DomainName"].Value.ToString();
                textBox2.Text = row.Cells["OwnerName"].Value.ToString();
                textBox3.Text = row.Cells["ServerName"].Value.ToString();
                comboBox1.Text = row.Cells["Status"].Value.ToString();
                dateTimePicker1.Text = row.Cells["RenewalDate"].Value.ToString();
                dateTimePicker2.Text = row.Cells["ExpiryDate"].Value.ToString();

                button5.Visible = true;



            }
        }
    }
}
