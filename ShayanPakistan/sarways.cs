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
    public partial class sarways : Form
    {
        string imgloc = "";
        string imgloc1 = "";
        DataTable data = new DataTable();
        int rowIndex = 0;
        public sarways()
        {
            InitializeComponent();
        }




      /* void loaddata()
        {
            try
            {  

                string query1;
                query1 = "SELECT        owner_name AS [Owner Name], location AS [Location], address AS [Address], front AS [Front], depth AS [Depth], ground as [Ground], floor as [Floor],total_coverd_area as [Coverd Area],escalation as [Escalation],security as [Security],tenure_of_lease as [lease tenure],parking as [Parking],possession as [possession],com_status as [Status],other_connection as [Other Connection],dg_space as [dg space],microwave_link as [microwave link],image,ID,type,type_1  FROM  sarway WHERE        (type = 'Plot ' AND type_1='for sale')";


                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                DataTable dt1 = new DataTable();
              


                SqlDataAdapter ad1 = new SqlDataAdapter(query1, con);
            



                ad1.Fill(dt1);
           

                dataGridView1.DataSource = dt1;
         

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["type"].Visible = false;
            dataGridView1.Columns["type_1"].Visible = false;
            dataGridView1.Columns["image"].Visible = false;

            dataGridView1.Columns["Owner Name"].Width = 100;
            dataGridView1.Columns["Location"].Width = 100;
            dataGridView1.Columns["Address"].Width = 120;
            dataGridView1.Columns["Front"].Width = 60;
            dataGridView1.Columns["Depth"].Width = 60;
            dataGridView1.Columns["Ground"].Width = 60;
            dataGridView1.Columns["Floor"].Width = 60;
            dataGridView1.Columns["Coverd Area"].Width = 60;
            dataGridView1.Columns["Escalation"].Width = 60;
            dataGridView1.Columns["Security"].Width = 60;
            dataGridView1.Columns["lease tenure"].Width = 70;
            dataGridView1.Columns["Parking"].Width = 60;
            dataGridView1.Columns["possession"].Width = 60;
            dataGridView1.Columns["Status"].Width = 60;
            dataGridView1.Columns["Other Connection"].Width = 80;
            dataGridView1.Columns["dg space"].Width = 80;
            dataGridView1.Columns["microwave link"].Width = 80;
 

           dataGridView1.EnableHeadersVisualStyles = false;
          


            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
     

            dataGridView1.ClearSelection();
         

        } */
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)


        { 
            textBox13.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(* .jpg)|*.jpg|GIF Files (* .gif)| * .gif|All Files(*.*)|*.*";
                dlg.Title = "Select Property Picture";
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

            button4.Visible = true;
            button2.Visible = false;


        }

      /*  private void button3_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = null;


            //loaddata();
            groupBox1.Visible = false;
            //groupBox2.Visible = true;
           // dataGridView1.Visible = true;
        }*/

        private void sarways_Load(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            loading();
            borderstyle();
            button1.Visible = false;
            //loaddata();
            groupBox1.Visible = true;
            show_status();
            load_map();
           /// button6.Visible = true;

            // groupBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // button6.Visible = true;
            button1.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            button2.Visible = false;
            byte[] img = null;
            byte[] img1 = null;
            try
            {

                FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                FileStream fs1 = new FileStream(imgloc1, FileMode.Open, FileAccess.Read);
                BinaryReader br1 = new BinaryReader(fs1);

                img = br.ReadBytes((int)fs.Length);
                img1 = br1.ReadBytes((int)fs1.Length);


                string query = "INSERT INTO sarway (owner_name,landline,Mobile, address, front, depth, backend,size,totalprice,unitprice,com_status,image,image2) VALUES('" + textBox1.Text.Trim() + "', '" + textBox3.Text.Trim() + "', '" + textBox4.Text.Trim() + "', '" + textBox6.Text.Trim() + "', '" + textBox7.Text.Trim() + "', '" + textBox8.Text.Trim() + "', '" + textBox9.Text.Trim() + "', '" + textBox10.Text.Trim() + "', '" + textBox11.Text.Trim() + "', '" + textBox12.Text.Trim() + "', '" + comboBox1.Text.Trim() + "',@img,@img1)";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                cmd.Parameters.Add(new SqlParameter("@img1", img1));

                int x = cmd.ExecuteNonQuery();
               

                con.Close();




                
              

                MessageBox.Show("Inserted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            

            textBox1.Text = String.Empty;
            //textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            ///textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            textBox9.Text = String.Empty;
            textBox10.Text = String.Empty;
            textBox11.Text = String.Empty;
            textBox12.Text = String.Empty;
            textBox13.Text = String.Empty;
            comboBox1.Text = string.Empty;
            textBox14.Text = String.Empty;
            pictureBox1.Image = null;
            pictureBox2.Image = null;





            
            groupBox1.Visible = true;
            borderstyle();
            comboBox1.Visible = false;
            textBox14.Visible = true;
            loading();



        }

        private void button6_Click(object sender, EventArgs e)
        {
 
            groupBox1.Visible = true;
     
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
           

        }

     /*   private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                   string id = row.Cells["ID"].Value.ToString();


                textBox4.Text = row.Cells["front"].Value.ToString();


                string query = "SELECT        image FROM sarway WHERE(ID ='"+id+"')";
                //SqlConnection con = new SqlConnection("Data Source=192.168.0.15,1433; Initial Catalog=ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayan; Password=123456789");
                SqlConnection con = new SqlConnection(variables.cons);
               
                    con.Open();

                    SqlCommand command = new SqlCommand(query, con);
                    SqlDataReader read = command.ExecuteReader();
                    read.Read();
                    if (read.HasRows)
                    {





                        byte[] img = (byte[])(read[0]);
                        if (img == null)
                        {
                            pictureBox1.Image = null;


                        }
                        else
                        {

                            MemoryStream ms = new MemoryStream(img);
                            pictureBox1.Image = Image.FromStream(ms);


                        }
                        

                    }


                textBox1.Text = row.Cells["Owner Name"].Value.ToString();
                textBox2.Text = row.Cells["Location"].Value.ToString();
                textBox3.Text = row.Cells["Address"].Value.ToString();
                textBox4.Text = row.Cells["Front"].Value.ToString();
                textBox5.Text = row.Cells["Depth"].Value.ToString();
                textBox6.Text = row.Cells["Ground"].Value.ToString();
                textBox7.Text = row.Cells["Floor"].Value.ToString();
                textBox8.Text = row.Cells["Coverd Area"].Value.ToString();
                textBox9.Text = row.Cells["Escalation"].Value.ToString();
               
                textBox18.Text = row.Cells["ID"].Value.ToString();




                groupBox1.Visible = true;
                groupBox2.Visible = false;
                dataGridView1.Visible = false;
    
              



            }


        } */



      

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button3.Visible = false;
            button2.Visible = true;
            button4.Visible = false;

            textBox1.Text = String.Empty;
           
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            textBox9.Text = String.Empty;
            textBox10.Text = String.Empty;
            textBox11.Text = String.Empty;
            textBox12.Text = String.Empty;
            textBox13.Text = String.Empty;
            //comboBox1.Text = string.Empty;
            textBox14.Text = String.Empty;
            pictureBox1.Image = null;
            pictureBox2.Image = null;


            border();
            comboBox1.Visible = true;


          

        }




        void loading()
        {
            SqlConnection con = new SqlConnection(variables.cons);

            string query = "SELECT   owner_name,ID,landline,Mobile, address, front, depth, backend,size,totalprice,unitprice,com_status,image,image2 FROM sarway ";
           
            con.Open();
               
                SqlDataAdapter da = new SqlDataAdapter(query,con);
                da.Fill(data);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                
                    con.Close();
            ShowData();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           


           
        }


        void ShowData()
        {
            try
            {



                if (rowIndex <= data.Rows.Count - 1)
                {
                    textBox1.Text = data.Rows[rowIndex]["owner_name"].ToString();
                   // textBox2.Text = data.Rows[rowIndex]["contact"].ToString();
                    textBox3.Text = data.Rows[rowIndex]["landline"].ToString();
                    textBox4.Text = data.Rows[rowIndex]["Mobile"].ToString();
                   // textBox5.Text = data.Rows[rowIndex]["location"].ToString();
                    textBox6.Text = data.Rows[rowIndex]["address"].ToString();
                    textBox7.Text = data.Rows[rowIndex]["front"].ToString();
                    textBox8.Text = data.Rows[rowIndex]["depth"].ToString();
                    textBox9.Text = data.Rows[rowIndex]["backend"].ToString();
                    textBox10.Text = data.Rows[rowIndex]["size"].ToString();
                    textBox11.Text = data.Rows[rowIndex]["totalprice"].ToString();
                    textBox12.Text = data.Rows[rowIndex]["unitprice"].ToString();
                    textBox13.Text = data.Rows[rowIndex]["ID"].ToString();
                    textBox14.Text = data.Rows[rowIndex]["com_status"].ToString();
                    byte[] img = (byte[])(data.Rows[rowIndex]["image"]);
                    byte[] img1 = (byte[])(data.Rows[rowIndex]["image2"]);
                    if (img == null || img1 == null)
                    {
                        pictureBox1.Image = null;
                        pictureBox2.Image = null;
                    }


                    else
                    {
                        MemoryStream mstream = new MemoryStream(img);
                        MemoryStream mstream2 = new MemoryStream(img1);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                        pictureBox2.Image = System.Drawing.Image.FromStream(mstream2);
                    }


                    /* else
                     {
                         MemoryStream nstream = new MemoryStream(img1);
                         pictureBox2.Image = System.Drawing.Image.FromStream(nstream);
                     }*/


                }
                else
                {
                    MessageBox.Show("End Of Entries");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            rowIndex++;
            ShowData();

            textBox14.Visible = true;
           
            // textBox19.Visible = true;

            loading();
            borderstyle();
            button1.Visible = false;

            groupBox1.Visible = true;


            comboBox1.Visible = false;
       




            pictureBox1.Image = null;
            load_map();
            button3.Visible = true;


        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            rowIndex--;
            ShowData();
            textBox14.Visible = true;

            // textBox19.Visible = true;

            loading();
            borderstyle();
            button1.Visible = false;

            groupBox1.Visible = true;


            comboBox1.Visible = false;





            pictureBox1.Image = null;
            load_map();
            button3.Visible = true;

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(* .jpg)|*.jpg|GIF Files (* .gif)| * .gif|All Files(*.*)|*.*";
                dlg.Title = "Select Property Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    imgloc1 = dlg.FileName.ToString();
                    pictureBox2.ImageLocation = imgloc1;

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        void borderstyle()
        {
            textBox1.ReadOnly = true;
            
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
           
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;



            textBox1.BackColor = Color.White;
           
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
           
            textBox6.BackColor = Color.White;
            textBox7.BackColor = Color.White;
            textBox8.BackColor = Color.White;
            textBox9.BackColor = Color.White;
            textBox10.BackColor = Color.White;
             textBox11.BackColor = Color.White;
            textBox12.BackColor = Color.White;
            textBox13.BackColor = Color.White;
            textBox14.BackColor = Color.White;
          



            textBox1.BorderStyle = BorderStyle.None;
           
            textBox3.BorderStyle = BorderStyle.None;
            textBox4.BorderStyle = BorderStyle.None;
           
            textBox6.BorderStyle = BorderStyle.None;
            textBox7.BorderStyle = BorderStyle.None;
            textBox8.BorderStyle = BorderStyle.None;
            textBox9.BorderStyle = BorderStyle.None;
            textBox10.BorderStyle = BorderStyle.None;
            textBox11.BorderStyle = BorderStyle.None;
            textBox12.BorderStyle = BorderStyle.None;
            textBox13.BorderStyle = BorderStyle.None;
            textBox14.BorderStyle = BorderStyle.None;


            comboBox1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
        }

        void border()
        {
            textBox1.BorderStyle = BorderStyle.Fixed3D;
          
            textBox3.BorderStyle = BorderStyle.Fixed3D;
            textBox4.BorderStyle = BorderStyle.Fixed3D;
            
            textBox6.BorderStyle = BorderStyle.Fixed3D;
            textBox7.BorderStyle = BorderStyle.Fixed3D;
            textBox8.BorderStyle = BorderStyle.Fixed3D;
            textBox9.BorderStyle = BorderStyle.Fixed3D;
            textBox10.BorderStyle = BorderStyle.Fixed3D;
            textBox11.BorderStyle = BorderStyle.Fixed3D;
            textBox12.BorderStyle = BorderStyle.Fixed3D;
            textBox13.BorderStyle = BorderStyle.Fixed3D;
            textBox14.BorderStyle = BorderStyle.None;
            comboBox1.FlatStyle = FlatStyle.Standard;

            textBox1.ReadOnly = false;
           
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
           
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox12.ReadOnly = false;
            textBox13.ReadOnly = false;
            textBox14.ReadOnly = false;

            textBox14.Visible = false;




        }

        void show_status()
        {
            try
            {
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                string query = "select distinct type from status_extra";
                SqlDataReader dr = new SqlCommand(query, con).ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr.GetValue(0).ToString());

                }
                dr.Close();
                con.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

      

        private void button6_Click_1(object sender, EventArgs e)
        {
          
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }


        void load_map()
        {

            string street = textBox6.Text;

            try
            {
                StringBuilder queryaddress = new StringBuilder();
                queryaddress.Append("https://www.google.com/maps/@31.5300254,74.3470055,15z");
                if (street != string.Empty)
                {
                    queryaddress.Append(street + "," + "+");

                }


                webBrowser1.Navigate(queryaddress.ToString());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }





        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TextBox1_Click(object sender, System.EventArgs e)
        {
           
        }

        private void textBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            load_map();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }


        Bitmap bmp;
        private void button5_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {
            e.PageSettings.Landscape = true;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }
    }
}
