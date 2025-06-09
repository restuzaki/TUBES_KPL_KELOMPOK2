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
            this.cmbJenisTransaksi = new System.Windows.Forms.ComboBox();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.txtJumlah = new System.Windows.Forms.TextBox();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.lblJenis = new System.Windows.Forms.Label();
            this.lblKet = new System.Windows.Forms.Label();
            this.lblJumlah = new System.Windows.Forms.Label();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblJenis
            // 
            this.lblJenis.AutoSize = true;
            this.lblJenis.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblJenis.Location = new System.Drawing.Point(20, 20);
            this.lblJenis.Name = "lblJenis";
            this.lblJenis.Size = new System.Drawing.Size(110, 23);
            this.lblJenis.Text = "Jenis Transaksi";
            // 
            // cmbJenisTransaksi
            // 
            this.cmbJenisTransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJenisTransaksi.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbJenisTransaksi.Location = new System.Drawing.Point(150, 17);
            this.cmbJenisTransaksi.Name = "cmbJenisTransaksi";
            this.cmbJenisTransaksi.Size = new System.Drawing.Size(200, 31);
            // 
            // lblKet
            // 
            this.lblKet.AutoSize = true;
            this.lblKet.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKet.Location = new System.Drawing.Point(20, 60);
            this.lblKet.Name = "lblKet";
            this.lblKet.Size = new System.Drawing.Size(92, 23);
            this.lblKet.Text = "Keterangan";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtKeterangan.Location = new System.Drawing.Point(150, 57);
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(200, 30);
            // 
            // lblJumlah
            // 
            this.lblJumlah.AutoSize = true;
            this.lblJumlah.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblJumlah.Location = new System.Drawing.Point(20, 100);
            this.lblJumlah.Name = "lblJumlah";
            this.lblJumlah.Size = new System.Drawing.Size(65, 23);
            this.lblJumlah.Text = "Jumlah";
            // 
            // txtJumlah
            // 
            this.txtJumlah.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtJumlah.Location = new System.Drawing.Point(150, 97);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(200, 30);
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTanggal.Location = new System.Drawing.Point(20, 140);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(72, 23);
            this.lblTanggal.Text = "Tanggal";
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dtpTanggal.Location = new System.Drawing.Point(150, 137);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(200, 30);
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(150, 180);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(100, 35);
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // InputTransaksiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 240);
            this.Controls.Add(this.lblJenis);
            this.Controls.Add(this.cmbJenisTransaksi);
            this.Controls.Add(this.lblKet);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.lblJumlah);
            this.Controls.Add(this.txtJumlah);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.btnSimpan);
            this.Name = "InputTransaksiForm";
            this.Text = "Input Transaksi";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}