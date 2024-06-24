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
    public partial class Gate_Pass : Form
    {
        public Gate_Pass()
        {
            InitializeComponent();
        }



        void loadData()
        {
            string query = "SELECT        GatePass#, Item, Location, Reason, Person, IncomingDate AS [Incoming Date], Status,ID FROM GatePass Order By ID ASC";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.ClearSelection();
        }

        void insertData()
        {
            string query = "INSERT INTO GatePass (GatePass#, Item, Location, Reason, Person, IncomingDate, Status) VALUES(N'"+textBox1.Text+ "', N'" + textBox2.Text + "', N'" + textBox3.Text + "', N'" + textBox4.Text + "', N'" + textBox5.Text + "', N'" + dateTimePicker1.Text + "', N'" + textBox7.Text + "')";
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read;
            read = cmd.ExecuteReader();

            con.Close();
            MessageBox.Show("Inserted Successfully");
        }

        private void Gate_Pass_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            groupBox1.Visible = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            insertData();
            loadData();
            button1.Visible = true;
            groupBox1.Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            groupBox1.Visible = false;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                DialogResult dialogResult = MessageBox.Show("Do You Want to Update The Status", "Warning ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    string ID = row.Cells["ID"].Value.ToString();

                    string query = "UPDATE       GatePass SET Status = 'Returned' WHERE(ID = '" + ID + "')";
                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read;
                    read = cmd.ExecuteReader();

                    con.Close();
                    MessageBox.Show("Updated Successfully");
                    loadData();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }


               


            }

        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
