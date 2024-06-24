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
    public partial class OtherDomains : Form
    {
        int j, k = 0;
        public OtherDomains()
        {
            InitializeComponent();
        }

        void loaddata()
        {
            label14.UseMnemonic = false;

            string query = "SELECT DomainName, ExpiryDate, RenewalDate, OwnerName, ServerName, Status,ID FROM Domain_Names where Status = 'Other'";
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
            //
            //dataGridView1.Columns["RD"].DisplayIndex = 7;
            dataGridView1.Columns["ID"].Visible = false;

            dataGridView1.ClearSelection();
            j = 0; k = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Status"].Value != null)
                {
                    if (dataGridView1.Rows[i].Cells["Status"].Value.ToString() == "Other")
                    {
                        j++;
                    }
                    else if (dataGridView1.Rows[i].Cells["Status"].Value.ToString() == "OK")
                    {
                        k++;
                    }
                }
            }

            label10.Text = "Other Domains   " + j;
            //label11.Text = "Unactive And Other  Domains " + k;
            //label13.Text = "Total Domains  " + dataGridView1.Rows.Count;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void OtherDomains_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            DomainNameAnDHosting dmd = new DomainNameAnDHosting();
            dmd.Show();
        }
        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            ExpireDomains exp = new ExpireDomains();
            exp.Show();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
