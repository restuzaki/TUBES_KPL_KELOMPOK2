using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Apotekku_API.Models;
using TUBES_KPL_KELOMPOK2.View;

namespace GUI_KPL
{
    public partial class PembelianObatForm : Form
    {
        private readonly PembelianObat _pembelian;
        private readonly string _currentUser;

        public PembelianObatForm(string currentUser)
        {
            InitializeComponent();
            _pembelian = new PembelianObat();
            _currentUser = currentUser;

            LoadObatDropdown();
            RefreshGrid();
        }

        private void LoadObatDropdown()
        {
            var obats = _pembelian.GetObatsFromAPI();
            cmbJenisObat.Items.Clear();

            foreach (var obat in obats)
            {
                cmbJenisObat.Items.Add(obat.nama);
            }
        }

        private List<object> GetPembelianGridData()
        {
            return _pembelian.GetObats()
                .Select(o => new
                {
                    Nama = o.nama,
                    Harga = o.harga,
                    Jumlah = o.stok,
                    Total = o.harga * o.stok
                }).ToList<object>();
        }

        private void RefreshGrid()
        {
            dataGridViewPembelian.DataSource = null;
            dataGridViewPembelian.DataSource = GetPembelianGridData();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            string namaObat = cmbJenisObat.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(namaObat))
            {
                MessageBox.Show("Silakan pilih jenis obat.");
                return;
            }

            if (!int.TryParse(txtJumlahObat.Text, out int jumlah) || jumlah <= 0)
            {
                MessageBox.Show("Masukkan jumlah obat yang valid.");
                return;
            }

            try
            {
                int harga = _pembelian.GetHargaObat(namaObat);
                _pembelian.TambahObat(namaObat, jumlah, harga, DateTime.Now);
                RefreshGrid();
                MessageBox.Show("Obat ditambahkan ke keranjang.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBeli_Click(object sender, EventArgs e)
        {
            try
            {
                SimpanRiwayat(_pembelian.GetObats().ToList());
                MessageBox.Show("Obat berhasil dibeli!", "Pembelian Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewPembelian.DataSource = null;
                dataGridViewPembelian.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan riwayat: {ex.Message}", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            var currentUser = new User
            {
                Nama = _currentUser,
                Role = "Buyer"
            };

            var menuUser = new MenuUser(currentUser);
            menuUser.FormClosed += (s, args) => this.Close();
            menuUser.Show();
            this.Hide();
        }

        private void SimpanRiwayat(List<Obat> daftarPembelian)
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            string filePath = Path.Combine(folderPath, "riwayat.json");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(daftarPembelian, options);

            File.WriteAllText(filePath, json);
        }
    }
}
