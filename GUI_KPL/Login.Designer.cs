namespace GUI_KPL
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
            button2 = new Button();
            label5 = new Label();
            button1 = new Button();
            checkBox1 = new CheckBox();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(353, 4);
            pictureBox1.Margin = new Padding(3, 4, 3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(426, 455);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold);
            label1.ForeColor = Color.YellowGreen;
            label1.Location = new Point(29, 56);
            label1.Name = "label1";
            label1.Size = new Size(169, 46);
            label1.TabIndex = 0;
            label1.Text = "Apotekku";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(344, 456);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = SystemColors.Control;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Yu Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.YellowGreen;
            button2.Location = new Point(183, 357);
            button2.Name = "button2";
            button2.Size = new Size(94, 31);
            button2.TabIndex = 9;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(40, 364);
            label5.Name = "label5";
            label5.Size = new Size(148, 20);
            label5.TabIndex = 2;
            label5.Text = "Belum Punya Akun?";
            // 
            // button1
            // 
            button1.BackColor = Color.YellowGreen;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.BorderSize = 4;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Yu Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(38, 309);
            button1.Name = "button1";
            button1.Size = new Size(212, 38);
            button1.TabIndex = 8;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Cursor = Cursors.Hand;
            checkBox1.Font = new Font("Yu Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox1.Location = new Point(165, 275);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(158, 26);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Show Password";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ScrollBar;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Yu Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(29, 229);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(237, 35);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic Medium", 10F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(29, 204);
            label3.Name = "label3";
            label3.Size = new Size(95, 22);
            label3.TabIndex = 3;
            label3.Text = "Password";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ScrollBar;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Yu Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(29, 142);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(237, 34);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic Medium", 10F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(29, 117);
            label2.Name = "label2";
            label2.Size = new Size(98, 22);
            label2.TabIndex = 1;
            label2.Text = "Username";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.YellowGreen;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.7980423F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.2019577F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 93.650795F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.34920645F));
            tableLayoutPanel1.Size = new Size(782, 462);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 462);
            Controls.Add(tableLayoutPanel1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel1;
        private Button button2;
        private Label label5;
        private Button button1;
        private CheckBox checkBox1;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
    }
}