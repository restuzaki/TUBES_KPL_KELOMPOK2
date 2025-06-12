using System;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using TUBES_KPL_KELOMPOK2.Services;
using Apotekku_API.Models;

namespace GUI_KPL
{
    public partial class ManajemenKeuanganForm : Form
    {
        private string _jsonPath = @"APOTEKKU_API_Kelompok2\Data\Keuangan.json";
        private readonly string currentUser;
        private List<TransaksiKeuangan> _dataKeuangan = new();
        private KeuanganService _keuanganService = new KeuanganService();

        public ManajemenKeuanganForm()
        {
            InitializeComponent();
            Directory.CreateDirectory(Path.GetDirectoryName(_jsonPath));
        }

        private void ManajemenKeuanganForm_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_jsonPath));
            _dataKeuangan = BacaDataKeuangan();
            dgvKeuangan.AutoGenerateColumns = true; // Tambahkan baris ini
            dgvKeuangan.DataSource = null;
            dgvKeuangan.DataSource = _dataKeuangan;
        }

        private async void btnTambahTransaksi_Click(object sender, EventArgs e)
        {
            var inputForm = new InputTransaksiForm();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                var transaksi = new TransaksiKeuangan(
                    inputForm.JenisTransaksi,
                    inputForm.Keterangan,
                    inputForm.Jumlah,
                    inputForm.Tanggal);

                await _keuanganService.TambahTransaksiAsync(transaksi);

                // Update list & simpan ke file
                _dataKeuangan.Add(transaksi);
                SimpanDataKeuangan(_dataKeuangan);

                dgvKeuangan.DataSource = null;
                dgvKeuangan.DataSource = _dataKeuangan;
            }
        }

        private List<TransaksiKeuangan> BacaDataKeuangan()
        {
            if (!File.Exists(_jsonPath))
                return new List<TransaksiKeuangan>();

            string json = File.ReadAllText(_jsonPath);
            var data = JsonSerializer.Deserialize<List<TransaksiKeuangan>>(json);
            return data ?? new List<TransaksiKeuangan>();
        }

        public void SimpanDataKeuangan(List<TransaksiKeuangan> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            // Pastikan direktori sudah ada
            Directory.CreateDirectory(Path.GetDirectoryName(_jsonPath));
            File.WriteAllText(_jsonPath, json);
        }

        // Method ini bisa dipanggil dari luar untuk refresh data
        public void RefreshKeuangan()
        {
            _dataKeuangan = BacaDataKeuangan();
            dgvKeuangan.DataSource = null;
            dgvKeuangan.DataSource = _dataKeuangan;
        }

        private void pictureBoxAdmin_Click(object sender, EventArgs e)
        {

        }

        private void dgvKeuangan_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
