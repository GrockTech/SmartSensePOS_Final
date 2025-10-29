namespace GPOS
{
    partial class ViewCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCustomers));
            button2 = new Button();
            button1 = new Button();
            CusPhone = new TextBox();
            CusName = new TextBox();
            label13 = new Label();
            label10 = new Label();
            label11 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            label3 = new Label();
            label14 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            CustomerDGV = new DataGridView();
            panel1 = new Panel();
            CusAdd = new TextBox();
            label12 = new Label();
            CusRem = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CustomerDGV).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(766, 442);
            button2.Name = "button2";
            button2.Padding = new Padding(5);
            button2.Size = new Size(112, 34);
            button2.TabIndex = 64;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(648, 442);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 65;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CusPhone
            // 
            CusPhone.Location = new Point(648, 345);
            CusPhone.Name = "CusPhone";
            CusPhone.Size = new Size(298, 23);
            CusPhone.TabIndex = 61;
            CusPhone.TextChanged += CusPhone_TextChanged;
            // 
            // CusName
            // 
            CusName.Location = new Point(648, 165);
            CusName.Name = "CusName";
            CusName.Size = new Size(298, 23);
            CusName.TabIndex = 63;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(650, 203);
            label13.Name = "label13";
            label13.Size = new Size(143, 18);
            label13.TabIndex = 59;
            label13.Text = "Customer Address";
            label13.Click += label13_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(255, 128, 0);
            label10.Location = new Point(904, 458);
            label10.Name = "label10";
            label10.Size = new Size(44, 18);
            label10.TabIndex = 67;
            label10.Text = "Back";
            label10.Click += label10_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(647, 324);
            label11.Name = "label11";
            label11.Size = new Size(129, 18);
            label11.TabIndex = 57;
            label11.Text = "Customer Phone";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(142, 45);
            label1.Name = "label1";
            label1.Size = new Size(52, 19);
            label1.TabIndex = 55;
            label1.Text = "GPOS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(106, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(36, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 53;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Yellow;
            panel3.Controls.Add(label3);
            panel3.Location = new Point(322, 13);
            panel3.Name = "panel3";
            panel3.Size = new Size(154, 18);
            panel3.TabIndex = 54;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(2, 2);
            label3.Name = "label3";
            label3.Size = new Size(149, 13);
            label3.TabIndex = 5;
            label3.Text = "Point of Sale Version 16.2";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(647, 141);
            label14.Name = "label14";
            label14.Size = new Size(130, 18);
            label14.TabIndex = 60;
            label14.Text = "Customer  Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(253, 9);
            label2.Name = "label2";
            label2.Size = new Size(219, 19);
            label2.TabIndex = 4;
            label2.Text = "Point of Sale Version 16.2";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(615, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 39);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // CustomerDGV
            // 
            CustomerDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomerDGV.Location = new Point(39, 135);
            CustomerDGV.Name = "CustomerDGV";
            CustomerDGV.Size = new Size(551, 327);
            CustomerDGV.TabIndex = 56;
            CustomerDGV.CellContentClick += CustomerDGV_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(407, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(665, 44);
            panel1.TabIndex = 51;
            // 
            // CusAdd
            // 
            CusAdd.Location = new Point(647, 224);
            CusAdd.Multiline = true;
            CusAdd.Name = "CusAdd";
            CusAdd.Size = new Size(298, 82);
            CusAdd.TabIndex = 63;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(647, 375);
            label12.Name = "label12";
            label12.Size = new Size(149, 18);
            label12.TabIndex = 57;
            label12.Text = "Customer Remarks";
            label12.Click += label12_Click;
            // 
            // CusRem
            // 
            CusRem.Location = new Point(648, 396);
            CusRem.Multiline = true;
            CusRem.Name = "CusRem";
            CusRem.Size = new Size(298, 40);
            CusRem.TabIndex = 61;
            CusRem.TextChanged += CusPhone_TextChanged;
            // 
            // ViewCustomers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1073, 560);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(CusRem);
            Controls.Add(CusPhone);
            Controls.Add(CusAdd);
            Controls.Add(CusName);
            Controls.Add(label13);
            Controls.Add(label10);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel3);
            Controls.Add(label14);
            Controls.Add(CustomerDGV);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ViewCustomers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewCustomers";
            Load += ViewCustomers_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)CustomerDGV).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Button button1;
        private TextBox CusPhone;
        private TextBox CusName;
        private Label label13;
        private Label label10;
        private Label label11;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label label3;
        private Label label14;
        private Label label2;
        private PictureBox pictureBox2;
        private DataGridView CustomerDGV;
        private Panel panel1;
        private TextBox CusAdd;
        private Label label12;
        private TextBox CusRem;
    }
}