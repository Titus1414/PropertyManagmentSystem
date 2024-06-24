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
    public partial class MonthlyRecordMonth : Form
    {
        public MonthlyRecordMonth()
        {
            InitializeComponent();
           
        }

        void loadNames()
        {
            string query = "select Distinct Name from [Attendence Record] Where  Month([Attendence Record].Date)='"+ Convert.ToDateTime(dateTimePicker1.Text).ToString("MM") +"'";
            
            // SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
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

          comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                var dtfn = Convert.ToDateTime(Attendence.lblDateForAtt).Month;
                string query1 = "Select IsNull(Sum(Fine),0) as Fine,IsNull(Sum(Appriciation),0) as Appriciation,IsNull(Sum(Compensation),0) as Compensation from ExtraPaidOrFine where EmpName = '" + comboBox1.Text.ToString() + "' and Month(Date) = '" + dtfn + "'";

                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt1 = new DataTable();
                SqlDataAdapter ad1 = new SqlDataAdapter(query1, con);
                ad1.Fill(dt1);

                //con.Close();
                int fin = Convert.ToInt32(dt1.Rows[0]["Fine"]);
                int Appr = Convert.ToInt32(dt1.Rows[0]["Appriciation"]);
                int Comp = Convert.ToInt32(dt1.Rows[0]["Compensation"]);

                string query = "Select * from Propertica_Staff_info where Staff_Name ='" + comboBox1.Text + "' ";

                //con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                //con.Close();

                string des = dt.Rows[0]["Designation"].ToString();
                string dep = dt.Rows[0]["Department"].ToString();
                string sal = dt.Rows[0]["Salary"].ToString();
                string stat = dt.Rows[0]["Status"].ToString();
                string inc = dt.Rows[0]["Increment"].ToString();
                int id = Convert.ToInt32(dt.Rows[0]["ID"]);

                string name = dt.Rows[0]["Staff_Name"].ToString();

                string qry = "select Sum(Fine) as fine from AssigmentsForStaff where StaffName = '" + name + "' and Staus = 'Pending'";
                DataTable dt2 = new DataTable();
                SqlDataAdapter ad2 = new SqlDataAdapter(qry, con);
                ad2.Fill(dt2);
                //con.Close();
                int dprfin = Convert.ToInt32(dt2.Rows[0]["fine"]);

                string qry1 = "select Sum(Insentive) as Insentive from AssigmentsForStaff where StaffName = '" + name + "' and Staus = 'Done' and DateCompleted <= DueDate ";
                DataTable dt21 = new DataTable();
                SqlDataAdapter ad21 = new SqlDataAdapter(qry1, con);
                ad21.Fill(dt21);
                con.Close();
                int dprinsentive = Convert.ToInt32(dt2.Rows[0]["Insentive"]);

                Attendence_Record_Monthly obj = new Attendence_Record_Monthly(comboBox1.Text, sal, des, dep, fin,Appr,Comp, stat,inc,dateTimePicker1.Text, dprfin, dprinsentive,id);
                obj.Show();
            }

        }

        private void MonthlyRecordMonth_Load(object sender, EventArgs e)
        {
            loadNames();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            loadNames();

        }
    }
}
