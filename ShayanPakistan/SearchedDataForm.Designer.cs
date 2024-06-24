namespace ShayanPakistan
{
    partial class SearchedDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchedDataForm));
            this.SearchResultLabel = new System.Windows.Forms.Label();
            this.TotalRowsLabel = new System.Windows.Forms.Label();
            this.IDnumberLabel = new System.Windows.Forms.Label();
            this.imgg = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.SearchedDataGridView = new System.Windows.Forms.DataGridView();
            this.SrNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HallName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManagerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManagerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LandLineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.TotalNumberLabel = new System.Windows.Forms.Label();
            this.DPRPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.PrintButton = new System.Windows.Forms.Button();
            this.DPRPrintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.SearchedDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchResultLabel
            // 
            this.SearchResultLabel.AutoSize = true;
            this.SearchResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.SearchResultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(172)))), ((int)(((byte)(0)))));
            this.SearchResultLabel.Location = new System.Drawing.Point(12, 20);
            this.SearchResultLabel.Name = "SearchResultLabel";
            this.SearchResultLabel.Size = new System.Drawing.Size(147, 25);
            this.SearchResultLabel.TabIndex = 1;
            this.SearchResultLabel.Text = "Search Result";
            // 
            // TotalRowsLabel
            // 
            this.TotalRowsLabel.AutoSize = true;
            this.TotalRowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TotalRowsLabel.ForeColor = System.Drawing.Color.Black;
            this.TotalRowsLabel.Location = new System.Drawing.Point(11, 379);
            this.TotalRowsLabel.Name = "TotalRowsLabel";
            this.TotalRowsLabel.Size = new System.Drawing.Size(0, 15);
            this.TotalRowsLabel.TabIndex = 2;
            // 
            // IDnumberLabel
            // 
            this.IDnumberLabel.AutoSize = true;
            this.IDnumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.IDnumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(172)))), ((int)(((byte)(0)))));
            this.IDnumberLabel.Location = new System.Drawing.Point(364, 421);
            this.IDnumberLabel.Name = "IDnumberLabel";
            this.IDnumberLabel.Size = new System.Drawing.Size(0, 25);
            this.IDnumberLabel.TabIndex = 3;
            // 
            // imgg
            // 
            this.imgg.HeaderText = "";
            this.imgg.Image = ((System.Drawing.Image)(resources.GetObject("imgg.Image")));
            this.imgg.Name = "imgg";
            this.imgg.Width = 40;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 40;
            // 
            // SearchedDataGridView
            // 
            this.SearchedDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.SearchedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNO,
            this.HallName,
            this.Location,
            this.OwnerName,
            this.OwnerPhone,
            this.ManagerName,
            this.ManagerPhone,
            this.LandLineNo});
            this.SearchedDataGridView.Location = new System.Drawing.Point(6, 58);
            this.SearchedDataGridView.Name = "SearchedDataGridView";
            this.SearchedDataGridView.Size = new System.Drawing.Size(954, 311);
            this.SearchedDataGridView.TabIndex = 4;
            this.SearchedDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView2_CellContentClick);
            // 
            // SrNO
            // 
            this.SrNO.HeaderText = "No";
            this.SrNO.Name = "SrNO";
            this.SrNO.Visible = false;
            this.SrNO.Width = 40;
            // 
            // HallName
            // 
            this.HallName.HeaderText = "Hall Name";
            this.HallName.Name = "HallName";
            this.HallName.Width = 200;
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.Width = 150;
            // 
            // OwnerName
            // 
            this.OwnerName.HeaderText = "Owner Name";
            this.OwnerName.Name = "OwnerName";
            // 
            // OwnerPhone
            // 
            this.OwnerPhone.HeaderText = "Owner Phone";
            this.OwnerPhone.Name = "OwnerPhone";
            // 
            // ManagerName
            // 
            this.ManagerName.HeaderText = "Manager Name";
            this.ManagerName.Name = "ManagerName";
            this.ManagerName.Width = 120;
            // 
            // ManagerPhone
            // 
            this.ManagerPhone.HeaderText = "Manager Phone";
            this.ManagerPhone.Name = "ManagerPhone";
            this.ManagerPhone.Width = 120;
            // 
            // LandLineNo
            // 
            this.LandLineNo.HeaderText = "Land Line No";
            this.LandLineNo.Name = "LandLineNo";
            this.LandLineNo.Width = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // TotalNumberLabel
            // 
            this.TotalNumberLabel.AutoSize = true;
            this.TotalNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalNumberLabel.ForeColor = System.Drawing.Color.Red;
            this.TotalNumberLabel.Location = new System.Drawing.Point(111, 379);
            this.TotalNumberLabel.Name = "TotalNumberLabel";
            this.TotalNumberLabel.Size = new System.Drawing.Size(0, 20);
            this.TotalNumberLabel.TabIndex = 6;
            // 
            // DPRPrintDocument
            // 
            this.DPRPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.DPRPrintDocument_PrintPage);
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PrintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.PrintButton.ForeColor = System.Drawing.Color.White;
            this.PrintButton.Location = new System.Drawing.Point(856, 375);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(105, 32);
            this.PrintButton.TabIndex = 8;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // DPRPrintPreviewDialog
            // 
            this.DPRPrintPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.DPRPrintPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.DPRPrintPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.DPRPrintPreviewDialog.Enabled = true;
            this.DPRPrintPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("DPRPrintPreviewDialog.Icon")));
            this.DPRPrintPreviewDialog.Name = "DPRPrintPreviewDialog";
            this.DPRPrintPreviewDialog.Visible = false;
            this.DPRPrintPreviewDialog.Load += new System.EventHandler(this.DPRPrintPreviewDialog_Load);
            // 
            // SearchedDataForm
            // 
            this.ClientSize = new System.Drawing.Size(1008, 492);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.TotalNumberLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchedDataGridView);
            this.Controls.Add(this.IDnumberLabel);
            this.Controls.Add(this.TotalRowsLabel);
            this.Controls.Add(this.SearchResultLabel);
            this.Name = "SearchedDataForm";
            this.Load += new System.EventHandler(this.SearchedDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SearchedDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sno;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UpperGrid;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label SearchResultLabel;
        private System.Windows.Forms.Label TotalRowsLabel;
        private System.Windows.Forms.Label IDnumberLabel;
        private System.Windows.Forms.DataGridViewImageColumn imgg;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridView SearchedDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TotalNumberLabel;
        private System.Drawing.Printing.PrintDocument DPRPrintDocument;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.PrintPreviewDialog DPRPrintPreviewDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HallName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn LandLineNo;
    }
}

