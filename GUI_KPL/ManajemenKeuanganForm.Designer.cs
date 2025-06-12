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
            TombolKembali = new Button();
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
            dgvKeuangan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI Semibold", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvKeuangan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvKeuangan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Yu Gothic UI Semibold", 11F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvKeuangan.DefaultCellStyle = dataGridViewCellStyle2;
            dgvKeuangan.Location = new Point(200, 69);
            dgvKeuangan.Name = "dgvKeuangan";
            dgvKeuangan.RowHeadersWidth = 51;
            dgvKeuangan.Size = new Size(582, 517);
            dgvKeuangan.TabIndex = 1;
            dgvKeuangan.CellContentClick += dgvKeuangan_CellContentClick;
            // 
            // btnTambahTransaksi
            // 
            btnTambahTransaksi.BackColor = Color.YellowGreen;
            btnTambahTransaksi.FlatStyle = FlatStyle.Flat;
            btnTambahTransaksi.Font = new Font("Yu Gothic UI Semibold", 11F, FontStyle.Bold);
            btnTambahTransaksi.ForeColor = Color.White;
            btnTambahTransaksi.Location = new Point(200, 592);
            btnTambahTransaksi.Name = "btnTambahTransaksi";
            btnTambahTransaksi.Size = new Size(181, 40);
            btnTambahTransaksi.TabIndex = 2;
            btnTambahTransaksi.Text = "Tambah Transaksi";
            btnTambahTransaksi.UseVisualStyleBackColor = false;
            btnTambahTransaksi.Click += btnTambahTransaksi_Click;
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic);
            lblJudul.Location = new Point(200, 20);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(327, 41);
            lblJudul.TabIndex = 3;
            lblJudul.Text = "Manajemen Keuangan";
            // 
            // panelKiri
            // 
            panelKiri.BackColor = Color.WhiteSmoke;
            panelKiri.Controls.Add(TombolKembali);
            panelKiri.Controls.Add(pictureBox1);
            panelKiri.Controls.Add(lblApotekku);
            panelKiri.Controls.Add(lblHaloAdmin);
            panelKiri.Dock = DockStyle.Left;
            panelKiri.Location = new Point(0, 0);
            panelKiri.Name = "panelKiri";
            panelKiri.Size = new Size(181, 667);
            panelKiri.TabIndex = 0;
            // 
            // TombolKembali
            // 
            TombolKembali.BackColor = Color.YellowGreen;
            TombolKembali.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold);
            TombolKembali.ForeColor = Color.White;
            TombolKembali.Location = new Point(21, 223);
            TombolKembali.Margin = new Padding(3, 4, 3, 4);
            TombolKembali.Name = "TombolKembali";
            TombolKembali.Size = new Size(117, 53);
            TombolKembali.TabIndex = 27;
            TombolKembali.Text = "Kembali";
            TombolKembali.UseVisualStyleBackColor = false;
            TombolKembali.Click += TombolKembali_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(41, 69);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(85, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lblApotekku
            // 
            lblApotekku.AutoSize = true;
            lblApotekku.Font = new Font("Yu Gothic UI Semibold", 16F, FontStyle.Bold);
            lblApotekku.ForeColor = Color.YellowGreen;
            lblApotekku.Location = new Point(21, 20);
            lblApotekku.Name = "lblApotekku";
            lblApotekku.Size = new Size(135, 37);
            lblApotekku.TabIndex = 0;
            lblApotekku.Text = "Apotekku";
            // 
            // lblHaloAdmin
            // 
            lblHaloAdmin.AutoSize = true;
            lblHaloAdmin.Font = new Font("Yu Gothic UI Semibold", 10F, FontStyle.Bold);
            lblHaloAdmin.Location = new Point(30, 171);
            lblHaloAdmin.Name = "lblHaloAdmin";
            lblHaloAdmin.Size = new Size(103, 23);
            lblHaloAdmin.TabIndex = 2;
            lblHaloAdmin.Text = "Halo, admin";
            // 
            // ManajemenKeuanganForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(830, 667);
            Controls.Add(btnTambahTransaksi);
            Controls.Add(dgvKeuangan);
            Controls.Add(lblJudul);
            Controls.Add(panelKiri);
            Name = "ManajemenKeuanganForm";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Button TombolKembali;
    }
}