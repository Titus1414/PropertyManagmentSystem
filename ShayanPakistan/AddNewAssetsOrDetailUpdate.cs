using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShayanPakistan
{
    public partial class AddNewAssetsOrDetailUpdate : Form
    {
        string imgloc = "";
        public AddNewAssetsOrDetailUpdate(string SubHead,string Name, string brand, string Color, string Qty, string dt,string totalPrice,string unitPrice, string VendorName,string imag)
        {
            InitializeComponent();
            LoadCombo();
            textBox5.Visible = false;

            if (!string.IsNullOrEmpty(SubHead))
            {
                comboBox1.Text = VendorName;
                comboBox2.Text = SubHead;
                textBox1.Text = Name;
                textBox2.Text = Qty;
                textBox3.Text = Color;
                textBox4.Text = brand;
                textBox6.Text = totalPrice;
                textBox7.Text = unitPrice;
                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                string MyImg = path + "\\AssetsImages\\" + imag;
                pictureBox1.Image = Image.FromFile(@"" + MyImg + "");
            }

        }
        

        private void AddNewAssetsOrDetailUpdate_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(* .jpg)|*.jpg|GIF Files (* .gif)| * .gif|All Files(*.*)|*.*";
                dlg.Title = "Select Asset Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    imgloc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgloc;
                    textBox5.Text = imgloc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(dateTimePicker1.Text);

            string PicName = Path.GetFileName(textBox5.Text);
            if (!string.IsNullOrEmpty(PicName))
            {
                string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                File.Copy(textBox5.Text, Path.Combine(path + "\\AssetsImages\\", Path.GetFileName(textBox5.Text)), true);
            }

            string query = "Insert into AssetDetail (ExpensHeadName,VendorName,Quantity,Color,Brand,TotalPrice,UnitPrice,IsActive,Image,Name,Date) values('" + comboBox2.Text +"','"+ comboBox2.Text + "',"+textBox2.Text+",'"+textBox3.Text+"','"+textBox4.Text+"',"+ textBox6.Text + ","+ textBox7.Text + ",1,'"+ PicName + "','"+ textBox1.Text + "','" + dt + "')";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteReader();
            con.Close();
            MessageBox.Show("Saved Successfully");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        void LoadCombo() {

            SqlConnection con = new SqlConnection(variables.cons);
            SqlCommand sqlCmd = new SqlCommand("select * from Vendors", con);
            SqlCommand sqlCmd1 = new SqlCommand("select * from Assets", con);
            con.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                comboBox1.Items.Add(sqlReader["Name"].ToString());
            }
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            sqlReader.Close();
            SqlDataReader sqlReader1 = sqlCmd1.ExecuteReader();
            while (sqlReader1.Read())
            {
                comboBox2.Items.Add(sqlReader1["AssetName"].ToString());
                comboBox2.DisplayMember = "AssetName";
                comboBox2.ValueMember = "ID";
            }
            sqlReader1.Close();
            con.Close();
        }

    }
}
