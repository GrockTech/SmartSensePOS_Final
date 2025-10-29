namespace GPOS
{
    partial class showValue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(showValue));
            pictureBox2 = new PictureBox();
            StoreValuems = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(372, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 39);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // StoreValuems
            // 
            StoreValuems.AutoSize = true;
            StoreValuems.Font = new Font("Verdana", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StoreValuems.ForeColor = Color.Peru;
            StoreValuems.Location = new Point(148, 74);
            StoreValuems.Name = "StoreValuems";
            StoreValuems.Size = new Size(131, 45);
            StoreValuems.TabIndex = 6;
            StoreValuems.Text = "label1";
            // 
            // showValue
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 216);
            Controls.Add(StoreValuems);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "showValue";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "showValue";
            Load += showValue_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label StoreValuems;
    }
}