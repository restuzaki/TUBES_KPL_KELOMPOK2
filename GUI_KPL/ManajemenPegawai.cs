using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Apotekku_API.Models;
using TUBES_KPL_KELOMPOK2.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace GUI_KPL
{
    public partial class ManajemenPegawai : Form
    {
        public ManajemenPegawai()
        {
            InitializeComponent();
        }

        private void ManajemenPegawai_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Aktif");
            comboBox1.Items.Add("TidakAktif");
            comboBox1.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MasukkanNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void MasukkanPegawai_TextChanged(object sender, EventArgs e)
        {

        }

        private void MasukkanJabatan_TextChanged(object sender, EventArgs e)
        {

        }

        private async void TombolCariP_Click(object sender, EventArgs e)
        {
            var id = MasukkanPegawai.Text.Trim();
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Masukkan ID pegawai terlebih dahulu.");
                return;
            }

            var service = new PegawaiService();
            var pegawai = await service.AmbilPegawaiByIdAsync(id);

            if (pegawai != null)
            {
                MasukkanNama.Text = pegawai.nama;
                MasukkanJabatan.Text = pegawai.jabatan;
                comboBox1.SelectedItem = pegawai.status;

                dataGridView1.DataSource = new List<Pegawai> { pegawai };
            }
            else
            {
                MessageBox.Show("Pegawai tidak ditemukan.");
            }
        }

        private async void TombolHapus_Click(object sender, EventArgs e)
        {
            var id = MasukkanPegawai.Text.Trim();
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Masukkan ID pegawai terlebih dahulu.");
                return;
            }

            var hasil = await new PegawaiService().HapusPegawaiAsync(id);
            if (hasil)
            {
                MessageBox.Show("Pegawai berhasil dihapus.");
                TombolSemua_Click(sender, e); // Refresh tabel
            }
            else
            {
                MessageBox.Show("Gagal menghapus pegawai. Cek ID.");
            }
        }

        private async void TombolTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MasukkanNama.Text) || string.IsNullOrWhiteSpace(MasukkanJabatan.Text))
            {
                MessageBox.Show("Nama dan Jabatan harus diisi.");
                return;
            }

            var pegawai = new Pegawai
            {
                id = MasukkanPegawai.Text.Trim(),
                nama = MasukkanNama.Text.Trim(),
                jabatan = MasukkanJabatan.Text.Trim(),
                status = (PegawaiStatus)Enum.Parse(typeof(PegawaiStatus), comboBox1.SelectedItem?.ToString())
            };

            await new PegawaiService().TambahPegawaiAsync(pegawai);
            MessageBox.Show("Pegawai berhasil ditambahkan.");
            TombolSemua_Click(sender, e);
        }

        private async void TombolUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MasukkanPegawai.Text))
            {
                MessageBox.Show("Masukkan ID pegawai untuk update.");
                return;
            }

            var pegawai = new Pegawai
            {
                id = MasukkanPegawai.Text.Trim(),
                nama = MasukkanNama.Text.Trim(),
                jabatan = MasukkanJabatan.Text.Trim(),
                status = (PegawaiStatus)Enum.Parse(typeof(PegawaiStatus), comboBox1.SelectedItem?.ToString())
            };

            await new PegawaiService().PerbaruiPegawaiAsync(pegawai);
            MessageBox.Show("Pegawai berhasil diperbarui.");
            TombolSemua_Click(sender, e);
        }

        private async void TombolSemua_Click(object sender, EventArgs e)
        {
            var service = new PegawaiService();
            var pegawaiList = await service.AmbilSemuaPegawaiAsync();
            dataGridView1.DataSource = pegawaiList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TombolKembali_Click(object sender, EventArgs e)
        {
            User currentUser = new User
            {
                Nama = "Admin",
                Role = "Admin"
            };

            var menuAdmin = new MenuAdmin(currentUser);
            menuAdmin.Show();
            this.Hide();
        }
    }
}
