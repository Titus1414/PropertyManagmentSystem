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
using System.Drawing.Printing;

namespace ShayanPakistan
{
    public partial class sarway_house : Form
    {

        string imgloc = "";
        //string imgloc1 = "";
        DataTable data = new DataTable();
        int rowIndex = 0;

        public sarway_house()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void sarwasy_house_Load(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            loading();
            borderstyle();
            button1.Visible = false;
            comboBox2.Visible = false;
            groupBox1.Visible = true;

            load_map();

            show_status1();
            show_status2();
            show_status3();
            show_status4();
            show_status5();
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

           // button4.Visible = true;
            button2.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button3.Visible = false;
            button2.Visible = true;
        //    button4.Visible = false;

            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;

            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;

            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            textBox9.Text = String.Empty;
            textBox10.Text = String.Empty;
            textBox11.Text = String.Empty;
            textBox12.Text = String.Empty;
            textBox13.Text = String.Empty;
            textBox14.Text = String.Empty;
            textBox15.Text = String.Empty;
            textBox16.Text = String.Empty;
            textBox17.Text = String.Empty;
            textBox18.Text = String.Empty;
            textBox19.Text = String.Empty;
            //comboBox1.Text = string.Empty;

            pictureBox1.Image = null;
            pictureBox2.Image = null;


            border();
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = true;

        }

