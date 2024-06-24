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
using System.Net;
using System.Diagnostics;

namespace ShayanPakistan
{
    public partial class BanquitHall : Form
    {
        string imgloc = "";
        string imgloc1 = "";
        byte[] VideosBit = null;
        DataTable data = new DataTable();
        DataTable DataTable = new DataTable();
        int rowIndex = 0;
        public BanquitHall()
        {
            InitializeComponent();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            textBox29.Visible = false;
        }
        void ShowData()
        {

           
            if (SearchedDataForm.IDOfSpecificRecord != "")
                    {
                //SqlConnection ConnForCountQueryIfExistOriginal = new SqlConnection(variables.cons);
                //ConnForCountQueryIfExistOriginal.Open();
                //using (ConnForCountQueryIfExistOriginal)
                //{
                    //SqlDataAdapter SDA = new SqlDataAdapter("SELECT count(*) from banquit_hall", ConnForCountQueryIfExistOriginal);
                    //SDA.Fill(data);
                    //TotalEntriesCountLabel.Text = "Total Entries : " + (SearchedDataForm.IDOfSpecificRecord).ToString() + "/" + (data.Rows.Count ).ToString();
                //}
            }
            else
                    {

                    }                   
                  //  data.Clear();

            try
            {
              
                if (rowIndex <= data.Rows.Count - 1)
                {
                    SaveUpdatesButton.Visible = true;
                    button8.Visible = false;
                    textBox30.Visible = false;

                    ForLabel.Text = "Available For";

                    //Loading picture in the Picturebox on pageload
                    string PicPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    pictureBox1.Image = null;

                    if (data.Rows[rowIndex]["imageURL"].ToString() != "")
                    {
                        string check = PicPath + "\\Images\\" + data.Rows[rowIndex]["imageURL"].ToString();
                        pictureBox1.Image = new Bitmap(check);
                    }

                    textBox30.Text = data.Rows[rowIndex]["ID"].ToString();
                    textBox1.Text = data.Rows[rowIndex]["hall_name"].ToString();
                    textBox2.Text = data.Rows[rowIndex]["Location"].ToString();
                    textBox3.Text = data.Rows[rowIndex]["Address"].ToString();
                    textBox4.Text = data.Rows[rowIndex]["owner_name"].ToString();
                    textBox5.Text = data.Rows[rowIndex]["mobile_no"].ToString();
                    textBox6.Text = data.Rows[rowIndex]["land_line"].ToString();
                    textBox7.Text = data.Rows[rowIndex]["authrise_name"].ToString();
                    textBox8.Text = data.Rows[rowIndex]["mobile"].ToString();
                    textBox9.Text = data.Rows[rowIndex]["land"].ToString();
                    textBox10.Text = data.Rows[rowIndex]["plot_size"].ToString();
                    textBox11.Text = data.Rows[rowIndex]["plot_statuts"].ToString();
                    textBox12.Text = data.Rows[rowIndex]["covred_area"].ToString();
                    FloorTextBox.Text = data.Rows[rowIndex]["floor"].ToString();
                    textBox14.Text = data.Rows[rowIndex]["parking_space"].ToString();
                    textBox15.Text = data.Rows[rowIndex]["gusets_capcity"].ToString();
                    HallSizeTextBox.Text = data.Rows[rowIndex]["hall_size"].ToString();
                    RatePerHeadTextBox.Text = data.Rows[rowIndex]["rate_per_head"].ToString();
                    ConstructionYearTextBox.Text = data.Rows[rowIndex]["construction_year"].ToString();
                    //textBox19.Text = data.Rows[rowIndex]["Construction"].ToString();
                    ConstructionComboBox.Text = data.Rows[rowIndex]["Construction"].ToString();
                    ConstructionTextBox.Text = data.Rows[rowIndex]["Construction"].ToString();
                    //textBox20.Text = data.Rows[rowIndex]["parking_floor"].ToString();
                    ParkingFloorComboBox.Text = data.Rows[rowIndex]["parking_floor"].ToString();
                    ParkingFloorTextBox.Text = data.Rows[rowIndex]["parking_floor"].ToString();
                    //textBox21.Text = data.Rows[rowIndex]["functional_hall"].ToString();
                    FunctionHallComboBox.Text = data.Rows[rowIndex]["functional_hall"].ToString();
                    FunctionHallTextBox.Text = data.Rows[rowIndex]["functional_hall"].ToString();
                    //textBox22.Text = data.Rows[rowIndex]["warehose"].ToString();
                    WareHouseComboBox.Text = data.Rows[rowIndex]["warehose"].ToString();
                    WareHouseTextBox.Text = data.Rows[rowIndex]["warehose"].ToString();
                    //textBox23.Text = data.Rows[rowIndex]["bridal_room"].ToString();
                    BridalComboBox.Text = data.Rows[rowIndex]["bridal_room"].ToString();
                    BridalTextBox.Text = data.Rows[rowIndex]["bridal_room"].ToString();
                    //textBox24.Text = data.Rows[rowIndex]["power_backup"].ToString();
                    PowerBackupComboBox.Text = data.Rows[rowIndex]["power_backup"].ToString();
                    PowerBackupTextBox.Text = data.Rows[rowIndex]["power_backup"].ToString();
                    //textBox25.Text = data.Rows[rowIndex]["air_condition"].ToString();
                    AirConditionComboBox.Text = data.Rows[rowIndex]["air_condition"].ToString();
                    AirConditionTextBox.Text = data.Rows[rowIndex]["air_condition"].ToString();
                    //textBox26.Text = data.Rows[rowIndex]["kitchen"].ToString();
                    KitchenComboBox.Text = data.Rows[rowIndex]["kitchen"].ToString();
                    KitchenTextBox.Text = data.Rows[rowIndex]["kitchen"].ToString();
                    //textBox27.Text = data.Rows[rowIndex]["lawan"].ToString();
                    LawnComboBox.Text = data.Rows[rowIndex]["lawan"].ToString();
                    LawnTextBox.Text = data.Rows[rowIndex]["lawan"].ToString();
                    //textBox28.Text = data.Rows[rowIndex]["office_space"].ToString();
                    OfficeSpaceComboBox.Text = data.Rows[rowIndex]["office_space"].ToString();
                    OfficeSpaceTextBox.Text = data.Rows[rowIndex]["office_space"].ToString();
                    ForComboBox.Text = data.Rows[rowIndex]["RentOrSale"].ToString();
                    ForTextBox.Text = data.Rows[rowIndex]["RentOrSale"].ToString();
                    BanquitHallLabel.Text = BanquitHallLabel.Text + data.Rows[rowIndex]["RentOrSale"].ToString();


                    //Loading picture in the Picturebox on pageload
                   


                    //byte[] img = (byte[])(data.Rows[rowIndex]["image"]);
                    //byte[] img1 = (byte[])(data.Rows[rowIndex]["Video"]);
                    //if (img == null)
                    //{
                    //    if (pictureBox1.Image != null)
                    //    {
                    //        pictureBox1.Image.Dispose();
                    //        pictureBox1.Image = null;
                    //    }
                    //}
                    //else
                    //{
                    //    MemoryStream mstream = new MemoryStream(img);
                    //    pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    //}
                }
                //else
                //{
                //    MessageBox.Show("End Of Entries");
                //}
            }
            catch (Exception )
            {
            //    MessageBox.Show(ex.Message);
            }
        }
        void loading()
        {

            SqlConnection con = new SqlConnection(variables.cons);
            string query;
            if (SearchedDataForm.IDOfSpecificRecord != "")

            {
                SqlConnection ConnForCountQueryIfExist = new SqlConnection(variables.cons);
                query = "SELECT  hall_name,Location,owner_name,mobile_no," +
                    "land_line,authrise_name,mobile,land,plot_size,plot_statuts," +
                    "Construction,covred_area,floor,parking_floor,parking_space," +
                    "gusets_capcity,functional_hall,hall_size,warehose,kitchen," +
                    "bridal_room,office_space,power_backup,lawan,air_condition," +
                    "construction_year,rate_per_head,image,ID,Address, imageURL " +
                    "from banquit_hall where ID = " + SearchedDataForm.IDOfSpecificRecord;

                ConnForCountQueryIfExist.Open();
                using (ConnForCountQueryIfExist)
                {
                    SqlDataAdapter SDA = new SqlDataAdapter("SELECT ID from banquit_hall", ConnForCountQueryIfExist);
                    data.Clear();
                    SDA.Fill(data);
                    TotalEntriesCountLabel.Text = "Total Entries : " + (SearchedDataForm.IDOfSpecificRecord).ToString() + "/" + (data.Rows.Count ).ToString();
                }

                SqlConnection WithIdQuery = new SqlConnection(variables.cons);
                WithIdQuery.Open();
                    using (WithIdQuery)
                    {
                    SqlDataAdapter da = new SqlDataAdapter(query, WithIdQuery);
                    data.Clear();
                    da.Fill(data);
                    ShowData();
                    SearchedDataForm.IDOfSpecificRecord = "";
                }
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
                FloorTextBox.BorderStyle = BorderStyle.None;
                textBox14.BorderStyle = BorderStyle.None;
                textBox15.BorderStyle = BorderStyle.None;
                HallSizeTextBox.BorderStyle = BorderStyle.None;
                RatePerHeadTextBox.BorderStyle = BorderStyle.None;
                ConstructionYearTextBox.BorderStyle = BorderStyle.None;
                //textBox19.BorderStyle = BorderStyle.None;
                ParkingFloorTextBox.BorderStyle = BorderStyle.None;
                FunctionHallTextBox.BorderStyle = BorderStyle.None;
                WareHouseTextBox.BorderStyle = BorderStyle.None;
                BridalTextBox.BorderStyle = BorderStyle.None;
                PowerBackupTextBox.BorderStyle = BorderStyle.None;
                AirConditionTextBox.BorderStyle = BorderStyle.None;
                KitchenTextBox.BorderStyle = BorderStyle.None;
                LawnTextBox.BorderStyle = BorderStyle.None;
                OfficeSpaceTextBox.BorderStyle = BorderStyle.None;

                ConstructionComboBox.Visible = false;
                ParkingFloorComboBox.Visible = false;
                FunctionHallComboBox.Visible = false;
                WareHouseComboBox.Visible = false;
                KitchenComboBox.Visible = false;
                BridalComboBox.Visible = false;
                LawnComboBox.Visible = false;
                PowerBackupComboBox.Visible = false;
                OfficeSpaceComboBox.Visible = false;

                ConstructionTextBox.Visible = true;
                ParkingFloorTextBox.Visible = true;
                FunctionHallTextBox.Visible = true;
                WareHouseTextBox.Visible = true;
                KitchenTextBox.Visible = true;
                BridalTextBox.Visible = true;
                LawnTextBox.Visible = true;
                PowerBackupTextBox.Visible = true;
                OfficeSpaceTextBox.Visible = true;


            }

            else 
            {
                query = "SELECT  hall_name,Location,owner_name,mobile_no,land_line,authrise_name,mobile,land,plot_size,plot_statuts,Construction,covred_area,[floor],parking_floor,parking_space,gusets_capcity,functional_hall,hall_size,warehose,kitchen,bridal_room,office_space,power_backup,lawan,air_condition,construction_year,rate_per_head,[image],ID,[Address], imageURL from banquit_hall ";
                con.Open();
                data.Clear();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(data);
                TotalEntriesCountLabel.Text = "Total Entries : " + (rowIndex + 1).ToString() + "/" + (data.Rows.Count).ToString();
                ShowData();
                con.Close();
            }


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
            FloorTextBox.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox15.ReadOnly = true;
            HallSizeTextBox.ReadOnly = true;
            RatePerHeadTextBox.ReadOnly = true;
            ConstructionYearTextBox.ReadOnly = true;
            //textBox19.ReadOnly = true;
            ParkingFloorTextBox.ReadOnly = true;
            FunctionHallTextBox.ReadOnly = true;
            WareHouseTextBox.ReadOnly = true;
            BridalTextBox.ReadOnly = true;
            PowerBackupTextBox.ReadOnly = true;
            AirConditionTextBox.ReadOnly = true;
            KitchenTextBox.ReadOnly = true;
            LawnTextBox.ReadOnly = true;
            OfficeSpaceTextBox.ReadOnly = true;
            textBox29.ReadOnly = true;

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
            FloorTextBox.BackColor = Color.White;
            textBox14.BackColor = Color.White;
            textBox15.BackColor = Color.White;
            HallSizeTextBox.BackColor = Color.White;
            RatePerHeadTextBox.BackColor = Color.White;
            ConstructionYearTextBox.BackColor = Color.White;
            //textBox19.BackColor = Color.White;
            ParkingFloorTextBox.BackColor = Color.White;
            FunctionHallTextBox.BackColor = Color.White;
            WareHouseTextBox.BackColor = Color.White;
            BridalTextBox.BackColor = Color.White;
            PowerBackupTextBox.BackColor = Color.White;
            AirConditionTextBox.BackColor = Color.White;
            KitchenTextBox.BackColor = Color.White;
            LawnTextBox.BackColor = Color.White;
            OfficeSpaceTextBox.BackColor = Color.White;
            textBox29.BackColor = Color.White;

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
            FloorTextBox.BorderStyle = BorderStyle.None;
            textBox14.BorderStyle = BorderStyle.None;
            textBox15.BorderStyle = BorderStyle.None;
            HallSizeTextBox.BorderStyle = BorderStyle.None;
            RatePerHeadTextBox.BorderStyle = BorderStyle.None;
            ConstructionYearTextBox.BorderStyle = BorderStyle.None;
            //textBox19.BorderStyle = BorderStyle.None;
            ParkingFloorTextBox.BorderStyle = BorderStyle.None;
            FunctionHallTextBox.BorderStyle = BorderStyle.None;
            WareHouseTextBox.BorderStyle = BorderStyle.None;
            BridalTextBox.BorderStyle = BorderStyle.None;
            PowerBackupTextBox.BorderStyle = BorderStyle.None;
            AirConditionTextBox.BorderStyle = BorderStyle.None;
            KitchenTextBox.BorderStyle = BorderStyle.None;
            LawnTextBox.BorderStyle = BorderStyle.None;
            OfficeSpaceTextBox.BorderStyle = BorderStyle.None;
            textBox29.BorderStyle = BorderStyle.None;
           
            ConstructionComboBox.Visible = false;
            ParkingFloorComboBox.Visible = false;
            FunctionHallComboBox.Visible = false;
            WareHouseComboBox.Visible = false;
            KitchenComboBox.Visible = false;
            BridalComboBox.Visible = false;
            LawnComboBox.Visible = false;
            PowerBackupComboBox.Visible = false;
            OfficeSpaceComboBox.Visible = false;
            AirConditionComboBox.Visible = false;
           
            button2.Visible = false;
            button4.Visible = false;
            SaveUpdatesButton.Visible = true;
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
            FloorTextBox.BorderStyle = BorderStyle.Fixed3D;
            textBox14.BorderStyle = BorderStyle.Fixed3D;
            textBox15.BorderStyle = BorderStyle.Fixed3D;
            HallSizeTextBox.BorderStyle = BorderStyle.Fixed3D;
            RatePerHeadTextBox.BorderStyle = BorderStyle.Fixed3D;
            ConstructionYearTextBox.BorderStyle = BorderStyle.Fixed3D;
            //textBox19.BorderStyle = BorderStyle.None;
            ParkingFloorTextBox.BorderStyle = BorderStyle.None;
            FunctionHallTextBox.BorderStyle = BorderStyle.None;
            WareHouseTextBox.BorderStyle = BorderStyle.None;
            BridalTextBox.BorderStyle = BorderStyle.None;
            PowerBackupTextBox.BorderStyle = BorderStyle.None;
            AirConditionTextBox.BorderStyle = BorderStyle.None;
            KitchenTextBox.BorderStyle = BorderStyle.None;
            LawnTextBox.BorderStyle = BorderStyle.None;
            OfficeSpaceTextBox.BorderStyle = BorderStyle.None;
            textBox29.BorderStyle = BorderStyle.None;
           
            ConstructionComboBox.FlatStyle = FlatStyle.Standard;
            ParkingFloorComboBox.FlatStyle = FlatStyle.Standard;
            FunctionHallComboBox.FlatStyle = FlatStyle.Standard;
            WareHouseComboBox.FlatStyle = FlatStyle.Standard;
            KitchenComboBox.FlatStyle = FlatStyle.Standard;
            BridalComboBox.FlatStyle = FlatStyle.Standard;
            LawnComboBox.FlatStyle = FlatStyle.Standard;
            PowerBackupComboBox.FlatStyle = FlatStyle.Standard;   
            OfficeSpaceComboBox.FlatStyle = FlatStyle.Standard;
            AirConditionComboBox.FlatStyle = FlatStyle.Standard;

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
            FloorTextBox.ReadOnly = false;
            textBox14.ReadOnly = false;
            textBox15.ReadOnly = false;
            HallSizeTextBox.ReadOnly = false;
            RatePerHeadTextBox.ReadOnly = false;
            ConstructionYearTextBox.ReadOnly = false;
            //textBox19.ReadOnly = false;
            ParkingFloorTextBox.ReadOnly = false;
            FunctionHallTextBox.ReadOnly = false;
            WareHouseTextBox.ReadOnly = false;
            BridalTextBox.ReadOnly = false;
            PowerBackupTextBox.ReadOnly = false;
            AirConditionTextBox.ReadOnly = false;
            KitchenTextBox.ReadOnly = false;
            LawnTextBox.ReadOnly = false;
            OfficeSpaceTextBox.ReadOnly = false;
            textBox29.ReadOnly = false;


            //textBox19.Visible = false;
            //textBox20.Visible = false;
            //textBox21.Visible = false;
            //textBox22.Visible = false;
            //textBox23.Visible = false;
            //textBox24.Visible = false;
            //textBox25.Visible = false;
            //textBox26.Visible = false;
            //textBox27.Visible = false;
            //textBox28.Visible = false;
        }

