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
    public partial class BasicStaff : Form
    {
        int sal = 0;
        int Id = 0;
        public BasicStaff()
        {
            InitializeComponent();
        }

        private void BasicStaff_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.Text = "Basic Staff          " +DateTime.Now.ToString("dddd, MMMM dd , yyyy");
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;

            string query = "SELECT ID,Designation ,Department,Basic_Salary As [Basic Salary],Status,Priority FROM Basic_Staff_Table";
            //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            //this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Visible = false;
            this.dataGridView1.Columns[2].Width = 200;
            this.dataGridView1.Columns[3].Width = 200;
            this.dataGridView1.Columns[5].Width = 50;
            this.dataGridView1.Columns[6].Width = 50;

            label1.Text = label1.Text + dataGridView1.Rows.Count;
            dataGridView1.ClearSelection();
            salary();
           
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Add New 
            Groupbox1.Visible=true;
            Add_save.Visible = true;
            button4.Visible = false;
            dataGridView1.Visible = false;
            filcombo();
        }

        private void Add_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
                {
                    bool sts;
                    if (comboBox4.Text == "Yes")
                    {
                        sts = true;
                    } else
                    {
                        sts = false;
                    }
                    string query = "INSERT INTO Basic_Staff_Table (Department, Designation, Basic_Salary,Status,Priority) VALUES('" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + textBox1.Text + "',"+ sts + ","+ comboBox3.Text +")";
                    // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read;
                    read = cmd.ExecuteReader();

                    con.Close();
                    MessageBox.Show("Saved Successfuly");
                }
                else
                {

                    MessageBox.Show("Please Fill All the Requirements Thankyou");
                }
            }
            catch (Exception )
            {
               
                MessageBox.Show("Either Record is Already saved or Network Error");
               

            }
            loaddata();
            comboBox1.Text = comboBox2.Text = textBox1.Text = "";
            Groupbox1.Visible = false;
            dataGridView1.Visible = true;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            filcombo();
        }

        private void Del_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && comboBox2.Text != "")
                {
                    string query = "DELETE FROM Basic_Staff_Table WHERE(Department = '"+comboBox1.Text+"') AND(Designation = '"+comboBox2.Text+"')";
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read;
                    read = cmd.ExecuteReader();

                    con.Close();
                    MessageBox.Show("Saved Successfuly");
                }
                else
                {
                    MessageBox.Show("Please Fill All the Requirements Thankyou");
                }
            }
            catch (Exception )
            {
                MessageBox.Show("No Record Found Or Network Error");
            }
            loaddata();
            comboBox1.Text = comboBox2.Text = textBox1.Text = "";
            Groupbox1.Visible = false;
            dataGridView1.Visible = true;
            Groupbox1.Visible = false;
            dataGridView1.Visible = true;
        }

        void filcombo()
        {
            
            string query = "SELECT    Distinct    Department FROM Basic_Staff_Table";
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
        void filcombo1()
        {
            string query = "SELECT Designation FROM Basic_Staff_Table WHERE(Department = '"+comboBox1.Text+"')";
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
                        comboBox2.Items.Add(myread.GetValue(0).ToString());
                    }
                }
                myread.Close();
            }
            catch (Exception )
            {
            }
        }

        private void ComboBox2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            filcombo1();
        }
        void loaddata()
        {
            string query = "SELECT ID,Designation ,Department,Basic_Salary As [Basic Salary],Status,Priority FROM Basic_Staff_Table";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Width = 200;
            this.dataGridView1.Columns[2].Width = 200;
            this.dataGridView1.Columns[5].Width = 50;
            this.dataGridView1.Columns[6].Width = 50;
            label1.Text = "Total Entries" + dataGridView1.Rows.Count;
            salary();
        }
        void salary()
        {
             sal=0;
            for(int i =0; i<=dataGridView1.Rows.Count-1; i++)
            {
                if (dataGridView1.Rows[i].Cells["Basic Salary"].Value.ToString() != null)
                {
                    sal = sal + Convert.ToInt32(dataGridView1.Rows[i].Cells["Basic Salary"].Value);
                }
            }
            label2.Text = "Total Salaries " + sal;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void Label4_Click(object sender, EventArgs e)
        {

        }
        private void Button3_Click(object sender, EventArgs e)
        {
            
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
                {
                    int sts;
                    if (comboBox4.Text == "Yes")
                    {
                        sts = 1;

                    }
                    else
                    {
                        sts = 0;
                    }
                    string query = "Update Basic_Staff_Table set Department = '"+ comboBox1.Text +"', Designation = '"+ comboBox2.Text + "', Basic_Salary = '" + textBox1.Text + "', Status = "+ sts + ", Priority = "+ comboBox3.Text +" where ID = "+ Id + " ";
                    // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read;
                    read = cmd.ExecuteReader();

                    con.Close();
                    MessageBox.Show("Update Successfuly");
                }
                else
                {
                    MessageBox.Show("Please Fill All the Requirements Thankyou");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Either Record is Already saved or Network Error");
            }
            loaddata();
            comboBox1.Text = comboBox2.Text = textBox1.Text = "";
            Groupbox1.Visible = false;
            dataGridView1.Visible = true;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Visible = false;
            Groupbox1.Visible = true;
            Add_save.Visible = false;
            button4.Visible = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                var ids = row.Cells[0].Value.ToString();
                Id = Convert.ToInt32(ids);
                comboBox2.Text = row.Cells[2].Value.ToString();//Desi
                comboBox1.Text = row.Cells[3].Value.ToString();//Depart
                textBox1.Text = row.Cells[4].Value.ToString();//BasicsSalary
                comboBox4.Text = row.Cells[5].Value.ToString();//status
                comboBox3.Text = row.Cells[6].Value.ToString();//Priority
            }
        }
    }
}
