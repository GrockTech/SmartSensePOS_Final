namespace GPOS
{
    partial class ReceiptPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiptPreview));
            BillDVG = new DataGridView();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            button1 = new Button();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)BillDVG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // BillDVG
            // 
            BillDVG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BillDVG.Location = new Point(48, 101);
            BillDVG.Name = "BillDVG";
            BillDVG.RowHeadersWidth = 62;
            BillDVG.Size = new Size(678, 469);
            BillDVG.TabIndex = 0;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage_1;
            // 
            // button1
            // 
            button1.Location = new Point(567, 598);
            button1.Name = "button1";
            button1.Size = new Size(155, 34);
            button1.TabIndex = 1;
            button1.Text = "Print Receipt";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(720, 14);
            pictureBox2.Margin = new Padding(4, 5, 4, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(51, 65);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(329, 42);
            label2.Name = "label2";
            label2.Size = new Size(127, 25);
            label2.TabIndex = 8;
            label2.Text = "Receipt Details";
            // 
            // ReceiptPreview
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 666);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(button1);
            Controls.Add(BillDVG);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReceiptPreview";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReceiptPreview";
            Load += ReceiptPreview_Load;
            ((System.ComponentModel.ISupportInitialize)BillDVG).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView BillDVG;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button button1;
        private PictureBox pictureBox2;
        private Label label2;
    }
}