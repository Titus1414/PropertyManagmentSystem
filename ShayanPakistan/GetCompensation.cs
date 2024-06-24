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
    public partial class GetCompensation : Form
    {
        SqlConnection con = new SqlConnection(variables.cons);
        public GetCompensation()
        {
            InitializeComponent();
            this.TopMost = true;
            LoadData();
            DateTime lblDt = Convert.ToDateTime(Attendence.lblDateForAtt);
            string ldt = lblDt.ToString("dd MMMM yyy");
            label1.Text = ldt;
            label2.Text = Attendence_Record_Monthly.Emname;
        }
        void LoadData()
        {
            int id = Attendence_Record_Monthly.Eid;
            int sdf123 = Convert.ToDateTime(Attendence.lblDateForAtt).Month;

            string query = "select e.Compensation, e.Date,Reason,Detail from ExtraPaidOrFine e where Month(e.Date) = '" + sdf123 + "' and Eid = " + id + " ";
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);

            ad.Fill(dt);
            dataGridView1.DataSource = dt;

            //dataGridView1.Columns["EmpName"].Width = 120;
            //dataGridView1.Columns["Fine"].Width = 80;
            //dataGridView1.Columns["Appriciation"].Width = 80;
            dataGridView1.Columns["Compensation"].Width = 80;
            dataGridView1.Columns["Date"].Width = 120;
            dataGridView1.Columns["Reason"].Width = 120;
            dataGridView1.Columns["Detail"].Width = 300;
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            AddFineAppricationOrCompensation sdf = new AddFineAppricationOrCompensation();
            sdf.Show();
        }
    }
}
