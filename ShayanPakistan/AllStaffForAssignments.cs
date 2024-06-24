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
    public partial class AllStaffForAssignments : Form
    {
        public AllStaffForAssignments()
        {
            this.TopMost = false;
            InitializeComponent();
            
        }

        private void AllStaffForAssignments_Load(object sender, EventArgs e)
        {
            
            loaddata();

        }










        public void loaddata()
        {
            
            string query = "SELECT Staff_Name AS[Name], Department, Designation FROM Propertica_Staff_info WHERE(Status = 'Probition')OR (Status = 'Regular')OR (Status = 'Trial')OR (Status = 'Permanent') order by  (Case Department  when 'HR' then 1 when 'Admin' then 2 when 'Accounts' then 3 when 'I.T' then 4 when 'Survey Department' then 5 when 'Legal Department'  then 6 when 'Building And Construcion' then 7 when 'Chairman Secretariate' then 8 when 'Junior Staff' then 9 when 'Business' then 10 else 100 END);";
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;


            dataGridView1.Columns["Name"].Width = 140;
            dataGridView1.Columns["Department"].Width = 110;
            dataGridView1.Columns["Designation"].Width = 110;

            label1.Text = "Total Entries  " + dataGridView1.Rows.Count;
            dataGridView1.ClearSelection();




        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string nm = row.Cells["Name"].Value.ToString();
                string des = row.Cells["Designation"].Value.ToString();

                ////////////////////////////////////////////////////


                AssignmentsForStaff obj = new AssignmentsForStaff(nm,des);
                obj.Show();
               



            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
