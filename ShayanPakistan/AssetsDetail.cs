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
    public partial class AssetsDetail : Form
    {
        string id;
        public AssetsDetail(string a)
        {
            InitializeComponent();
            id = a;
        }
        private void AssetsDetail_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(variables.cons);
            string query = "select ID,ExpensHeadName as [Asset Name],Name,Brand,Color,Quantity,Date,TotalPrice,UnitPrice,VendorName,Image from AssetDetail where ExpensHeadName = '" + id +"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query,con);

            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();

                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["Asset Name"].Visible = false;
                dataGridView1.Columns["TotalPrice"].Visible = false;
                dataGridView1.Columns["UnitPrice"].Visible = false;
                dataGridView1.Columns["VendorName"].Visible = false;
                dataGridView1.Columns["Image"].Visible = false;
                //dataGridView1.Columns["Expenses_Head"].Width = 150;
            }
            con.Close();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            AddNewAssetsOrDetailUpdate addNewAssetsOrDetailUpdate = new AddNewAssetsOrDetailUpdate(null,null,null,null,null,null,null,null,null,null);
            addNewAssetsOrDetailUpdate.Show();
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string SbHead = "";
            string Name = "";
            string Brand = "";
            string Color = "";
            string Quantity = "";
            string Date = "";
            string ttPrice = "";
            string UtPrice = "";
            string VendName = "";
            string img = "";
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                SbHead = row.Cells[1].Value.ToString();
                Name = row.Cells[2].Value.ToString();
                Brand = row.Cells[3].Value.ToString();
                Color = row.Cells[4].Value.ToString();
                Quantity = row.Cells[5].Value.ToString();
                Date = row.Cells[6].Value.ToString();
                ttPrice = row.Cells[7].Value.ToString();
                UtPrice = row.Cells[8].Value.ToString();
                VendName = row.Cells[9].Value.ToString();
                img = row.Cells[10].Value.ToString();
            }
                 
            AddNewAssetsOrDetailUpdate addNewAssetsOrDetailUpdate = new AddNewAssetsOrDetailUpdate(SubHead:SbHead,Name:Name,brand:Brand,Color:Color,Qty:Quantity,dt: Date,totalPrice:ttPrice,unitPrice:UtPrice,VendorName:VendName,imag:img);
            addNewAssetsOrDetailUpdate.Show();
        }
    }
}
