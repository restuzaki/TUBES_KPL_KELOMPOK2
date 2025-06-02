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

            ((System.ComponentModel.ISupportInitialize)(dataGridViewPembelian)).BeginInit();
            SuspendLayout();

            // 
            // cmbJenisObat
            // 
            cmbJenisObat.FormattingEnabled = true;
            cmbJenisObat.Location = new Point(95, 76);
            cmbJenisObat.Name = "cmbJenisObat";
            cmbJenisObat.Size = new Size(173, 23);
            cmbJenisObat.TabIndex = 0;

            // 
            // txtJumlahObat
            // 
            txtJumlahObat.Location = new Point(113, 105);
            txtJumlahObat.Name = "txtJumlahObat";
            txtJumlahObat.Size = new Size(154, 23);
            txtJumlahObat.TabIndex = 1;

            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.YellowGreen;
            btnTambah.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            btnTambah.ForeColor = Color.White;
            btnTambah.Location = new Point(131, 150);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(137, 36);
            btnTambah.TabIndex = 2;
            btnTambah.Text = "Tambah Ke Keranjang";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;

            // 
            // dataGridViewPembelian
            // 
            dataGridViewPembelian.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPembelian.Location = new Point(287, 49);
            dataGridViewPembelian.Name = "dataGridViewPembelian";
            dataGridViewPembelian.Size = new Size(446, 411);
            dataGridViewPembelian.TabIndex = 3;

            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.YellowGreen;
            btnKembali.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            btnKembali.ForeColor = Color.White;
            btnKembali.Location = new Point(131, 423);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(137, 37);
            btnKembali.TabIndex = 4;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;

            // 
            // lblJenisObat
            // 
            lblJenisObat.AutoSize = true;
            lblJenisObat.Font = new Font("Yu Gothic UI Semibold", 9.75F, FontStyle.Bold);
            lblJenisObat.Location = new Point(12, 79);
            lblJenisObat.Name = "lblJenisObat";
            lblJenisObat.Size = new Size(78, 17);
            lblJenisObat.TabIndex = 5;
            lblJenisObat.Text = "Jenis Obat :";

            // 
            // lblJumlahObat
            // 
            lblJumlahObat.AutoSize = true;
            lblJumlahObat.Font = new Font("Yu Gothic UI Semibold", 9.75F, FontStyle.Bold);
            lblJumlahObat.Location = new Point(13, 108);
            lblJumlahObat.Name = "lblJumlahObat";
            lblJumlahObat.Size = new Size(92, 17);
            lblJumlahObat.TabIndex = 6;
            lblJumlahObat.Text = "Jumlah Obat :";

            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.BackColor = SystemColors.Control;
            lblJudul.Font = new Font("Yu Gothic UI Semibold", 14.25F, FontStyle.Bold);
            lblJudul.ForeColor = Color.YellowGreen;
            lblJudul.Location = new Point(28, 19);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(178, 25);
            lblJudul.TabIndex = 7;
            lblJudul.Text = "Apotekku Beli Obat";

            // 
            // btnBeli
            // 
            btnBeli.BackColor = Color.YellowGreen;
            btnBeli.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            btnBeli.ForeColor = Color.White;
            btnBeli.Location = new Point(131, 197);
            btnBeli.Name = "btnBeli";
            btnBeli.Size = new Size(136, 36);
            btnBeli.TabIndex = 8;
            btnBeli.Text = "Beli Obat";
            btnBeli.UseVisualStyleBackColor = false;
            btnBeli.Click += btnBeli_Click;

            // 
            // PembelianObatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(802, 517);
            Controls.Add(btnBeli);
            Controls.Add(lblJudul);
            Controls.Add(lblJumlahObat);
            Controls.Add(lblJenisObat);
            Controls.Add(btnKembali);
            Controls.Add(dataGridViewPembelian);
            Controls.Add(btnTambah);
            Controls.Add(txtJumlahObat);
            Controls.Add(cmbJenisObat);
            Name = "PembelianObatForm";
            Text = "Pembelian Obat";

            ((System.ComponentModel.ISupportInitialize)(dataGridViewPembelian)).EndInit();
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
