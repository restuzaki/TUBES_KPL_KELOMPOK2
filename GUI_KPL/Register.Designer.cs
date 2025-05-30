namespace GUI_KPL
{
    partial class Register
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            label1 = new Label();
            panel1 = new Panel();
            button2 = new Button();
            label5 = new Label();
            button1 = new Button();
            checkBox1 = new CheckBox();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold);
            label1.ForeColor = Color.YellowGreen;
            label1.Location = new Point(47, 90);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(449, 72);
            label1.TabIndex = 0;
            label1.Text = "Selamat Datang, ";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(5, 5);
            panel1.Margin = new Padding(5, 5, 5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(572, 804);
            panel1.TabIndex = 1;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = SystemColors.Control;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Yu Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.YellowGreen;
            button2.Location = new Point(297, 688);
            button2.Margin = new Padding(5, 5, 5, 5);
            button2.Name = "button2";
            button2.Size = new Size(107, 50);
            button2.TabIndex = 9;
            button2.Text = "Login";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(65, 699);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(236, 31);
            label5.TabIndex = 2;
            label5.Text = "Sudah Punya Akun?";
            // 
            // button1
            // 
            button1.BackColor = Color.YellowGreen;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.BorderSize = 4;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Yu Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(62, 611);
            button1.Margin = new Padding(5, 5, 5, 5);
            button1.Name = "button1";
            button1.Size = new Size(344, 61);
            button1.TabIndex = 8;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Cursor = Cursors.Hand;
            checkBox1.Font = new Font("Yu Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(268, 560);
            checkBox1.Margin = new Padding(5, 5, 5, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(253, 40);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ScrollBar;
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("Yu Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(47, 496);
            textBox3.Margin = new Padding(5, 5, 5, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(384, 51);
            textBox3.TabIndex = 6;
            textBox3.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic Medium", 10F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(47, 456);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(259, 35);
            label4.TabIndex = 5;
            label4.Text = "Confrim Password";
            label4.TextAlign = ContentAlignment.TopRight;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ScrollBar;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Yu Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(47, 366);
            textBox2.Margin = new Padding(5, 5, 5, 5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(384, 51);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic Medium", 10F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(47, 326);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(145, 35);
            label3.TabIndex = 3;
            label3.Text = "Password";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ScrollBar;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Yu Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(47, 227);
            textBox1.Margin = new Padding(5, 5, 5, 5);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(384, 53);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic Medium", 10F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(47, 187);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(151, 35);
            label2.TabIndex = 1;
            label2.Text = "Username";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(587, 6);
            pictureBox1.Margin = new Padding(5, 6, 5, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(708, 803);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.7980423F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.2019577F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(5, 5, 5, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 93.650795F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.34920645F));
            tableLayoutPanel1.Size = new Size(1300, 814);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.YellowGreen;
            ClientSize = new Size(1300, 814);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aplikasi Apotek";
            Load += Register_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private CheckBox checkBox1;
        private Button button1;
        private Label label5;
        private Button button2;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
