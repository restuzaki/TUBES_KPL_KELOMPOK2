using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Apotekku_API.Models;
using TUBES_KPL_KELOMPOK2.Services;

namespace GUI_KPL
{
    public partial class RiwayatPembelian : Form
    {
        private List<Obat> riwayatPembelian = new();
        private readonly string currentUser;
        private string _jsonPath = @"APOTEKKU_API_Kelompok2\Data\Keuangan.json";

        public RiwayatPembelian(string username)
        {
            InitializeComponent();
            currentUser = username;
            LoadRiwayatPembelian();
        }

        // Load data riwayat pembelian dari file JSON
        private void LoadRiwayatPembelian()
        {
            string filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data",
                "riwayat.json"
            );

            if (!File.Exists(filePath))
            {
                MessageBox.Show(
                    "Belum ada riwayat pembelian.",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            try
            {
                string json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<List<Obat>>(json);

                if (data != null)
                {
                    riwayatPembelian = data;
                    TampilkanDataKeGrid();
                }
                else
                {
                    MessageBox.Show(
                        "Data riwayat tidak valid.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Gagal memuat riwayat: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Tampilkan data riwayat pembelian ke DataGridView
        private void TampilkanDataKeGrid()
        {
            dataGridViewPembelian.DataSource = null;
            dataGridViewPembelian.DataSource = riwayatPembelian
                .Select(o => new
                {
                    ID = o.id,
                    Nama = o.nama,
                    Harga = o.harga,
                    Jumlah = o.stok,
                    Total = o.harga * o.stok
                })
                .ToList();
        }

        // Tombol kembali ke menu user
        private void btnKembali_Click_1(object sender, EventArgs e)
        {
            var user = new User
            {
                Nama = currentUser,
                Role = "Buyer"
            };

            var menuUserForm = new MenuUser(user);
            menuUserForm.FormClosed += (s, args) => this.Close();
            menuUserForm.Show();
            this.Hide();
        }
        private async void ProsesPembelian(string namaPembeli, int totalHarga)
        {
            // ... proses pembelian obat (update stok, dsb)

            // Tambahkan transaksi keuangan
            var transaksi = new TransaksiKeuangan(
                "Pemasukan",
                $"Pembelian obat oleh {namaPembeli}",
                totalHarga,
                DateTime.Now
            );

            // Baca data lama
            List<TransaksiKeuangan> dataKeuangan;
            if (File.Exists(_jsonPath))
            {
                var json = File.ReadAllText(_jsonPath);
                dataKeuangan = JsonSerializer.Deserialize<List<TransaksiKeuangan>>(json) ?? new List<TransaksiKeuangan>();
            }
            else
            {
                dataKeuangan = new List<TransaksiKeuangan>();
            }

            dataKeuangan.Add(transaksi);

            // Simpan ke file
            var jsonBaru = JsonSerializer.Serialize(dataKeuangan, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonPath, jsonBaru);

            // Jika ingin refresh form keuangan:
            // (misal, jika form keuangan sedang terbuka)
            // var formKeuangan = Application.OpenForms["ManajemenKeuanganForm"] as ManajemenKeuanganForm;
            // formKeuangan?.RefreshKeuangan();
        }
    }
}