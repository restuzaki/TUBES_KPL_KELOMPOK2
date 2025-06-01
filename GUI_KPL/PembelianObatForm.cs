using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apotekku_API.Models;
using TUBES_KPL_KELOMPOK2.View;

namespace GUI_KPL
{
    public partial class PembelianObatForm: Form
    {
        private PembelianObat _pembelian;
        private string _currentUser;
        public PembelianObatForm(string currentUser)
        {
            InitializeComponent();
            _pembelian = new PembelianObat();
            LoadObatDropdown();
            LoadPembelianGrid();
            _currentUser = currentUser;
        }
        private void LoadObatDropdown()
        {
            var obats = _pembelian.GetObatsFromAPI();
            comboBox1.Items.Clear();
            foreach (var obat in obats)
            {
                comboBox1.Items.Add(obat.nama);
            }
        }
        private void LoadPembelianGrid()
        {
            var pembelianData = _pembelian.GetObats()
                .Select(o => new
                {
                    Nama = o.nama,
                    Harga = o.harga,
                    Jumlah = o.stok,
                    Total = o.harga * o.stok
                }).ToList();

            dataGridView1.DataSource = pembelianData;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string namaObat = comboBox1.SelectedItem?.ToString();
            if (!int.TryParse(textBox1.Text, out int jumlah) || jumlah <= 0)
            {
                MessageBox.Show("Masukkan jumlah obat yang valid.");
                return;
            }

            int harga = _pembelian.GetHargaObat(namaObat);
            try
            {
                _pembelian.TambahObat(namaObat, jumlah, harga, DateTime.Now);
                RefreshGrid();
                MessageBox.Show("Obat ditambahkan ke keranjang.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            SimpanRiwayat(_pembelian.GetObats().ToList());
         
            MessageBox.Show("Obat Berhasil Dibeli!", "Pembelian Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear(); 

        }
        private void button2_Click(object sender, EventArgs e)
        {
            User currentUser = new User
            {
                Nama = _currentUser,
                Role = "Buyer"
            };
            MenuUser menuUser = new MenuUser(currentUser);
            menuUser.Show();
            this.Hide();

        }
        private void RefreshGrid()
        {
            var data = _pembelian.GetObats().Select(o => new
            {
                Nama = o.nama,
                Harga = o.harga,
                Jumlah = o.stok,
                Total = o.harga * o.stok
            }).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = data;
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