        void show_status()
        {
            try
            {
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                string query = "select Distinct banquit_hall from banquit_type";
                SqlDataReader dr = new SqlCommand(query, con).ExecuteReader();
                while (dr.Read())
                {
                    ConstructionComboBox.Items.Add(dr.GetValue(0).ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    ParkingFloorComboBox.Items.Add(dr.GetValue(0).ToString());
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
                    FunctionHallComboBox.Items.Add(dr.GetValue(0).ToString());
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
                    WareHouseComboBox.Items.Add(dr.GetValue(0).ToString());
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
                    KitchenComboBox.Items.Add(dr.GetValue(0).ToString());
                }
                dr.Close();
                con.Close();
            }
            catch(Exception ex)
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
                    BridalComboBox.Items.Add(dr.GetValue(0).ToString());
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void show_status6()
        {
            try
            {
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                string query = "select Distinct type1 from parking_yes_no";
                SqlDataReader dr = new SqlCommand(query, con).ExecuteReader();
                while (dr.Read())
                {
                    LawnComboBox.Items.Add(dr.GetValue(0).ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void show_status7()
        {
            try
            {
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                string query = "select Distinct type1 from parking_yes_no";
                SqlDataReader dr = new SqlCommand(query, con).ExecuteReader();
                while (dr.Read())
                {
                    PowerBackupComboBox.Items.Add(dr.GetValue(0).ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void show_status8()
        {
            try
            {
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                string query = "select Distinct type1 from parking_yes_no";
                SqlDataReader dr = new SqlCommand(query, con).ExecuteReader();
                while (dr.Read())
                {
                    OfficeSpaceComboBox.Items.Add(dr.GetValue(0).ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void show_status9()
        {
            try
            {
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                string query = "select Distinct type1 from parking_yes_no";
                SqlDataReader dr = new SqlCommand(query, con).ExecuteReader();
                while (dr.Read())
                {
                    AirConditionComboBox.Items.Add(dr.GetValue(0).ToString());

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
            string street = textBox3.Text;
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

        private void textBox2_Click(object sender, EventArgs e)
        {


        }

      
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
           
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
        private void BanquitHall_Load(object sender, EventArgs e)
        {

            SqlConnection InteliSenseCon = new SqlConnection(variables.cons);
            string InteliSenseQuery = "SELECT  hall_name,Location,owner_name,mobile_no,land_line,authrise_name,mobile,Construction," + "construction_year,ID,[Address] from banquit_hall ";

            // = "select hall_name from banquit_hall";
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            SqlCommand CMD = new SqlCommand(InteliSenseQuery, InteliSenseCon);
            InteliSenseCon.Open();
            using(InteliSenseCon) { 
            SqlDataReader SDR = CMD.ExecuteReader();
            while (SDR.Read())
            {
                    string hall_name = SDR["hall_name"].ToString();
                    Collection.Add(hall_name);
                    string Location = SDR["Location"].ToString();
                    Collection.Add(Location);
                    string owner_name = SDR["owner_name"].ToString();
                    Collection.Add(owner_name);
                    string mobile_no = SDR["mobile_no"].ToString();
                    Collection.Add(mobile_no);
                    string land_line = SDR["land_line"].ToString();
                    Collection.Add(land_line);
                    string authrise_name = SDR["authrise_name"].ToString();
                    Collection.Add(authrise_name);
                    string mobile = SDR["mobile"].ToString();
                    Collection.Add(mobile);
                    string Construction = SDR["Construction"].ToString();
                    Collection.Add(Construction);
                    string construction_year = SDR["construction_year"].ToString();
                    Collection.Add(construction_year);
                    string Address = SDR["Address"].ToString();
                    Collection.Add(Address);
            }

            SearchTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                SearchTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                SearchTextBox.AutoCompleteCustomSource = Collection;

            }

            //hiding Items on PageLaod
            SaveNewPropertyButton.Visible = false;
            SaveUpdatesButton.Visible = false;

            ForComboBox.Visible = false;
            ConstructionComboBox.Visible = false;
            ParkingFloorComboBox.Visible = false;
            FunctionHallComboBox.Visible = false;
            WareHouseComboBox.Visible = false;
            KitchenComboBox.Visible = false;
            BridalComboBox.Visible = false;
            LawnComboBox.Visible = false;
            PowerBackupComboBox.Visible = false;
            OfficeSpaceComboBox.Visible = false;
            AirConditionComboBox.Visible = false;

            ForTextBox.Visible = true;
            ConstructionTextBox.Visible = true;
            ParkingFloorTextBox.Visible = true;
            FunctionHallTextBox.Visible = true;
            WareHouseTextBox.Visible = true;
            KitchenTextBox.Visible = true;
            BridalTextBox.Visible = true;
            LawnTextBox.Visible = true;
            PowerBackupTextBox.Visible = true;
            OfficeSpaceTextBox.Visible = true;
            AirConditionTextBox.Visible = true;

            ForTextBox.BorderStyle = BorderStyle.None;

            ConstructionTextBox.BorderStyle = BorderStyle.None;


            loading();
            //borderstyle();


            button1.Visible = false;
           
            groupBox1.Visible = true;

            


            load_map();
            show_status();
            show_status1();
            show_status2();
            show_status3();
            show_status4();
            show_status5();
            show_status6();
            show_status7();
            show_status8();
            show_status9();
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        ////--------------------------------------//

        

        //private void CaptureScreen()
        //{
        //    Graphics mygraphics = this.CreateGraphics();

        //    Size s = this.Size;

        //    memoryImage = new Bitmap(s.Width, s.Height, mygraphics);

        //    Graphics memoryGraphics = Graphics.FromImage(memoryImage);
        //    IntPtr dc1 = mygraphics.GetHdc();

        //    IntPtr dc2 = memoryGraphics.GetHdc();
        //    BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369377);//13369376);

        //    mygraphics.ReleaseHdc(dc1);

        //    memoryGraphics.ReleaseHdc(dc2);
        //}

        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        //private Bitmap memoryImage;
        //private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawImage(memoryImage, 0, 0);
        //}
        //Bitmap bitmap;

        //private void button5_Click_1(object sender, EventArgs e)
        //{
        //    //panel1.Hide();
        //    CaptureScreen();
        //    PrintDocument myDoc = new PrintDocument();
        //    myDoc.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 1415, 1000);
        //    PrintPreviewDialog print_dlg = new PrintPreviewDialog();
        //    print_dlg.Document = printDocument1;
        //    print_dlg.ShowDialog();

        //}



        //private void printDocument1_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        //{
        //    e.PageSettings.Landscape = true;
        //}

        ////--------------------------------------//




        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            // button6.Visible = true;
            
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


                string query = "INSERT INTO banquit_hall (hall_name,Location,owner_name,mobile_no,land_line,authrise_name,mobile,land,plot_size,plot_statuts,Construction,covred_area,floor,parking_floor,parking_space,gusets_capcity,functional_hall,hall_size,warehose,kitchen,bridal_room,office_space,power_backup,lawan,air_condition,construction_year,rate_per_head,image,Address, RentOrSale) VALUES('" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "',  '" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "', '" + textBox6.Text.Trim() + "', '" + textBox7.Text.Trim() + "', '" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + textBox10.Text.Trim() + "', '" + textBox11.Text.Trim() + "','" + ConstructionComboBox.Text.Trim() + "' , '" + textBox12.Text.Trim() + "','" + FloorTextBox.Text.Trim() + "','" + ParkingFloorComboBox.Text.Trim() + "','" + textBox14.Text.Trim() + "','" + textBox15.Text.Trim() + "','" + FunctionHallComboBox.Text.Trim() + "','" + HallSizeTextBox.Text.Trim() + "','" + WareHouseComboBox.Text.Trim() + "','" + KitchenComboBox.Text.Trim() + "','" + BridalComboBox.Text.Trim() + "','" + OfficeSpaceComboBox.Text.Trim() + "','" + PowerBackupComboBox.Text.Trim() + "','" + LawnComboBox.Text.Trim() + "','" + AirConditionComboBox.Text.Trim() + "','" + ConstructionYearTextBox.Text.Trim() + "','" + RatePerHeadTextBox.Text.Trim() + "',@img,'" + textBox3.Text.Trim() + "', '" + ForComboBox.Text.Trim() + "');";
                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                //cmd.Parameters.Add(new SqlParameter("@img1", img1));

                int x = cmd.ExecuteNonQuery();


                con.Close();







                MessageBox.Show("Inserted Successfully");
              }

              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }

            button1.Visible = false;
            AddNewPropertyButton.Visible = true;
            SaveUpdatesButton.Visible = true;
            button4.Visible = false;
            button2.Visible = false;


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
            FloorTextBox.Text = String.Empty;
            textBox14.Text = String.Empty;
            textBox15.Text = String.Empty;
            HallSizeTextBox.Text = String.Empty;
            RatePerHeadTextBox.Text = String.Empty;
            ConstructionYearTextBox.Text = String.Empty;
            //textBox19.Text = String.Empty;
            ParkingFloorTextBox.Text = String.Empty;
            FunctionHallTextBox.Text = String.Empty;
            WareHouseTextBox.Text = String.Empty;
            BridalTextBox.Text = String.Empty;
            PowerBackupTextBox.Text = String.Empty;
            AirConditionTextBox.Text = String.Empty;
            KitchenTextBox.Text = String.Empty;
            LawnTextBox.Text = String.Empty;
            OfficeSpaceTextBox.Text = String.Empty;
            textBox29.Text = String.Empty; 


            ConstructionComboBox.Text = string.Empty;
            ParkingFloorComboBox.Text = string.Empty;
            FunctionHallComboBox.Text = string.Empty;
            WareHouseComboBox.Text = string.Empty;
            KitchenComboBox.Text = string.Empty;
            BridalComboBox.Text = string.Empty;
            LawnComboBox.Text = string.Empty;
            PowerBackupComboBox.Text = string.Empty;
            OfficeSpaceComboBox.Text = string.Empty;
            AirConditionComboBox.Text = string.Empty;


            //textBox14.Text = String.Empty;
            //pictureBox1.Image = null;
            //pictureBox2.Image = null;






            groupBox1.Visible = true;
          
            textBox9.Visible = true;

            ConstructionTextBox.Visible = true;
            ParkingFloorComboBox.Visible = false;
            FunctionHallComboBox.Visible = false;
            WareHouseComboBox.Visible = false;
            KitchenComboBox.Visible = false;
            BridalComboBox.Visible = false;
            LawnComboBox.Visible = false;
            PowerBackupComboBox.Visible = false;
            OfficeSpaceComboBox.Visible = false;
            AirConditionComboBox.Visible = false; ConstructionComboBox.Visible = true;



            ConstructionComboBox.Visible = true;
            //textBox19.Visible = true;
            ParkingFloorTextBox.Visible = true;
            FunctionHallTextBox.Visible = true;
            WareHouseTextBox.Visible = true;
            BridalTextBox.Visible = true;
            PowerBackupTextBox.Visible = true;
            AirConditionTextBox.Visible = true;
            KitchenTextBox.Visible = true;
            LawnTextBox.Visible = true;
            OfficeSpaceTextBox.Visible = true;


            //ShowData();

            borderstyle();
            loading();


        }
        public static string PictureUpload;
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
               

                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Filter = "JPG Files(* .jpg)|*.jpg|GIF Files (* .gif)| * .gif|All Files(*.*)|*.*";
                    dlg.Title = "Select Property Picture";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    URLTextBoxNew.Text = dlg.FileName;
                    pictureBox1.Image = new Bitmap(dlg.FileName);
                }

                //OpenFileDialog dlg = new OpenFileDialog();
                //dlg.Filter = "JPG Files(* .jpg)|*.jpg|GIF Files (* .gif)| * .gif|All Files(*.*)|*.*";
                //dlg.Title = "Select Property Picture";
                //if (dlg.ShowDialog() == DialogResult.OK)
                //{
                //    imgloc = dlg.FileName.ToString();
                //    pictureBox1.ImageLocation = imgloc;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //button4.Visible = false;
           // button2.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ConstructionTextBox.Visible = false;
            ParkingFloorTextBox.Visible = false;
            ParkingFloorTextBox.Visible = false;
            FunctionHallTextBox.Visible = false;
            KitchenTextBox.Visible = false;
            WareHouseTextBox.Visible = false;
            LawnTextBox.Visible = false;
            BridalTextBox.Visible = false;
            OfficeSpaceTextBox.Visible = false;
            PowerBackupTextBox.Visible = false;
            AirConditionTextBox.Visible = false;
            SaveNewPropertyButton.Visible = true;
            button1.Visible = true;
            textBox30.Visible = false;
            AddNewPropertyButton.Visible = false;
            button2.Visible = true;
            SaveUpdatesButton.Visible = false;
            button8.Visible = true;
            button4.Visible = true;
            label31.Visible = false;
            label32.Visible = false;
            ForComboBox.Visible = true;
            ForTextBox.Visible = false;

            ConstructionComboBox.Text = String.Empty;
            ParkingFloorComboBox.Text = String.Empty;
            FunctionHallComboBox.Text = String.Empty;
            WareHouseComboBox.Text = String.Empty;
            KitchenComboBox.Text = String.Empty;
            BridalComboBox.Text = String.Empty;
            LawnComboBox.Text = String.Empty;
            PowerBackupComboBox.Text = String.Empty;
            OfficeSpaceComboBox.Text = String.Empty;
            AirConditionComboBox.Text  = String.Empty;

            //pictureBox1.Image = null;
            //pictureBox2.Image = null;

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
            FloorTextBox.Text = String.Empty;
            textBox14.Text = String.Empty;
            textBox15.Text = String.Empty;
            HallSizeTextBox.Text = String.Empty;
            RatePerHeadTextBox.Text = String.Empty;
            ConstructionYearTextBox.Text = String.Empty;
            //textBox19.Text = String.Empty;
            ParkingFloorTextBox.Text = String.Empty;
            FunctionHallTextBox.Text = String.Empty;
            WareHouseTextBox.Text = String.Empty;
            BridalTextBox.Text = String.Empty;
            PowerBackupTextBox.Text = String.Empty;
            AirConditionTextBox.Text = String.Empty;
            KitchenTextBox.Text = String.Empty;
            LawnTextBox.Text = String.Empty;
            OfficeSpaceTextBox.Text = String.Empty;
            textBox29.Text = String.Empty;

            if (pictureBox1.Image != null)
            {
              //  pictureBox1.Image.Dispose();
             //   pictureBox1.Image = null;
            }

            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
             //   pictureBox2.Image = null;
            }
           // pictureBox1.Image = null;
            //pictureBox2.Image = null;


            border();
            ConstructionComboBox.Visible = true;
            ConstructionComboBox.Visible = true;
            ParkingFloorComboBox.Visible = true;
            FunctionHallComboBox.Visible = true;
            WareHouseComboBox.Visible = true;
            KitchenComboBox.Visible = true;
            BridalComboBox.Visible = true;
            LawnComboBox.Visible = true;
            PowerBackupComboBox.Visible = true;
            OfficeSpaceComboBox.Visible = true;
            AirConditionComboBox.Visible = true;
            ConstructionTextBox.Visible = false;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            var client = new WebClient();
            //var uri = new Uri("http://www.yoursite.com/UploadMethod/");


            var fileName = "";

            try
            {
                dlg.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";
                dlg.Title = "Select Property Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgloc1 = dlg.FileName.ToString();
                    pictureBox2.ImageLocation = imgloc1;
                    fileName = imgloc1;
                }
                var sdf2 = new Uri(imgloc1);
                client.Headers.Add("fileName", System.IO.Path.GetFileName(fileName));
                var data = System.IO.File.ReadAllBytes(fileName);
                var path = new Uri(System.IO.Directory.GetCurrentDirectory());
                client.UploadDataAsync(path, data);
                VideosBit = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void label32_Click(object sender, EventArgs e)
        {
            if (rowIndex < 1)
            {
                rowIndex = data.Rows.Count - 1;
            }
            rowIndex--;


            //ShowData();
        //  pictureBox1.Image = null;
            //textBox19.Visible = true;
            ParkingFloorTextBox.Visible = true;
            FunctionHallTextBox.Visible = true;
            WareHouseTextBox.Visible = true;
            BridalTextBox.Visible = true;
            PowerBackupTextBox.Visible = true;
            AirConditionTextBox.Visible = true;
            KitchenTextBox.Visible = true;
            LawnTextBox.Visible = true;
            OfficeSpaceTextBox.Visible = true;
            loading();
            //borderstyle();
            button1.Visible = false;
            groupBox1.Visible = true;
            //comboBox1.Visible = false;
            //comboBox2.Visible = false;
            //comboBox3.Visible = false;
            //comboBox4.Visible = false;
            //comboBox5.Visible = false;
            //comboBox6.Visible = false;
            //comboBox7.Visible = false;
            //comboBox8.Visible = false;
            //comboBox9.Visible = false;
            //comboBox10.Visible = false;
            load_map();
            AddNewPropertyButton.Visible = true;
        }
        public static int RightLeftArrow;
        public static int rowindexNew=0;
        private void label31_Click(object sender, EventArgs e)
        {
            rowIndex++;
               rowindexNew = rowindexNew + 1;
            RightLeftArrow = rowindexNew;

            if (rowIndex > data.Rows.Count - 1)
            {
                rowIndex = 0;
            }

            //ShowData();
            //textBox19.Visible = true;
            ParkingFloorTextBox.Visible = true;
            FunctionHallTextBox.Visible = true;
            WareHouseTextBox.Visible = true;
            BridalTextBox.Visible = true;
            PowerBackupTextBox.Visible = true;
            AirConditionTextBox.Visible = true;
            KitchenTextBox.Visible = true;
            LawnTextBox.Visible = true;
            OfficeSpaceTextBox.Visible = true;
            loading();

            //SqlConnection conOnRightArrow = new SqlConnection(variables.cons);
            //string queryOnRightArrow = "SELECT  hall_name,Location,owner_name,mobile_no,land_line,authrise_name,mobile,land,plot_size,plot_statuts,Construction,covred_area,[floor],parking_floor,parking_space,gusets_capcity,functional_hall,hall_size,warehose,kitchen,bridal_room,office_space,power_backup,lawan,air_condition,construction_year,rate_per_head,[image],ID,[Address], imageURL from banquit_hall where id = " + (rowIndex + 1).ToString() + ";";
            //conOnRightArrow.Open();
            //using (conOnRightArrow)
            //{
            //    data.Clear();
            //    SqlDataAdapter da = new SqlDataAdapter(queryOnRightArrow, conOnRightArrow);
            //    da.Fill(data);
            //    //   TotalEntriesCountLabel.Text = "Total Entries : " + (rowIndex + 1).ToString() + "/" + (data.Rows.Count).ToString();
            //    ShowData();
            //}


            load_map();
            AddNewPropertyButton.Visible = true;
        }

        private void label15_Click_1(object sender, EventArgs e)
        {
            load_map();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            byte[] ved = null;
            try
            {
                if (imgloc != "")
                {
                    FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    ved = VideosBit;
                }
                string query = "";
                if (img != null && img.Length > 0 && ved != null && ved.Length > 0)
                {
                   string PicName= Path.GetFileName(URLTextBoxNew.Text);
                    string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    File.Copy(URLTextBoxNew.Text, Path.Combine(path + "\\Images\\", Path.GetFileName(URLTextBoxNew.Text)), true);
                    query = "INSERT INTO banquit_hall (hall_name,Location,owner_name,mobile_no,land_line,authrise_name,mobile,land,plot_size,plot_statuts,Construction,covred_area,floor,parking_floor,parking_space,gusets_capcity,functional_hall,hall_size,warehose,kitchen,bridal_room,office_space,power_backup,lawan,air_condition,construction_year,rate_per_head, imageURL,Address,Video, RentOrSale) VALUES('" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "',  '" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "', '" + textBox6.Text.Trim() + "', '" + textBox7.Text.Trim() + "', '" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + textBox10.Text.Trim() + "', '" + textBox11.Text.Trim() + "','" + ConstructionComboBox.Text.Trim() + "' , '" + textBox12.Text.Trim() + "','" + FloorTextBox.Text.Trim() + "','" + ParkingFloorComboBox.Text.Trim() + "','" + textBox14.Text.Trim() + "','" + textBox15.Text.Trim() + "','" + FunctionHallComboBox.Text.Trim() + "','" + HallSizeTextBox.Text.Trim() + "','" + WareHouseComboBox.Text.Trim() + "','" + KitchenComboBox.Text.Trim() + "','" + BridalComboBox.Text.Trim() + "','" + OfficeSpaceComboBox.Text.Trim() + "','" + PowerBackupComboBox.Text.Trim() + "','" + LawnComboBox.Text.Trim() + "','" + AirConditionComboBox.Text.Trim() + "','" + ConstructionYearTextBox.Text.Trim() + "','" + RatePerHeadTextBox.Text.Trim() + "', '" + PicName + "', '" + textBox3.Text.Trim() + "','ved', '" + ForComboBox.Text.Trim() + "');";
                }
                else
                {
                    string PicName = Path.GetFileName(URLTextBoxNew.Text);
                    string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    File.Copy(URLTextBoxNew.Text, Path.Combine(path + "\\Images\\", Path.GetFileName(URLTextBoxNew.Text)), true);
                    query = "INSERT INTO banquit_hall (hall_name,Location,owner_name,mobile_no,land_line,authrise_name,mobile,land,plot_size,plot_statuts,Construction,covred_area,floor,parking_floor,parking_space,gusets_capcity,functional_hall,hall_size,warehose,kitchen,bridal_room,office_space,power_backup,lawan,air_condition,construction_year,rate_per_head, imageURL, Address,Video, RentOrSale) VALUES('" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "',  '" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "', '" + textBox6.Text.Trim() + "', '" + textBox7.Text.Trim() + "', '" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + textBox10.Text.Trim() + "', '" + textBox11.Text.Trim() + "','" + ConstructionComboBox.Text.Trim() + "' , '" + textBox12.Text.Trim() + "','" + FloorTextBox.Text.Trim() + "','" + ParkingFloorComboBox.Text.Trim() + "','" + textBox14.Text.Trim() + "','" + textBox15.Text.Trim() + "','" + FunctionHallComboBox.Text.Trim() + "','" + HallSizeTextBox.Text.Trim() + "','" + WareHouseComboBox.Text.Trim() + "','" + KitchenComboBox.Text.Trim() + "','" + BridalComboBox.Text.Trim() + "','" + OfficeSpaceComboBox.Text.Trim() + "','" + PowerBackupComboBox.Text.Trim() + "','" + LawnComboBox.Text.Trim() + "','" + AirConditionComboBox.Text.Trim() + "','" + ConstructionYearTextBox.Text.Trim() + "','" + RatePerHeadTextBox.Text.Trim() + "','" + PicName + "','" + textBox3.Text.Trim() + "','No video', '" + ForComboBox.Text.Trim() + "');";
                }

                SqlConnection con = new SqlConnection(variables.cons);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                //if (img != null && img.Length > 0 && ved != null && ved.Length > 0)
                //{
                //    cmd.Parameters.Add(new SqlParameter("@img", img));
                //    cmd.Parameters.Add(new SqlParameter("@ved", ved));
                //}

                int x = cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Inserted Successfully");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            button1.Visible = false;
            AddNewPropertyButton.Visible = true;
            SaveUpdatesButton.Visible = true;
            button4.Visible = false;
            button2.Visible = false;

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
            FloorTextBox.Text = String.Empty;
            textBox14.Text = String.Empty;
            textBox15.Text = String.Empty;
            HallSizeTextBox.Text = String.Empty;
            RatePerHeadTextBox.Text = String.Empty;
            ConstructionYearTextBox.Text = String.Empty;
            //textBox19.Text = String.Empty;
            ParkingFloorTextBox.Text = String.Empty;
            FunctionHallTextBox.Text = String.Empty;
            WareHouseTextBox.Text = String.Empty;
            BridalTextBox.Text = String.Empty;
            PowerBackupTextBox.Text = String.Empty;
            AirConditionTextBox.Text = String.Empty;
            KitchenTextBox.Text = String.Empty;
            LawnTextBox.Text = String.Empty;
            OfficeSpaceTextBox.Text = String.Empty;
            textBox29.Text = String.Empty;


            ConstructionComboBox.Text = string.Empty;
            ParkingFloorComboBox.Text = string.Empty;
            FunctionHallComboBox.Text = string.Empty;
            WareHouseComboBox.Text = string.Empty;
            KitchenComboBox.Text = string.Empty;
            BridalComboBox.Text = string.Empty;
            LawnComboBox.Text = string.Empty;
            PowerBackupComboBox.Text = string.Empty;
            OfficeSpaceComboBox.Text = string.Empty;
            AirConditionComboBox.Text = string.Empty;
            //pictureBox1.Image = null;
            //pictureBox2.Image = null;
            groupBox1.Visible = true;

            textBox9.Visible = true;

            ConstructionComboBox.Visible = false;
            ParkingFloorComboBox.Visible = false;
            FunctionHallComboBox.Visible = false;
            WareHouseComboBox.Visible = false;
            KitchenComboBox.Visible = false;
            BridalComboBox.Visible = false;
            LawnComboBox.Visible = false;
            PowerBackupComboBox.Visible = false;
            OfficeSpaceComboBox.Visible = false;
            AirConditionComboBox.Visible = false;

            //textBox19.Visible = true;
            ParkingFloorTextBox.Visible = true;
            FunctionHallTextBox.Visible = true;
            WareHouseTextBox.Visible = true;
            BridalTextBox.Visible = true;
            PowerBackupTextBox.Visible = true;
            AirConditionTextBox.Visible = true;
            KitchenTextBox.Visible = true;
            LawnTextBox.Visible = true;
            OfficeSpaceTextBox.Visible = true;
            //ShowData();

            borderstyle();
            loading();

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

            //Update the record
        private void Button7_Click(object sender, EventArgs e)
        {
            EditButton.Visible = true;
            SaveUpdatesButton.Visible = false;
            byte[] img = null;
            byte[] ved = null;
            try
            {
                if (imgloc != "")
                {
                    FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    ved = VideosBit;
                }
                string query = "";
                //if (img != null && img.Length > 0 && ved != null && ved.Length > 0)
                //{
                string PicName = Path.GetFileName(URLTextBoxNew.Text);
                    string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    File.Copy(URLTextBoxNew.Text, Path.Combine(path + "\\Images\\", Path.GetFileName(URLTextBoxNew.Text)), true);
                    query = "Update banquit_hall set hall_name = '" + textBox1.Text.Trim() + "', RentOrSale = '" + ForComboBox.Text.Trim() + "',   Location = '" + textBox2.Text.Trim() + "',owner_name = '" + textBox4.Text.Trim() + "',mobile_no = '" + textBox5.Text.Trim() + "',land_line = '" + textBox6.Text.Trim() + "',authrise_name = '" + textBox7.Text.Trim() + "',mobile = '" + textBox8.Text.Trim() + "',land = '" + textBox9.Text.Trim() + "',plot_size = '" + textBox10.Text.Trim() + "',plot_statuts = '" + textBox11.Text.Trim() + "',Construction = '" + ConstructionComboBox.Text.Trim() + "',covred_area = '" + textBox12.Text.Trim() + "',floor = '" + FloorTextBox.Text.Trim() + "',parking_floor = '" + ParkingFloorComboBox.Text.Trim() + "',parking_space = '" + textBox14.Text.Trim() + "',gusets_capcity = '" + textBox15.Text.Trim() + "',functional_hall = '" + FunctionHallComboBox.Text.Trim() + "',hall_size = '" + HallSizeTextBox.Text.Trim() + "',warehose = '" + WareHouseComboBox.Text.Trim() + "',kitchen = '" + KitchenComboBox.Text.Trim() + "',bridal_room = '" + BridalComboBox.Text.Trim() + "',office_space = '" + OfficeSpaceComboBox.Text.Trim() + "',power_backup = '" + PowerBackupComboBox.Text.Trim() + "',lawan = '" + LawnComboBox.Text.Trim() + "',air_condition = '" + AirConditionComboBox.Text.Trim() + "',construction_year = '" + ConstructionYearTextBox.Text.Trim() + "',rate_per_head = '" + RatePerHeadTextBox.Text.Trim() + "',image = @img,Address = '" + textBox3.Text.Trim() + "',Video = @ved, imageURL = '" + PicName +  "' where ID =   " + Convert.ToInt32(textBox30.Text) + " ";

                {
                    File.Copy(URLTextBoxNew.Text, Path.Combine(path + "\\Images\\", Path.GetFileName(URLTextBoxNew.Text)), true);
                    query = "Update banquit_hall set hall_name = '" + textBox1.Text.Trim() + "', RentOrSale = '"+ ForComboBox.Text.Trim() + "', Location = '" + textBox2.Text.Trim() + "',owner_name = '" + textBox4.Text.Trim() + "',mobile_no = '" + textBox5.Text.Trim() + "',land_line = '" + textBox6.Text.Trim() + "',authrise_name = '" + textBox7.Text.Trim() + "',mobile = '" + textBox8.Text.Trim() + "',land = '" + textBox9.Text.Trim() + "',plot_size = '" + textBox10.Text.Trim() + "',plot_statuts = '" + textBox11.Text.Trim() + "',Construction = '" + ConstructionComboBox.Text.Trim() + "',covred_area = '" + textBox12.Text.Trim() + "',floor = '" + FloorTextBox.Text.Trim() + "',parking_floor = '" + ParkingFloorComboBox.Text.Trim() + "',parking_space = '" + textBox14.Text.Trim() + "',gusets_capcity = '" + textBox15.Text.Trim() + "',functional_hall = '" + FunctionHallComboBox.Text.Trim() + "',hall_size = '" + HallSizeTextBox.Text.Trim() + "',warehose = '" + WareHouseComboBox.Text.Trim() + "',kitchen = '" + KitchenComboBox.Text.Trim() + "',bridal_room = '" + BridalComboBox.Text.Trim() + "',office_space = '" + OfficeSpaceComboBox.Text.Trim() + "',power_backup = '" + PowerBackupComboBox.Text.Trim() + "',lawan = '" + LawnComboBox.Text.Trim() + "',air_condition = '" + AirConditionComboBox.Text.Trim() + "',construction_year = '" + ConstructionYearTextBox.Text.Trim() + "',rate_per_head = '" + RatePerHeadTextBox.Text.Trim() + "',image = '',Address = '" + textBox3.Text.Trim() + "',Video = '', imageURL = '" + PicName + "' where ID = " + Convert.ToInt32(textBox30.Text) + " ";
                    }

                    SqlConnection con = new SqlConnection(variables.cons);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);

                    if (img != null && img.Length > 0 && ved != null && ved.Length > 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("@img", img));
                        cmd.Parameters.Add(new SqlParameter("@ved", ved));
                    }
                    int x = cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Update Successfully");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            button1.Visible = false;
            AddNewPropertyButton.Visible = true;
            SaveUpdatesButton.Visible = true;
            button4.Visible = false;
            button2.Visible = false;

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
            FloorTextBox.Text = String.Empty;
            textBox14.Text = String.Empty;
            textBox15.Text = String.Empty;
            HallSizeTextBox.Text = String.Empty;
            RatePerHeadTextBox.Text = String.Empty;
            ConstructionYearTextBox.Text = String.Empty;
            //textBox19.Text = String.Empty;
            ParkingFloorTextBox.Text = String.Empty;
            FunctionHallTextBox.Text = String.Empty;
            WareHouseTextBox.Text = String.Empty;
            BridalTextBox.Text = String.Empty;
            PowerBackupTextBox.Text = String.Empty;
            AirConditionTextBox.Text = String.Empty;
            KitchenTextBox.Text = String.Empty;
            LawnTextBox.Text = String.Empty;
            OfficeSpaceTextBox.Text = String.Empty;
            textBox29.Text = String.Empty;


            ConstructionComboBox.Text = string.Empty;
            ParkingFloorComboBox.Text = string.Empty;
            FunctionHallComboBox.Text = string.Empty;
            WareHouseComboBox.Text = string.Empty;
            KitchenComboBox.Text = string.Empty;
            BridalComboBox.Text = string.Empty;
            LawnComboBox.Text = string.Empty;
            PowerBackupComboBox.Text = string.Empty;
            OfficeSpaceComboBox.Text = string.Empty;
            AirConditionComboBox.Text = string.Empty;
            //pictureBox1.Image = null;
            //pictureBox2.Image = null;
            groupBox1.Visible = true;

            textBox9.Visible = true;

            ConstructionComboBox.Visible = false;
            ParkingFloorComboBox.Visible = false;
            FunctionHallComboBox.Visible = false;
            WareHouseComboBox.Visible = false;
            KitchenComboBox.Visible = false;
            BridalComboBox.Visible = false;
            LawnComboBox.Visible = false;
            PowerBackupComboBox.Visible = false;
            OfficeSpaceComboBox.Visible = false;
            AirConditionComboBox.Visible = false;

            //textBox19.Visible = true;
            ParkingFloorTextBox.Visible = true;
            FunctionHallTextBox.Visible = true;
            WareHouseTextBox.Visible = true;
            BridalTextBox.Visible = true;
            PowerBackupTextBox.Visible = true;
            AirConditionTextBox.Visible = true;
            KitchenTextBox.Visible = true;
            LawnTextBox.Visible = true;
            OfficeSpaceTextBox.Visible = true;
            loading();
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            AddNewPropertyButton.Visible = true;
            label31.Visible = true;
            label32.Visible = true;

            loading();
        }

        private void GroupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }
        public static string SearchString = "";

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchString = SearchTextBox.Text;
            SearchedDataForm SearchedDataForm = new SearchedDataForm();
            SearchedDataForm.Show();
        }

        private void SearchFromBanquitHallfunction()
        {
            SearchString = SearchTextBox.Text;
            SearchedDataForm SearchedDataForm = new SearchedDataForm();
            SearchedDataForm.Show();
        }

        private void SearchAllButton_Click(object sender, EventArgs e)
        {
            SearchString = "";
            SearchedDataForm SearchedDataForm = new SearchedDataForm();
            SearchedDataForm.Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ForTextBox.Visible = false;
            AirConditionTextBox.Visible = false;

            PowerBackupTextBox.Visible = false;
            OfficeSpaceTextBox.Visible = false;

            BridalTextBox.Visible = false;

            LawnTextBox.Visible = false;
            WareHouseTextBox.Visible = false;
            KitchenTextBox.Visible = false; ;
            FunctionHallTextBox.Visible = false;
            ConstructionTextBox.Visible = false;



            EditButton.Visible = false;
            SaveUpdatesButton.Visible = true;
            ForComboBox.Visible = true;


            ConstructionComboBox.Visible = true;
            ParkingFloorComboBox.Visible = true;
            FunctionHallComboBox.Visible = true;
            WareHouseComboBox.Visible = true;
            BridalComboBox.Visible = true;
            PowerBackupComboBox.Visible = true;
            AirConditionComboBox.Visible = true;
            KitchenComboBox.Visible = true;
            LawnComboBox.Visible = true;
            OfficeSpaceComboBox.Visible = true;


            ForTextBox.BorderStyle = BorderStyle.Fixed3D;
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
            FloorTextBox.BorderStyle = BorderStyle.Fixed3D;
            textBox14.BorderStyle = BorderStyle.Fixed3D;
            textBox15.BorderStyle = BorderStyle.Fixed3D;
            HallSizeTextBox.BorderStyle = BorderStyle.Fixed3D;
            RatePerHeadTextBox.BorderStyle = BorderStyle.Fixed3D;
            ConstructionYearTextBox.BorderStyle = BorderStyle.Fixed3D;
            //textBox19.BorderStyle = BorderStyle.Fixed3D;
            ConstructionTextBox.BorderStyle = BorderStyle.Fixed3D;
            ParkingFloorTextBox.BorderStyle = BorderStyle.Fixed3D;
            FunctionHallTextBox.BorderStyle = BorderStyle.Fixed3D;
            WareHouseTextBox.BorderStyle = BorderStyle.Fixed3D;
            BridalTextBox.BorderStyle = BorderStyle.Fixed3D;
            PowerBackupTextBox.BorderStyle = BorderStyle.Fixed3D;
            AirConditionTextBox.BorderStyle = BorderStyle.Fixed3D;
            KitchenTextBox.BorderStyle = BorderStyle.Fixed3D;
            LawnTextBox.BorderStyle = BorderStyle.Fixed3D;
            OfficeSpaceTextBox.BorderStyle = BorderStyle.Fixed3D;
         
            //textBox20.Text = data.Rows[rowIndex]["parking_floor"].ToString();
            ParkingFloorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            //textBox21.Text = data.Rows[rowIndex]["functional_hall"].ToString();
            FunctionHallComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            //textBox22.Text = data.Rows[rowIndex]["warehose"].ToString();
            WareHouseComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            //textBox23.Text = data.Rows[rowIndex]["bridal_room"].ToString();
            BridalComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            //textBox24.Text = data.Rows[rowIndex]["power_backup"].ToString();
            PowerBackupComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            //textBox25.Text = data.Rows[rowIndex]["air_condition"].ToString();
            AirConditionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            //textBox26.Text = data.Rows[rowIndex]["kitchen"].ToString();
            KitchenComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            //textBox27.Text = data.Rows[rowIndex]["lawan"].ToString();
            LawnComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            //textBox28.Text = data.Rows[rowIndex]["office_space"].ToString();
            OfficeSpaceComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;



        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConstructionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void ParkingFloorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ConstructionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void KitchenTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LawnTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void OfficeSpaceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FunctionHallTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void WareHouseTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BridalTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PowerBackupTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void Label25_Click(object sender, EventArgs e)
        {

        }

        private void AirConditionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void AirConditionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OfficeSpaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PowerBackupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label30_Click(object sender, EventArgs e)
        {

        }

        private void Label29_Click(object sender, EventArgs e)
        {

        }

        private void Label26_Click(object sender, EventArgs e)
        {

        }

        private void Label28_Click(object sender, EventArgs e)
        {

        }

        private void ForTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ForComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
