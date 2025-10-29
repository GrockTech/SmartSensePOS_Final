namespace GPOS
{
    partial class lowstock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lowstock));
            label1 = new Label();
            LD = new DataGridView();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)LD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(245, 23);
            label1.Name = "label1";
            label1.Size = new Size(306, 35);
            label1.TabIndex = 0;
            label1.Text = "LOW STOCK PRODUCTS";
            // 
            // LD
            // 
            LD.AllowUserToAddRows = false;
            LD.AllowUserToDeleteRows = false;
            LD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LD.Location = new Point(19, 76);
            LD.Name = "LD";
            LD.ReadOnly = true;
            LD.Size = new Size(803, 353);
            LD.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(758, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 42);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lowstock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 462);
            Controls.Add(pictureBox1);
            Controls.Add(LD);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "lowstock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "lowstock";
            Load += lowstock_Load;
            ((System.ComponentModel.ISupportInitialize)LD).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView LD;
        private PictureBox pictureBox1;
    }
}