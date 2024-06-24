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
using System.IO;

namespace ShayanPakistan
{
    public partial class Duty_Charter : Form
    {
        public Duty_Charter(String des)
        {
            InitializeComponent();
            
            loaddata(des);
        }



        void loaddata(string designation)
        {
            try
            {
                string query = "SELECT        Designation, Image FROM Duty_Charter_Table WHERE(Designation = N'" + designation + "')";
                //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);

                con.Close();

                byte[] img = (byte[])(dt.Rows[0]["Image"]);


                MemoryStream ms = new MemoryStream(img);
                Image imgs = Image.FromStream(ms);
                Bitmap bmpPhoto = new Bitmap(imgs);
               // pictureBox1.Image = bmpPhoto;
                this.BackgroundImage = bmpPhoto;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

       
    }
}
