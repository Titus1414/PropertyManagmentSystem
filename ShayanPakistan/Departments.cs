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

namespace ShayanPakistan
{
    public partial class Departments : Form
    {
        // Fill ComboBox
        void filcombo()
        {
            string query = "SELECT DISTINCT Departments FROM Shayan_Department";
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
                       comboBox1.Items.Add(myread.GetValue(0).ToString());
                    }
                }
                myread.Close();
            }
            catch (Exception )
            {
            }
        }
        void load()
        {
            string query = "SELECT Departments FROM Shayan_Department";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Width = 250;


            filcombo();
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
            public Departments()
        {
            InitializeComponent();
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT Departments,Division as Divisions FROM Shayan_Department order by Division desc ";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Width = 180;
                dataGridView1.Columns[2].Width = 180;

                filcombo();
                comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
                button3.Visible = false;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[2].Value.ToString() == "S&GAD")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(105, 105, 105);
                        row.DefaultCellStyle.ForeColor = Color.White;

                    }
                    else if (row.Cells[2].Value.ToString() == "Marketing")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 172, 0);
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else if (row.Cells[2].Value.ToString() == "Buliding")
                    {
                        row.DefaultCellStyle.BackColor = Color.Gray;
                    }
                    else if (row.Cells[2].Value.ToString() == "I.T")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }

                dataGridView1.ClearSelection();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT Departments,Division as Divisions FROM Shayan_Department order by Division desc";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 180;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[2].Value.ToString() == "S&GAD")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(105, 105, 105);
                }
                else if (row.Cells[2].Value.ToString() == "Marketing")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(230, 172, 0);
                }
                else if (row.Cells[2].Value.ToString() == "Buliding")
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                }
                else if (row.Cells[2].Value.ToString() == "I.T")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }
        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            AddNewDept newDept = new AddNewDept();
            newDept.Show();
        }
        
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        //Cell Click of Grid
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string nm = row.Cells["Departments"].Value.ToString();
                Form7 obj = new Form7(nm);
                obj.Show();
            }
        }
        //Visibility
        private void Button4_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            dataGridView1.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = true;

        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }
        //DELETE FROM Shayan_Department
        private void Button5_Click_1(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = true;
            dataGridView1.Visible = true;

            //button3.Visible = false;
            groupBox1.Visible = false;

            groupBox2.Visible = false;


            // groupBox2.Visible = false;

            if (comboBox1.Text != "")
            {
                string query = "DELETE FROM Shayan_Department WHERE(Departments = '" + comboBox1.Text + "')";
                // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader read;
                read = cmd.ExecuteReader();
                con.Close();
                load();
                MessageBox.Show("Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Please Select a department");
            }

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Departments newDept = new Departments();
            newDept.Show();
        }
    }
}
