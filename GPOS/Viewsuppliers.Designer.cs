namespace GPOS
{
    partial class Viewsuppliers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewsuppliers));
            button2 = new Button();
            button1 = new Button();
            SupPhone = new TextBox();
            SupAdd = new TextBox();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            SupName = new TextBox();
            label13 = new Label();
            label10 = new Label();
            SupplierDGV = new DataGridView();
            label14 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label11 = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            SupRem = new TextBox();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SupplierDGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(756, 416);
            button2.Name = "button2";
            button2.Padding = new Padding(5);
            button2.Size = new Size(112, 34);
            button2.TabIndex = 80;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(638, 416);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 81;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SupPhone
            // 
            SupPhone.Location = new Point(633, 308);
            SupPhone.Name = "SupPhone";
            SupPhone.Size = new Size(298, 23);
            SupPhone.TabIndex = 77;
            // 
            // SupAdd
            // 
            SupAdd.Location = new Point(631, 190);
            SupAdd.Multiline = true;
            SupAdd.Name = "SupAdd";
            SupAdd.Size = new Size(298, 82);
            SupAdd.TabIndex = 78;
            SupAdd.TextChanged += textBox2_TextChanged;
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
            // SupName
            // 
            SupName.Location = new Point(632, 131);
            SupName.Name = "SupName";
            SupName.Size = new Size(298, 23);
            SupName.TabIndex = 79;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(634, 169);
            label13.Name = "label13";
            label13.Size = new Size(68, 18);
            label13.TabIndex = 75;
            label13.Text = "Address";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(255, 128, 0);
            label10.Location = new Point(894, 432);
            label10.Name = "label10";
            label10.Size = new Size(44, 18);
            label10.TabIndex = 82;
            label10.Text = "Back";
            label10.Click += label10_Click;
            // 
            // SupplierDGV
            // 
            SupplierDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SupplierDGV.Location = new Point(47, 109);
            SupplierDGV.Name = "SupplierDGV";
            SupplierDGV.Size = new Size(526, 327);
            SupplierDGV.TabIndex = 73;
            SupplierDGV.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(631, 107);
            label14.Name = "label14";
            label14.Size = new Size(122, 18);
            label14.TabIndex = 76;
            label14.Text = "Supplier  Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(126, 45);
            label1.Name = "label1";
            label1.Size = new Size(52, 19);
            label1.TabIndex = 72;
            label1.Text = "GPOS";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(90, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(36, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 70;
            pictureBox1.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(632, 285);
            label11.Name = "label11";
            label11.Size = new Size(54, 18);
            label11.TabIndex = 74;
            label11.Text = "Phone";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Yellow;
            panel3.Controls.Add(label3);
            panel3.Location = new Point(306, 13);
            panel3.Name = "panel3";
            panel3.Size = new Size(154, 18);
            panel3.TabIndex = 71;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(391, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(665, 44);
            panel1.TabIndex = 68;
            // 
            // SupRem
            // 
            SupRem.Location = new Point(634, 362);
            SupRem.Multiline = true;
            SupRem.Name = "SupRem";
            SupRem.Size = new Size(298, 41);
            SupRem.TabIndex = 77;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Tahoma", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(633, 340);
            label12.Name = "label12";
            label12.Size = new Size(74, 18);
            label12.TabIndex = 83;
            label12.Text = "Remarks";
            // 
            // Viewsuppliers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1057, 521);
            Controls.Add(label12);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(SupRem);
            Controls.Add(SupPhone);
            Controls.Add(SupAdd);
            Controls.Add(SupName);
            Controls.Add(label13);
            Controls.Add(label10);
            Controls.Add(SupplierDGV);
            Controls.Add(label14);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(label11);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Viewsuppliers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "6yy6y46";
            Load += Viewsuppliers_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)SupplierDGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private TextBox SupPhone;
        private TextBox SupAdd;
        private Label label2;
        private PictureBox pictureBox2;
        private Label label3;
        private TextBox SupName;
        private Label label13;
        private Label label10;
        private DataGridView SupplierDGV;
        private Label label14;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label11;
        private Panel panel3;
        private Panel panel1;
        private TextBox SupRem;
        private Label label12;
    }
}