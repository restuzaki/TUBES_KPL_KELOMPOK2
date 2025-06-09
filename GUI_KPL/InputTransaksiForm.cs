using System;
using System.Windows.Forms;
using GUI_KPL;

namespace GUI_KPL
{
    public partial class InputTransaksiForm : Form
    {
        public string JenisTransaksi => cmbJenisTransaksi.SelectedItem?.ToString();
        public string Keterangan => txtKeterangan.Text;
        public int Jumlah => int.TryParse(txtJumlah.Text, out var jml) ? jml : 0;
        public DateTime Tanggal => dtpTanggal.Value;

        public InputTransaksiForm()
        {
            InitializeComponent();
            cmbJenisTransaksi.Items.AddRange(new[] { "Pemasukan", "Pengeluaran" });
            cmbJenisTransaksi.SelectedIndex = 0;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Keterangan) || Jumlah <= 0)
            {
                MessageBox.Show("Data tidak valid!");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}