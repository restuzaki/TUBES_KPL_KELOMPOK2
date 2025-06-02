namespace GUI_KPL
{
    partial class PembelianObatForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            cmbJenisObat = new ComboBox();
            txtJumlahObat = new TextBox();
            btnTambah = new Button();
            dataGridViewPembelian = new DataGridView();
            btnKembali = new Button();
            lblJenisObat = new Label();
            lblJumlahObat = new Label();
            lblJudul = new Label();
            btnBeli = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPembelian).BeginInit();
            SuspendLayout();
            // 
            // cmbJenisObat
            // 
            cmbJenisObat.FormattingEnabled = true;
            cmbJenisObat.Location = new Point(109, 101);
            cmbJenisObat.Margin = new Padding(3, 4, 3, 4);
            cmbJenisObat.Name = "cmbJenisObat";
            cmbJenisObat.Size = new Size(197, 28);
            cmbJenisObat.TabIndex = 0;
            cmbJenisObat.SelectedIndexChanged += cmbJenisObat_SelectedIndexChanged;
            // 
            // txtJumlahObat
            // 
            txtJumlahObat.Location = new Point(129, 140);
            txtJumlahObat.Margin = new Padding(3, 4, 3, 4);
            txtJumlahObat.Name = "txtJumlahObat";
            txtJumlahObat.Size = new Size(175, 27);
            txtJumlahObat.TabIndex = 1;
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.YellowGreen;
            btnTambah.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            btnTambah.ForeColor = Color.White;
            btnTambah.Location = new Point(150, 200);
            btnTambah.Margin = new Padding(3, 4, 3, 4);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(157, 48);
            btnTambah.TabIndex = 2;
            btnTambah.Text = "Tambah Ke Keranjang";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // dataGridViewPembelian
            // 
            dataGridViewPembelian.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPembelian.Location = new Point(328, 65);
            dataGridViewPembelian.Margin = new Padding(3, 4, 3, 4);
            dataGridViewPembelian.Name = "dataGridViewPembelian";
            dataGridViewPembelian.RowHeadersWidth = 51;
            dataGridViewPembelian.Size = new Size(510, 548);
            dataGridViewPembelian.TabIndex = 3;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.YellowGreen;
            btnKembali.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            btnKembali.ForeColor = Color.White;
            btnKembali.Location = new Point(150, 564);
            btnKembali.Margin = new Padding(3, 4, 3, 4);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(157, 49);
            btnKembali.TabIndex = 4;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // lblJenisObat
            // 
            lblJenisObat.AutoSize = true;
            lblJenisObat.Font = new Font("Yu Gothic UI Semibold", 9.75F, FontStyle.Bold);
            lblJenisObat.Location = new Point(14, 105);
            lblJenisObat.Name = "lblJenisObat";
            lblJenisObat.Size = new Size(99, 23);
            lblJenisObat.TabIndex = 5;
            lblJenisObat.Text = "Jenis Obat :";
            // 
            // lblJumlahObat
            // 
            lblJumlahObat.AutoSize = true;
            lblJumlahObat.Font = new Font("Yu Gothic UI Semibold", 9.75F, FontStyle.Bold);
            lblJumlahObat.Location = new Point(15, 144);
            lblJumlahObat.Name = "lblJumlahObat";
            lblJumlahObat.Size = new Size(117, 23);
            lblJumlahObat.TabIndex = 6;
            lblJumlahObat.Text = "Jumlah Obat :";
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.BackColor = SystemColors.Control;
            lblJudul.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold);
            lblJudul.ForeColor = Color.YellowGreen;
            lblJudul.Location = new Point(32, 25);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(228, 32);
            lblJudul.TabIndex = 7;
            lblJudul.Text = "Apotekku Beli Obat";
            // 
            // btnBeli
            // 
            btnBeli.BackColor = Color.YellowGreen;
            btnBeli.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            btnBeli.ForeColor = Color.White;
            btnBeli.Location = new Point(150, 263);
            btnBeli.Margin = new Padding(3, 4, 3, 4);
            btnBeli.Name = "btnBeli";
            btnBeli.Size = new Size(155, 48);
            btnBeli.TabIndex = 8;
            btnBeli.Text = "Beli Obat";
            btnBeli.UseVisualStyleBackColor = false;
            btnBeli.Click += btnBeli_Click;
            // 
            // PembelianObatForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(917, 689);
            Controls.Add(btnBeli);
            Controls.Add(lblJudul);
            Controls.Add(lblJumlahObat);
            Controls.Add(lblJenisObat);
            Controls.Add(btnKembali);
            Controls.Add(dataGridViewPembelian);
            Controls.Add(btnTambah);
            Controls.Add(txtJumlahObat);
            Controls.Add(cmbJenisObat);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PembelianObatForm";
            Text = "Pembelian Obat";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPembelian).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbJenisObat;
        private TextBox txtJumlahObat;
        private Button btnTambah;
        private DataGridView dataGridViewPembelian;
        private Button btnKembali;
        private Label lblJenisObat;
        private Label lblJumlahObat;
        private Label lblJudul;
        private Button btnBeli;
    }
}
