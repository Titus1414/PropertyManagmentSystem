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
    public partial class AssetsReport : Form
    {
        public AssetsReport()
        {
            InitializeComponent();
        }

        private void AssetsReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData() {
            groupBox1.Visible = false;
            button1.Visible = true;
            button3.Visible = false;
            SqlConnection con = new SqlConnection(variables.cons);
            string query = "select * from Assets";
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            //dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["AssetName"].Width = 150;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            string nm = row.Cells["AssetName"].Value.ToString();
            //int id = Convert.ToInt32(nm);
            AssetsDetail assetsDetail = new AssetsDetail(nm);
            assetsDetail.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            button1.Visible = false;
            button3.Visible = true;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            string query = "Insert into Assets (AssetName) values('" + textBox1.Text+"')";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteReader();
            con.Close();
            MessageBox.Show("Saved Successfully");
            textBox1.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