        void ShowData()
        {
            try
            {



                if (rowIndex <= data.Rows.Count - 1)
                {
                    textBox1.Text = data.Rows[rowIndex]["location"].ToString();
                    textBox2.Text = data.Rows[rowIndex]["address"].ToString();
                    textBox3.Text = data.Rows[rowIndex]["name"].ToString();
                    textBox4.Text = data.Rows[rowIndex]["mobile"].ToString();
                    textBox5.Text = data.Rows[rowIndex]["landine"].ToString();
                    textBox6.Text = data.Rows[rowIndex]["size"].ToString();
                    textBox7.Text = data.Rows[rowIndex]["front"].ToString();
                    textBox8.Text = data.Rows[rowIndex]["depth"].ToString();
                    textBox9.Text = data.Rows[rowIndex]["backend"].ToString();
                    textBox10.Text = data.Rows[rowIndex]["story"].ToString();
                    textBox11.Text = data.Rows[rowIndex]["room"].ToString();
                    textBox12.Text = data.Rows[rowIndex]["kitchen"].ToString();
                    textBox13.Text = data.Rows[rowIndex]["bathroom"].ToString();
                    textBox14.Text = data.Rows[rowIndex]["lounge"].ToString();
                    textBox15.Text = data.Rows[rowIndex]["basement"].ToString();
                    textBox16.Text = data.Rows[rowIndex]["parking_space"].ToString();
                    textBox17.Text = data.Rows[rowIndex]["swiming_pool"].ToString();
                    textBox18.Text = data.Rows[rowIndex]["store_room"].ToString();
                    textBox19.Text = data.Rows[rowIndex]["ID"].ToString();




                    //textBox14.Text = data.Rows[rowIndex]["com_status"].ToString();
                    byte[] img = (byte[])(data.Rows[rowIndex]["image"]);
                    //  byte[] img1 = (byte[])(data.Rows[rowIndex]["image2"]);
                    if (img == null)
                    {
                        pictureBox1.Image = null;
                        //    pictureBox2.Image = null;
                    }


                    else
                    {
                        MemoryStream mstream = new MemoryStream(img);
                        //  MemoryStream mstream2 = new MemoryStream(img1);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                        // pictureBox2.Image = System.Drawing.Image.FromStream(mstream2);
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



        void loading()
        {
            try
            {
                SqlConnection con = new SqlConnection(variables.cons);

                string query = "SELECT location,address,name,mobile,landine,size,front,depth,backend,story,room,kitchen,bathroom,lounge,basement,parking_space,swiming_pool,store_room,ID,image FROM sarway_house ";

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(data);
                //DataSet ds = new DataSet();
                //da.Fill(ds);

                con.Close();
                ShowData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label31_Click(object sender, EventArgs e)
        {
            rowIndex++;
            ShowData();

            textBox14.Visible = true;
            textBox15.Visible = true;
            textBox16.Visible = true;
            textBox17.Visible = true;
            textBox18.Visible = true;
            // textBox19.Visible = true;

            loading();
            borderstyle();
            button1.Visible = false;

            groupBox1.Visible = true;


            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;




            pictureBox1.Image = null;
            load_map();
            button3.Visible = true;
        }

        private void label32_Click(object sender, EventArgs e)
        {
            rowIndex--;
            ShowData();


            textBox14.Visible = true;
            textBox15.Visible = true;
            textBox16.Visible = true;
            textBox17.Visible = true;
            textBox18.Visible = true;
            // textBox19.Visible = true;

            loading();
            borderstyle();
            button1.Visible = false;

            groupBox1.Visible = true;


            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;




            pictureBox1.Image = null;
            load_map();
            button3.Visible = true;


        }

        void borderstyle()
        {
            textBox1.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox15.ReadOnly = true;
            textBox16.ReadOnly = true;
            textBox17.ReadOnly = true;
            textBox18.ReadOnly = true;
            textBox19.ReadOnly = true;
            ///  textBox14.ReadOnly = true;



            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            textBox5.BackColor = Color.White;
            textBox6.BackColor = Color.White;
            textBox7.BackColor = Color.White;
            textBox8.BackColor = Color.White;
            textBox9.BackColor = Color.White;
            textBox10.BackColor = Color.White;
            textBox11.BackColor = Color.White;
            textBox12.BackColor = Color.White;
            textBox13.BackColor = Color.White;
            textBox14.BackColor = Color.White;
            textBox15.BackColor = Color.White;
            textBox16.BackColor = Color.White;
            textBox17.BackColor = Color.White;
            textBox18.BackColor = Color.White;
            textBox19.BackColor = Color.White;
            // textBox14.BackColor = Color.White;




            textBox1.BorderStyle = BorderStyle.None;
            textBox2.BorderStyle = BorderStyle.None;
            textBox3.BorderStyle = BorderStyle.None;
            textBox4.BorderStyle = BorderStyle.None;
            textBox5.BorderStyle = BorderStyle.None;
            textBox6.BorderStyle = BorderStyle.None;
            textBox7.BorderStyle = BorderStyle.None;
            textBox8.BorderStyle = BorderStyle.None;
            textBox9.BorderStyle = BorderStyle.None;
            textBox10.BorderStyle = BorderStyle.None;
            textBox11.BorderStyle = BorderStyle.None;
            textBox12.BorderStyle = BorderStyle.None;
            textBox13.BorderStyle = BorderStyle.None;
            textBox14.BorderStyle = BorderStyle.None;
            textBox15.BorderStyle = BorderStyle.None;
            textBox16.BorderStyle = BorderStyle.None;
            textBox17.BorderStyle = BorderStyle.None;
            textBox18.BorderStyle = BorderStyle.None;
            textBox19.BorderStyle = BorderStyle.None;
            // textBox14.BorderStyle = BorderStyle.None;

            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;

            button2.Visible = false;
         //   button4.Visible = false;
        }

        void border()
        {
            textBox1.BorderStyle = BorderStyle.Fixed3D;
            textBox2.BorderStyle = BorderStyle.Fixed3D;
            textBox3.BorderStyle = BorderStyle.Fixed3D;
            textBox4.BorderStyle = BorderStyle.Fixed3D;
            textBox5.BorderStyle = BorderStyle.Fixed3D;
            textBox6.BorderStyle = BorderStyle.Fixed3D;
            textBox7.BorderStyle = BorderStyle.Fixed3D;
            textBox8.BorderStyle = BorderStyle.Fixed3D;
            textBox9.BorderStyle = BorderStyle.Fixed3D;
            textBox10.BorderStyle = BorderStyle.Fixed3D;
            textBox11.BorderStyle = BorderStyle.Fixed3D;
            textBox12.BorderStyle = BorderStyle.Fixed3D;
            textBox13.BorderStyle = BorderStyle.Fixed3D;


            textBox14.BorderStyle = BorderStyle.None;
            textBox15.BorderStyle = BorderStyle.None;
            textBox16.BorderStyle = BorderStyle.None;
            textBox17.BorderStyle = BorderStyle.None;
            textBox18.BorderStyle = BorderStyle.None;
            textBox19.BorderStyle = BorderStyle.None;
            comboBox1.FlatStyle = FlatStyle.Standard;
            comboBox2.FlatStyle = FlatStyle.Standard;
            comboBox3.FlatStyle = FlatStyle.Standard;
            comboBox4.FlatStyle = FlatStyle.Standard;
            comboBox5.FlatStyle = FlatStyle.Standard;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox12.ReadOnly = false;
            textBox13.ReadOnly = false;
            textBox14.ReadOnly = false;
            textBox15.ReadOnly = false;
            textBox16.ReadOnly = false;
            textBox17.ReadOnly = false;
            textBox18.ReadOnly = false;
            textBox19.ReadOnly = false;
            //textBox14.ReadOnly = false;

            // textBox14.Visible = false;

            textBox14.Visible = false;
            textBox15.Visible = false;
            textBox16.Visible = false;
            textBox17.Visible = false;
            textBox18.Visible = false;
            textBox19.Visible = false;


        }

        void show_status1()
        {
            try
            {
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                string query = "select Distinct type1 from parking_yes_no";
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

        void show_status2()
        {
            try
            {
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                string query = "select Distinct type1 from parking_yes_no";
                SqlDataReader dr = new SqlCommand(query, con).ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr.GetValue(0).ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void show_status3()
        {
            try
            {
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                string query = "select Distinct type1 from parking_yes_no";
                SqlDataReader dr = new SqlCommand(query, con).ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr.GetValue(0).ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void show_status4()
        {
            try
            {
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                string query = "select Distinct type1 from parking_yes_no";
                SqlDataReader dr = new SqlCommand(query, con).ExecuteReader();
                while (dr.Read())
                {
                    comboBox4.Items.Add(dr.GetValue(0).ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void show_status5()
        {
            try
            {
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                string query = "select Distinct type1 from parking_yes_no";
                SqlDataReader dr = new SqlCommand(query, con).ExecuteReader();
                while (dr.Read())
                {
                    comboBox5.Items.Add(dr.GetValue(0).ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void load_map()
        {

            string street = textBox2.Text;

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

        private void button1_Click(object sender, EventArgs e)
        {
            // button6.Visible = true;
            button1.Visible = false;
            button3.Visible = true;
           // button4.Visible = false;
            button2.Visible = false;
            byte[] img = null;
            //byte[] img1 = null;
            try
            {

                FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                //   FileStream fs1 = new FileStream(imgloc1, FileMode.Open, FileAccess.Read);
                //    BinaryReader br1 = new BinaryReader(fs1);

                img = br.ReadBytes((int)fs.Length);
                //  img1 = br1.ReadBytes((int)fs1.Length);


                string query = "INSERT INTO sarway_house (location,address,name,mobile,landine,size,front,depth,backend,story,room,kitchen,bathroom,lounge,basement,parking_space,swiming_pool,store_room,image) VALUES('" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "', '" + textBox3.Text.Trim() + "',  '" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "', '" + textBox6.Text.Trim() + "', '" + textBox7.Text.Trim() + "', '" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + textBox10.Text.Trim() + "', '" + textBox11.Text.Trim() + "', '" + textBox12.Text.Trim() + "', '" + textBox13.Text.Trim() + "','" + comboBox1.Text.Trim() + "','" + comboBox2.Text.Trim() + "','" + comboBox3.Text.Trim() + "','" + comboBox4.Text.Trim() + "','" + comboBox5.Text.Trim() + "',@img)";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                //   cmd.Parameters.Add(new SqlParameter("@img1", img1));

                int x = cmd.ExecuteNonQuery();


                con.Close();







                MessageBox.Show("Inserted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            textBox9.Text = String.Empty;
            textBox10.Text = String.Empty;
            textBox11.Text = String.Empty;
            textBox12.Text = String.Empty;
            textBox13.Text = String.Empty;
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;
            comboBox4.Text = string.Empty;
            comboBox5.Text = string.Empty;
            textBox14.Text = String.Empty;
            textBox15.Text = String.Empty;
            textBox16.Text = String.Empty;
            textBox17.Text = String.Empty;
            textBox18.Text = String.Empty;
            textBox19.Text = String.Empty;
            //textBox14.Text = String.Empty;
            pictureBox1.Image = null;
            pictureBox2.Image = null;






            groupBox1.Visible = true;
            borderstyle();
            comboBox1.Visible = false;
            textBox9.Visible = true;
            loading();
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;



            textBox14.Visible = true;
            textBox15.Visible = true;
            textBox16.Visible = true;
            textBox17.Visible = true;
            textBox18.Visible = true;

        }

        private void label15_Click(object sender, EventArgs e)
        {
            load_map();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            
        }
            public static string SearchString="";
        private void SearchButton_Click_1(object sender, EventArgs e)
        {
            SearchString = SearchTextBox.Text;
            //SearchedDataBanquitHallForm SearchedDataBanquitHallForm = new SearchedDataBanquitHallForm();
            //SearchedDataBanquitHallForm.Show();
        }

        //private void SearchFromBanquitHallfunction()
        // {
        //     SearchString = SearchTextBox.Text;
        //     SearchedDataForm SearchedDataForm = new SearchedDataForm();
        //     SearchedDataForm.Show();
        // }

    }

}
