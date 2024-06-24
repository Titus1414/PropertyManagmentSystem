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
    public partial class Imagepicker : Form
    {
        string imgloc = "";
        public Imagepicker()
        {
            InitializeComponent();
        }

        private void Imagepicker_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(* .jpg)|*.jpg|GIF Files (* .gif)| * .gif|All Files(*.*)|*.*";
                dlg.Title = "Select Employ Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    imgloc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgloc;

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }





        }






       

        private void Button2_Click(object sender, EventArgs e)
        {
            byte[] img = null;
           


                FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
            string query = "INSERT INTO SoftawareIcons (Image, Name) VALUES(@img, '"+textBox1.Text+"')";

            //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@img", img));

            int x = cmd.ExecuteNonQuery();
            

            con.Close();
            MessageBox.Show("Save successfully");

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(* .jpg)|*.jpg|GIF Files (* .gif)| * .gif|All Files(*.*)|*.*";
                dlg.Title = "Select Employ Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    imgloc = dlg.FileName.ToString();
                    pictureBox2.ImageLocation = imgloc;

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            byte[] img = null;



            FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            string query = "INSERT INTO Duty_Charter_Table (Image, Designation) VALUES(@img, '" + textBox2.Text + "')";

            //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
            SqlConnection con = new SqlConnection(variables.cons);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@img", img));

            int x = cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Save successfully");
        }
    }
}
