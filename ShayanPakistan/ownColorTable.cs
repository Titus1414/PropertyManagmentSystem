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
    class ownColorTable : System.Windows.Forms.ProfessionalColorTable
    {

        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return Color.Black;
            }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return Color.FromArgb(255, 255, 255);
            }




        }


        public override Color MenuItemSelected
        {
            // when the menu is selected
            get { return Color.LightGray; } //FromArgb(255, 255, 255); }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.Black; }
        }
        //public override Color MenuItemSelectedGradientEnd
        //{
        //    get { return Color.Green; }
        //}

        public override Color MenuBorder
        {
            get
            {
                return Color.White;
            }
        }
        public override Color MenuItemBorder
        {
            get
            {
                return Color.Black;
            }
        }
        
        





    }
}