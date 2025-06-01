namespace GUI_KPL
{
    partial class PembelianObatForm
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(95, 76);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(173, 23);
            comboBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 105);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(154, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.YellowGreen;
            button1.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(131, 150);
            button1.Name = "button1";
            button1.Size = new Size(137, 36);
            button1.TabIndex = 2;
            button1.Text = "Tambah Ke Keranjang";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(287, 49);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(446, 411);
            dataGridView1.TabIndex = 3;
            // 
            // button2
            // 
            button2.BackColor = Color.YellowGreen;
            button2.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(131, 423);
            button2.Name = "button2";
            button2.Size = new Size(137, 37);
            button2.TabIndex = 4;
            button2.Text = "Kembali";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI Semibold", 9.75F, FontStyle.Bold);
            label1.Location = new Point(12, 79);
            label1.Name = "label1";
            label1.Size = new Size(78, 17);
            label1.TabIndex = 5;
            label1.Text = "Jenis Obat :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Semibold", 9.75F, FontStyle.Bold);
            label2.Location = new Point(13, 108);
            label2.Name = "label2";
            label2.Size = new Size(92, 17);
            label2.TabIndex = 6;
            label2.Text = "Jumlah Obat :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.YellowGreen;
            label3.Location = new Point(28, 19);
            label3.Name = "label3";
            label3.Size = new Size(178, 25);
            label3.TabIndex = 7;
            label3.Text = "Apotekku Beli Obat";
            // 
            // button3
            // 
            button3.BackColor = Color.YellowGreen;
            button3.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(131, 197);
            button3.Name = "button3";
            button3.Size = new Size(136, 36);
            button3.TabIndex = 8;
            button3.Text = "Beli Obat ";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // PembelianObatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(802, 517);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Name = "PembelianObatForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private TextBox textBox1;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button3;
    }
}