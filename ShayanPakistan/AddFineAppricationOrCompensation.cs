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
    public partial class AddFineAppricationOrCompensation : Form
    {
        public AddFineAppricationOrCompensation()
        {
            InitializeComponent();
            this.TopMost = true;
            filcombo();

            
        }

        void filcombo()
        {
            string query = "SELECT Staff_Name,ID FROM Propertica_Staff_info where Status != 'Left'";
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
            catch (Exception)
            {
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int id;
            id = Attendence_Record_Monthly.Eid;
            string mpName = comboBox1.Text;
            int vl = Convert.ToInt32(textBox1.Text);
            DateTime dateTime = DateTime.Now.Date;
            string v2 = comboBox2.Text;
            int fn = 0;
            int App = 0;
            int Comp = 0;
            string query = "";
            if (v2 == "Fine")
            {
                fn = vl;
                query = "INSERT INTO ExtraPaidOrFine (EmpName,Fine,Date,Reason,Detail,Eid) VALUES('" + mpName + "','" + fn + "','" + dateTime + "','" + richTextBox1.Text + "','" + richTextBox2.Text + "',"+ id + ")";
            } else if (v2 == "Appriciation")
            {
                App = vl;
                query = "INSERT INTO PaidAppreciation (EmpName,Appriciation,Date,Reason,Detail,Eid) VALUES('" + mpName + "','" + App + "'','" + dateTime + "','" + richTextBox1.Text + "','" + richTextBox2.Text + "'," + id + ")";
            }
            else if (v2 == "Componsation")
            {
                Comp = vl;
                query = "INSERT INTO PaidCompensations (EmpName,Compensation,Date,Reason,Detail,Eid) VALUES('" + mpName + "','" + Comp + "','" + dateTime + "','" + richTextBox1.Text + "','" + richTextBox2.Text + "'," + id + ")";
            }
            
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader read;
            read = cmd.ExecuteReader();
            con.Close();

            MessageBox.Show("Record Saved Successfully");
            textBox1.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
                
        }
    }
}
