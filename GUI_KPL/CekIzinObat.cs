using Apotekku_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUBES_KPL_KELOMPOK2.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI_KPL
{
    public partial class CekIzinObat : Form
    {
        private ObatService _obatService;

        public CekIzinObat()
        {
            InitializeComponent();
            _obatService = new ObatService();
            Load += CekIzinObat_Load;
        }

        private void CekIzinObat_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Terdaftar");
            comboBox1.Items.Add("TidakTerdaftar");
            comboBox1.Items.Add("Kadaluarsa");
        }

        private async void TombolCari_Click(object sender, EventArgs e)
        {
            string idObat = MasukkanObat.Text.Trim();

            if (string.IsNullOrEmpty(idObat))
            {
                MessageBox.Show("Masukkan ID Obat terlebih dahulu.");
                return;
            }

            var obatData = await _obatService.DapatkanObatByIdAsync(idObat);

            if (obatData == null)
            {
                MessageBox.Show("Obat tidak ditemukan.");
                return;
            }

            var obat = new ObatBuilder()
                .AturId(obatData.id)
                .AturNama(obatData.nama)
                .AturStatus(obatData.status)
                .AturHarga(obatData.harga)
                .AturKadaluarsa(obatData.kadaluarsa)
                .AturStok(obatData.stok)
                .Bangun();

            TampilkanData(new List<Obat> { obat });
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
                return;

            string statusTerpilih = comboBox1.SelectedItem.ToString();

            try
            {
                var semuaObat = await _obatService.DapatkanSemuaObatAsync();

                var hasilFilter = semuaObat
                    .Where(o => o.status.ToString().Equals(statusTerpilih, StringComparison.OrdinalIgnoreCase))
                    .Select(o => new ObatBuilder()
                        .AturId(o.id)
                        .AturNama(o.nama)
                        .AturStatus(o.status)
                        .AturHarga(o.harga)
                        .AturKadaluarsa(o.kadaluarsa)
                        .AturStok(o.stok)
                        .Bangun())
                    .ToList();

                TampilkanData(hasilFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data obat:\n" + ex.Message);
            }
        }

        private void TampilkanData(List<Obat> daftarObat)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "id",
                Name = "ID"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nama Obat",
                DataPropertyName = "nama",
                Name = "Nama"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Status",
                DataPropertyName = "status",
                Name = "Status"
            });

            dataGridView1.DataSource = daftarObat;
        }

        private void MasukkanObat_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}