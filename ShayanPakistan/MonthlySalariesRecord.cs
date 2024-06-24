using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShayanPakistan
{
    public partial class MonthlySalariesRecord : Form
    {
        SqlConnection con = new SqlConnection(variables.cons);
        DateTime dt = DateTime.Now.Date;
        StringFormat strFormat;
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        public MonthlySalariesRecord()
        {
            InitializeComponent();

           
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        void LoadData(DateTime date) {

            using (SqlConnection con = new SqlConnection(variables.cons))
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("sp_MonthlySalaryRecord", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date", date);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                bindingSource1.DataSource = dt;
                dataGridView1.DataSource = bindingSource1;
                //dataGridView1.Columns["MonthIInDays"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                //dataGridView1.Columns["Staff_Name"].Width = 130;
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 50;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
                dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridView1_CellPainting);
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[21].Value);
                }
                label4.Text = sum.ToString();
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                con.Close();
            }
        }

        private BindingSource bindingSource1 = new BindingSource();
        private void MonthlySalariesRecord_Load(object sender, EventArgs e)
        {
            LoadData(date:dt);
            label1.Text = dt.ToString("MMMM yyyy");
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            
            label1.Text = Convert.ToDateTime(label1.Text).AddMonths(-1).ToLongDateString();
            dt = Convert.ToDateTime(label1.Text);
            label1.Text = dt.ToString("MMMM yyyy");
            LoadData(date: dt);
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            label1.Text = Convert.ToDateTime(label1.Text).AddMonths(1).ToLongDateString();
            dt = Convert.ToDateTime(label1.Text);
            label1.Text = dt.ToString("MMMM yyyy");
            LoadData(date: dt);
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime datepicker = dateTimePicker1.Value;
            label1.Text = datepicker.ToLongDateString();
            dt = Convert.ToDateTime(label1.Text);
            LoadData(date: dt);
        }
        private void Save_btn_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
        ////Bitmap bmp;
        private void Button1_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            (printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument1;
            if (DialogResult.OK == printPreviewDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }
            //PrintDialog printDialog = new PrintDialog();
            //printDialog.Document = printDocument1;
            //printDialog.UseEXDialog = true;
            //Get the document
            //if (DialogResult.OK == printDialog.ShowDialog())
            //{
            //    printDocument1.DocumentName = "Test Page Print";
            //    printDocument1.Print();
            //}


            //////printDocument1.DefaultPageSettings.Landscape = true;
            //////(printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;

            //////printPreviewDialog1.Document = printDocument1;
            //////printPreviewDialog1.ShowDialog();

            ////int height = dataGridView1.Height;
            ////dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            ////bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            ////dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            ////dataGridView1.Height = height;
            ////printPreviewDialog1.ShowDialog();

            //(printPreviewDialog1 as Form).WindowState = FormWindowState.Maximized;
            //if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            //{
            //printDocument1.Print();
            //}
        }
        private void PrintDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PrintDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                            (double)iTotalWidth * (double)iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            System.Drawing.Image img = System.Drawing.Image.FromFile("E:\\SVN\\Titus\\ShayanPakistan\\ShayanPakistan\\Images\\logo-inverse.png");
                            Bitmap dst = new Bitmap(200, 80);
                            e.Graphics.DrawImage(img, 500, 10, dst.Width, dst.Height);

                            String strDate = DateTime.Now.ToString("dd-MMM-yyy");// + " " + DateTime.Now.ToShortTimeString();

                            e.Graphics.DrawString("Propertica Staff Salaries " + strDate,
                                new Font("Calibri", 14, FontStyle.Bold),
                                Brushes.Black, 450,
                                115 - e.Graphics.MeasureString("Propertica Staff Salaries" + strDate,
                                new Font("Calibri", 14, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            
                            //Draw Date
                            //e.Graphics.DrawString(strDate,
                            //    new Font(dataGridView1.Font, FontStyle.Bold), Brushes.Black,
                            //    e.MarginBounds.Left +
                            //    (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                            //    new Font(dataGridView1.Font, FontStyle.Bold),
                            //    e.MarginBounds.Width).Width),
                            //    e.MarginBounds.Top - e.Graphics.MeasureString("Propertica Staff Salaries",
                            //    new Font(new Font(dataGridView1.Font, FontStyle.Bold),
                            //    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,(int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                //e.Graphics.DrawRectangle(Pens.Black,
                                //    new Rectangle((int)arrColumnLefts[0], iTopMargin,
                                //    (int)arrColumnWidths[0], 80));

                                //e.Graphics.DrawRectangle(Pens.Black,
                                //    new Rectangle((int)arrColumnLefts[1], iTopMargin,
                                //    (int)arrColumnWidths[1], 80));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(),
                                    Cel.InheritedStyle.Font,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }



            //////Bitmap bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            //////dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            //////Bitmap dst = new Bitmap(100, 80);
            //////e.Graphics.DrawImage(bitmap, 10, 10, dst.Width, dst.Height);
            ////e.Graphics.DrawImage(bmp, 0, 0);

            //var myPaintArgs = new PaintEventArgs
            //(
            //    e.Graphics,
            //    new Rectangle(new Point(0, 0), this.Size)
            //);
            //this.InvokePaint(dataGridView1, myPaintArgs);
        }

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                Rectangle rect = this.dataGridView1.GetColumnDisplayRectangle(e.ColumnIndex, true);
                Size titleSize = TextRenderer.MeasureText(e.Value.ToString(), e.CellStyle.Font);
                if (this.dataGridView1.ColumnHeadersHeight < titleSize.Width)
                {
                    this.dataGridView1.ColumnHeadersHeight = titleSize.Width;
                }

                e.Graphics.TranslateTransform(0, titleSize.Width);
                e.Graphics.RotateTransform(-90.0F);

                // This is the key line for bottom alignment - we adjust the PointF based on the 
                // ColumnHeadersHeight minus the current text width. ColumnHeadersHeight is the
                // maximum of all the columns since we paint cells twice - though this fact
                // may not be true in all usages!   
                e.Graphics.DrawString(e.Value.ToString(), new Font("Times new Roman", 12, FontStyle.Bold) , Brushes.White, new PointF(rect.Y - (dataGridView1.ColumnHeadersHeight - titleSize.Width), rect.X));

                // The old line for comparison
                //e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y, rect.X));

                this.dataGridView1.EnableHeadersVisualStyles = false;

                //DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
                //col5.DefaultCellStyle.BackColor = Color.Yellow; col5.HeaderCell.Style.Font = new Font("Arial", 8, FontStyle.Bold);
                //col5.HeaderCell.Style.BackColor = Color.Yellow;

                e.Graphics.RotateTransform(90.0F);
                e.Graphics.TranslateTransform(0, -titleSize.Width);
                e.Handled = true;
            }
            

        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Sr_no"].Value = (e.RowIndex + 1).ToString();
        }
    }
}
