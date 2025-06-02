namespace GUI_KPL
{
    partial class CekIzinObat
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
            label1 = new Label();
            MasukkanObat = new TextBox();
            label2 = new Label();
            TombolCari = new Button();
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            label3 = new Label();
            TombolKembali = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold);
            label1.ForeColor = Color.YellowGreen;
            label1.Location = new Point(39, 38);
            label1.Name = "label1";
            label1.Size = new Size(219, 46);
            label1.TabIndex = 0;
            label1.Text = "Cek izin obat";
            label1.Click += label1_Click;
            // 
            // MasukkanObat
            // 
            MasukkanObat.BackColor = SystemColors.ScrollBar;
            MasukkanObat.BorderStyle = BorderStyle.FixedSingle;
            MasukkanObat.Font = new Font("Yu Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MasukkanObat.Location = new Point(39, 138);
            MasukkanObat.Multiline = true;
            MasukkanObat.Name = "MasukkanObat";
            MasukkanObat.Size = new Size(237, 34);
            MasukkanObat.TabIndex = 3;
            MasukkanObat.TextChanged += MasukkanObat_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic Medium", 10F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(39, 113);
            label2.Name = "label2";
            label2.Size = new Size(170, 22);
            label2.TabIndex = 4;
            label2.Text = "Masukkan ID obat";
            label2.Click += label2_Click;
            // 
            // TombolCari
            // 
            TombolCari.BackColor = Color.YellowGreen;
            TombolCari.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            TombolCari.ForeColor = Color.White;
            TombolCari.Location = new Point(176, 205);
            TombolCari.Margin = new Padding(4);
            TombolCari.Name = "TombolCari";
            TombolCari.Size = new Size(100, 41);
            TombolCari.TabIndex = 20;
            TombolCari.Text = "Cari";
            TombolCari.UseVisualStyleBackColor = false;
            TombolCari.Click += TombolCari_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(371, 138);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(417, 286);
            dataGridView1.TabIndex = 21;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Terdaftar", "Tidak Terdaftar", "Kadaluarsa" });
            comboBox1.Location = new Point(371, 104);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(237, 28);
            comboBox1.TabIndex = 22;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic Medium", 10F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(371, 79);
            label3.Name = "label3";
            label3.Size = new Size(95, 22);
            label3.TabIndex = 23;
            label3.Text = "Filter izin";
            // 
            // TombolKembali
            // 
            TombolKembali.BackColor = Color.YellowGreen;
            TombolKembali.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            TombolKembali.ForeColor = Color.White;
            TombolKembali.Location = new Point(12, 443);
            TombolKembali.Margin = new Padding(3, 4, 3, 4);
            TombolKembali.Name = "TombolKembali";
            TombolKembali.Size = new Size(117, 53);
            TombolKembali.TabIndex = 24;
            TombolKembali.Text = "Kembali";
            TombolKembali.UseVisualStyleBackColor = false;
            TombolKembali.Click += button3_Click;
            // 
            // CekIzinObat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 509);
            Controls.Add(TombolKembali);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Controls.Add(TombolCari);
            Controls.Add(label2);
            Controls.Add(MasukkanObat);
            Controls.Add(label1);
            Name = "CekIzinObat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CekIzinObat";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox MasukkanObat;
        private Label label2;
        private Button TombolCari;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Label label3;
        private Button TombolKembali;
    }
}