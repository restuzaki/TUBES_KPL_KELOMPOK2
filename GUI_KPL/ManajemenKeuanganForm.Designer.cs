using System.Windows.Forms;
using System.Drawing;

namespace GUI_KPL
{
    partial class ManajemenKeuanganForm
    {
        private DataGridView dgvKeuangan;
        private Button btnTambahTransaksi;
        private Label lblJudul;
        private Panel panelKiri;
        private Label lblApotekku;
        private Label lblHaloAdmin;

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManajemenKeuanganForm));
            dgvKeuangan = new DataGridView();
            btnTambahTransaksi = new Button();
            lblJudul = new Label();
            panelKiri = new Panel();
            pictureBox1 = new PictureBox();
            lblApotekku = new Label();
            lblHaloAdmin = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvKeuangan).BeginInit();
            panelKiri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvKeuangan
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI Semibold", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvKeuangan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvKeuangan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKeuangan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Yu Gothic UI Semibold", 11F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvKeuangan.DefaultCellStyle = dataGridViewCellStyle2;
            dgvKeuangan.Location = new Point(175, 52);
            dgvKeuangan.Margin = new Padding(3, 2, 3, 2);
            dgvKeuangan.Name = "dgvKeuangan";
            dgvKeuangan.Size = new Size(509, 388);
            dgvKeuangan.TabIndex = 1;
            dgvKeuangan.CellContentClick += dgvKeuangan_CellContentClick;
            // 
            // btnTambahTransaksi
            // 
            btnTambahTransaksi.BackColor = Color.YellowGreen;
            btnTambahTransaksi.FlatStyle = FlatStyle.Flat;
            btnTambahTransaksi.Font = new Font("Yu Gothic UI Semibold", 11F, FontStyle.Bold);
            btnTambahTransaksi.ForeColor = Color.White;
            btnTambahTransaksi.Location = new Point(175, 444);
            btnTambahTransaksi.Margin = new Padding(3, 2, 3, 2);
            btnTambahTransaksi.Name = "btnTambahTransaksi";
            btnTambahTransaksi.Size = new Size(158, 30);
            btnTambahTransaksi.TabIndex = 2;
            btnTambahTransaksi.Text = "Tambah Transaksi";
            btnTambahTransaksi.UseVisualStyleBackColor = false;
            btnTambahTransaksi.Click += btnTambahTransaksi_Click;
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic);
            lblJudul.Location = new Point(175, 15);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(260, 32);
            lblJudul.TabIndex = 3;
            lblJudul.Text = "Manajemen Keuangan";
            // 
            // panelKiri
            // 
            panelKiri.BackColor = Color.WhiteSmoke;
            panelKiri.Controls.Add(pictureBox1);
            panelKiri.Controls.Add(lblApotekku);
            panelKiri.Controls.Add(lblHaloAdmin);
            panelKiri.Dock = DockStyle.Left;
            panelKiri.Location = new Point(0, 0);
            panelKiri.Margin = new Padding(3, 2, 3, 2);
            panelKiri.Name = "panelKiri";
            panelKiri.Size = new Size(158, 500);
            panelKiri.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(36, 52);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(74, 63);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lblApotekku
            // 
            lblApotekku.AutoSize = true;
            lblApotekku.Font = new Font("Yu Gothic UI Semibold", 16F, FontStyle.Bold);
            lblApotekku.ForeColor = Color.YellowGreen;
            lblApotekku.Location = new Point(18, 15);
            lblApotekku.Name = "lblApotekku";
            lblApotekku.Size = new Size(111, 30);
            lblApotekku.TabIndex = 0;
            lblApotekku.Text = "Apotekku";
            // 
            // lblHaloAdmin
            // 
            lblHaloAdmin.AutoSize = true;
            lblHaloAdmin.Font = new Font("Yu Gothic UI Semibold", 10F, FontStyle.Bold);
            lblHaloAdmin.Location = new Point(26, 128);
            lblHaloAdmin.Name = "lblHaloAdmin";
            lblHaloAdmin.Size = new Size(84, 19);
            lblHaloAdmin.TabIndex = 2;
            lblHaloAdmin.Text = "Halo, admin";
            // 
            // ManajemenKeuanganForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(726, 500);
            Controls.Add(btnTambahTransaksi);
            Controls.Add(dgvKeuangan);
            Controls.Add(lblJudul);
            Controls.Add(panelKiri);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ManajemenKeuanganForm";
            Text = "Manajemen Keuangan";
            Load += ManajemenKeuanganForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKeuangan).EndInit();
            panelKiri.ResumeLayout(false);
            panelKiri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private PictureBox pictureBox1;
    }
}