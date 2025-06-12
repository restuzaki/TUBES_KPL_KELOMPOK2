namespace GUI_KPL
{
    partial class InputTransaksiForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbJenisTransaksi;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.TextBox txtJumlah;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label lblJenis;
        private System.Windows.Forms.Label lblKet;
        private System.Windows.Forms.Label lblJumlah;
        private System.Windows.Forms.Label lblTanggal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbJenisTransaksi = new ComboBox();
            txtKeterangan = new TextBox();
            txtJumlah = new TextBox();
            dtpTanggal = new DateTimePicker();
            btnSimpan = new Button();
            lblJenis = new Label();
            lblKet = new Label();
            lblJumlah = new Label();
            lblTanggal = new Label();
            SuspendLayout();
            // 
            // cmbJenisTransaksi
            // 
            cmbJenisTransaksi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJenisTransaksi.Font = new Font("Yu Gothic UI Semibold", 10.2F, FontStyle.Bold);
            cmbJenisTransaksi.Location = new Point(150, 17);
            cmbJenisTransaksi.Name = "cmbJenisTransaksi";
            cmbJenisTransaksi.Size = new Size(200, 31);
            cmbJenisTransaksi.TabIndex = 1;
            // 
            // txtKeterangan
            // 
            txtKeterangan.Font = new Font("Yu Gothic UI Semibold", 10.2F, FontStyle.Bold);
            txtKeterangan.Location = new Point(150, 57);
            txtKeterangan.Name = "txtKeterangan";
            txtKeterangan.Size = new Size(200, 30);
            txtKeterangan.TabIndex = 3;
            // 
            // txtJumlah
            // 
            txtJumlah.Font = new Font("Yu Gothic UI Semibold", 10.2F, FontStyle.Bold);
            txtJumlah.Location = new Point(150, 97);
            txtJumlah.Name = "txtJumlah";
            txtJumlah.Size = new Size(200, 30);
            txtJumlah.TabIndex = 5;
            // 
            // dtpTanggal
            // 
            dtpTanggal.Font = new Font("Yu Gothic UI Semibold", 10.2F, FontStyle.Bold);
            dtpTanggal.Location = new Point(150, 137);
            dtpTanggal.Name = "dtpTanggal";
            dtpTanggal.Size = new Size(200, 30);
            dtpTanggal.TabIndex = 7;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.YellowGreen;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Font = new Font("Yu Gothic UI Semibold", 10.2F, FontStyle.Bold);
            btnSimpan.ForeColor = Color.White;
            btnSimpan.Location = new Point(150, 180);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(100, 35);
            btnSimpan.TabIndex = 8;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // lblJenis
            // 
            lblJenis.AutoSize = true;
            lblJenis.Font = new Font("Yu Gothic UI Semibold", 10.2F, FontStyle.Bold);
            lblJenis.Location = new Point(20, 20);
            lblJenis.Name = "lblJenis";
            lblJenis.Size = new Size(120, 23);
            lblJenis.TabIndex = 0;
            lblJenis.Text = "Jenis Transaksi";
            // 
            // lblKet
            // 
            lblKet.AutoSize = true;
            lblKet.Font = new Font("Yu Gothic UI Semibold", 10.2F, FontStyle.Bold);
            lblKet.Location = new Point(20, 60);
            lblKet.Name = "lblKet";
            lblKet.Size = new Size(98, 23);
            lblKet.TabIndex = 2;
            lblKet.Text = "Keterangan";
            // 
            // lblJumlah
            // 
            lblJumlah.AutoSize = true;
            lblJumlah.Font = new Font("Yu Gothic UI Semibold", 10.2F, FontStyle.Bold);
            lblJumlah.Location = new Point(20, 100);
            lblJumlah.Name = "lblJumlah";
            lblJumlah.Size = new Size(65, 23);
            lblJumlah.TabIndex = 4;
            lblJumlah.Text = "Jumlah";
            // 
            // lblTanggal
            // 
            lblTanggal.AutoSize = true;
            lblTanggal.Font = new Font("Yu Gothic UI Semibold", 10.2F, FontStyle.Bold);
            lblTanggal.Location = new Point(20, 140);
            lblTanggal.Name = "lblTanggal";
            lblTanggal.Size = new Size(69, 23);
            lblTanggal.TabIndex = 6;
            lblTanggal.Text = "Tanggal";
            // 
            // InputTransaksiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 240);
            Controls.Add(lblJenis);
            Controls.Add(cmbJenisTransaksi);
            Controls.Add(lblKet);
            Controls.Add(txtKeterangan);
            Controls.Add(lblJumlah);
            Controls.Add(txtJumlah);
            Controls.Add(lblTanggal);
            Controls.Add(dtpTanggal);
            Controls.Add(btnSimpan);
            Name = "InputTransaksiForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Input Transaksi";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}