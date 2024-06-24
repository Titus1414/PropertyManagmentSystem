using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShayanPakistan
{
    public partial class temp : Form
    {
        public temp()
        {
            InitializeComponent();

            // variables.cons = @"Data Source = DESKTOP-2RPIP22\SQLEXPRESS; Initial Catalog = ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayans; Password=123456789";
            //For Live
            variables.cons = @"data source=win10.hosterpk.com;initial catalog=ProperticaDesck_db;persist security info=True;user id=ProperticaDB;password=Propertica@123; MultipleActiveResultSets=True;";
            //For Home
            //variables.cons = (@"Data Source=DESKTOP-0R1BI80\SQLEXPRESS; Initial Catalog= ShayanPakistanD.P.R; Persist Security Info=True; User ID=Mujtaba; Password=1234567887654321");
            //Form2 obj = new Form2();
            //obj.Show();
            //this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //variables.cons = @"Data Source = DESKTOP-2RPIP22\SQLEXPRESS; Initial Catalog = ShayanPakistanD.P.R; Persist Security Info=True; User ID=Shayans; Password=123456789";
            //For Live
            variables.cons = @"data source=win10.hosterpk.com;initial catalog=ProperticaDesck_db;persist security info=True;user id=ProperticaDB;password=Propertica@123; MultipleActiveResultSets=True;";
            //variables.cons = @"data source=win10.hosterpk.com;initial catalog=ProperticaDesck_db;persist security info=True;user id=ProperticaDB;password=Propertica@123; MultipleActiveResultSets=True;";
            //For Home
            //variables.cons = (@"Data Source=DESKTOP-0R1BI80\SQLEXPRESS; Initial Catalog= ShayanPakistanD.P.R; Persist Security Info=True; User ID=Mujtaba; Password=1234567887654321");
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //office//Local Server
            //variables.cons = @"data source=win10.hosterpk.com;initial catalog=ProperticaDesck_db;persist security info=True;user id=ProperticaDB;password=Propertica@123; MultipleActiveResultSets=True;";
            variables.cons = "Data Source = 192.168.0.15,1433; Initial Catalog = ProperticaDesck_db; Persist Security Info = True; User ID = Titus; Password = Titus@123";
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();

        }
    }
}
