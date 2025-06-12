namespace GUI_KPL
{
    partial class ManajemenPegawai
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            MasukkanPegawai = new TextBox();
            MasukkanNama = new TextBox();
            MasukkanJabatan = new TextBox();
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            TombolTambah = new Button();
            TombolUpdate = new Button();
            TombolSemua = new Button();
            TombolHapus = new Button();
            TombolCariP = new Button();
            TombolKembali = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI Semibold", 20F, FontStyle.Bold);
            label1.ForeColor = Color.YellowGreen;
            label1.Location = new Point(12, 40);
            label1.Name = "label1";
            label1.Size = new Size(340, 46);
            label1.TabIndex = 1;
            label1.Text = "Manajemen pegawai";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic Medium", 10F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(22, 127);
            label2.Name = "label2";
            label2.Size = new Size(113, 22);
            label2.TabIndex = 5;
            label2.Text = "ID pegawai:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic Medium", 10F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(22, 192);
            label3.Name = "label3";
            label3.Size = new Size(66, 22);
            label3.TabIndex = 6;
            label3.Text = "Nama:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic Medium", 10F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(22, 259);
            label4.Name = "label4";
            label4.Size = new Size(83, 22);
            label4.TabIndex = 7;
            label4.Text = "Jabatan:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic Medium", 10F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(22, 325);
            label5.Name = "label5";
            label5.Size = new Size(73, 22);
            label5.TabIndex = 8;
            label5.Text = "Status:";
            // 
            // MasukkanPegawai
            // 
            MasukkanPegawai.BackColor = SystemColors.ScrollBar;
            MasukkanPegawai.BorderStyle = BorderStyle.FixedSingle;
            MasukkanPegawai.Font = new Font("Yu Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MasukkanPegawai.Location = new Point(158, 125);
            MasukkanPegawai.Multiline = true;
            MasukkanPegawai.Name = "MasukkanPegawai";
            MasukkanPegawai.Size = new Size(237, 34);
            MasukkanPegawai.TabIndex = 9;
            MasukkanPegawai.TextChanged += MasukkanPegawai_TextChanged;
            // 
            // MasukkanNama
            // 
            MasukkanNama.BackColor = SystemColors.ScrollBar;
            MasukkanNama.BorderStyle = BorderStyle.FixedSingle;
            MasukkanNama.Font = new Font("Yu Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MasukkanNama.Location = new Point(158, 180);
            MasukkanNama.Multiline = true;
            MasukkanNama.Name = "MasukkanNama";
            MasukkanNama.Size = new Size(237, 34);
            MasukkanNama.TabIndex = 10;
            MasukkanNama.TextChanged += MasukkanNama_TextChanged;
            // 
            // MasukkanJabatan
            // 
            MasukkanJabatan.BackColor = SystemColors.ScrollBar;
            MasukkanJabatan.BorderStyle = BorderStyle.FixedSingle;
            MasukkanJabatan.Font = new Font("Yu Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MasukkanJabatan.Location = new Point(158, 247);
            MasukkanJabatan.Multiline = true;
            MasukkanJabatan.Name = "MasukkanJabatan";
            MasukkanJabatan.Size = new Size(237, 34);
            MasukkanJabatan.TabIndex = 11;
            MasukkanJabatan.TextChanged += MasukkanJabatan_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 433);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(766, 236);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(158, 325);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(237, 28);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // TombolTambah
            // 
            TombolTambah.BackColor = Color.YellowGreen;
            TombolTambah.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            TombolTambah.ForeColor = Color.White;
            TombolTambah.Location = new Point(35, 385);
            TombolTambah.Margin = new Padding(4);
            TombolTambah.Name = "TombolTambah";
            TombolTambah.Size = new Size(100, 41);
            TombolTambah.TabIndex = 21;
            TombolTambah.Text = "Tambah";
            TombolTambah.UseVisualStyleBackColor = false;
            TombolTambah.Click += TombolTambah_Click;
            // 
            // TombolUpdate
            // 
            TombolUpdate.BackColor = Color.YellowGreen;
            TombolUpdate.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            TombolUpdate.ForeColor = Color.White;
            TombolUpdate.Location = new Point(158, 385);
            TombolUpdate.Margin = new Padding(4);
            TombolUpdate.Name = "TombolUpdate";
            TombolUpdate.Size = new Size(100, 41);
            TombolUpdate.TabIndex = 22;
            TombolUpdate.Text = "Update";
            TombolUpdate.UseVisualStyleBackColor = false;
            TombolUpdate.Click += TombolUpdate_Click;
            // 
            // TombolSemua
            // 
            TombolSemua.BackColor = Color.YellowGreen;
            TombolSemua.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            TombolSemua.ForeColor = Color.White;
            TombolSemua.Location = new Point(278, 385);
            TombolSemua.Margin = new Padding(4);
            TombolSemua.Name = "TombolSemua";
            TombolSemua.Size = new Size(100, 41);
            TombolSemua.TabIndex = 23;
            TombolSemua.Text = "Tampilkan";
            TombolSemua.UseVisualStyleBackColor = false;
            TombolSemua.Click += TombolSemua_Click;
            // 
            // TombolHapus
            // 
            TombolHapus.BackColor = Color.YellowGreen;
            TombolHapus.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            TombolHapus.ForeColor = Color.White;
            TombolHapus.Location = new Point(556, 118);
            TombolHapus.Margin = new Padding(4);
            TombolHapus.Name = "TombolHapus";
            TombolHapus.Size = new Size(100, 41);
            TombolHapus.TabIndex = 24;
            TombolHapus.Text = "Hapus";
            TombolHapus.UseVisualStyleBackColor = false;
            TombolHapus.Click += TombolHapus_Click;
            // 
            // TombolCariP
            // 
            TombolCariP.BackColor = Color.YellowGreen;
            TombolCariP.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            TombolCariP.ForeColor = Color.White;
            TombolCariP.Location = new Point(433, 118);
            TombolCariP.Margin = new Padding(4);
            TombolCariP.Name = "TombolCariP";
            TombolCariP.Size = new Size(100, 41);
            TombolCariP.TabIndex = 25;
            TombolCariP.Text = "Cari";
            TombolCariP.UseVisualStyleBackColor = false;
            TombolCariP.Click += TombolCariP_Click;
            // 
            // TombolKembali
            // 
            TombolKembali.BackColor = Color.YellowGreen;
            TombolKembali.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            TombolKembali.ForeColor = Color.White;
            TombolKembali.Location = new Point(22, 694);
            TombolKembali.Margin = new Padding(3, 4, 3, 4);
            TombolKembali.Name = "TombolKembali";
            TombolKembali.Size = new Size(117, 53);
            TombolKembali.TabIndex = 26;
            TombolKembali.Text = "Kembali";
            TombolKembali.UseVisualStyleBackColor = false;
            TombolKembali.Click += TombolKembali_Click;
            // 
            // ManajemenPegawai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 760);
            Controls.Add(TombolKembali);
            Controls.Add(TombolCariP);
            Controls.Add(TombolHapus);
            Controls.Add(TombolSemua);
            Controls.Add(TombolUpdate);
            Controls.Add(TombolTambah);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Controls.Add(MasukkanJabatan);
            Controls.Add(MasukkanNama);
            Controls.Add(MasukkanPegawai);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ManajemenPegawai";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ManajemenPegawai";
            Load += ManajemenPegawai_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox MasukkanPegawai;
        private TextBox MasukkanNama;
        private TextBox MasukkanJabatan;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Button TombolTambah;
        private Button TombolUpdate;
        private Button TombolSemua;
        private Button TombolHapus;
        private Button TombolCariP;
        private Button TombolKembali;
    }
}