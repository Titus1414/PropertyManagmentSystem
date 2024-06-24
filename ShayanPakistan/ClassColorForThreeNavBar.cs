using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShayanPakistan
{
    class ClassColorForThreeNavBar : System.Windows.Forms.ProfessionalColorTable
    {

        
            public override Color MenuItemSelected
            {
                get { return Color.Yellow; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.Orange; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.Yellow; }
            }



        //public override Color MenuItemPressedGradientBegin
        //{
        //    get
        //    {
        //        return Color.Yellow;
        //    }
        //}

        //public override Color MenuItemPressedGradientEnd
        //{
        //    get
        //    {
        //        return Color.Goldenrod;//.FromArgb(255, 255, 255);
        //    }




        //}


        //public override Color MenuItemSelected
        //{
        //    // when the menu is selected
        //    get { return Color.Yellow; } //FromArgb(255, 255, 255); }
        //}
        //public override Color MenuItemSelectedGradientBegin
        //{
        //    get { return Color.Yellow; }
        //}
        ////public override Color MenuItemSelectedGradientEnd
        ////{
        ////    get { return Color.Green; }
        ////}

        public override Color MenuBorder
        {
            get
            {
                return Color.FromArgb(230, 172, 0);
            }
        }
        public override Color MenuItemBorder
        {
            get
            {
                return Color.FromArgb(230, 172, 0);
            }
        }
    }
}
