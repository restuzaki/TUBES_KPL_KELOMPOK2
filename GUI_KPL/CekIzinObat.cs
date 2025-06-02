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
        private async void CekIzinObat_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Terdaftar");
            comboBox1.Items.Add("TidakTerdaftar");
            comboBox1.Items.Add("Kadaluarsa");
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

        private async void TombolCari_Click(object sender, EventArgs e)
        {
            string idObat = MasukkanObat.Text.Trim();

            if (string.IsNullOrEmpty(idObat))
            {
                MessageBox.Show("Masukkan ID Obat terlebih dahulu.");
                return;
            }

            var obat = await _obatService.DapatkanObatByIdAsync(idObat);


            if (obat == null)
            {
                MessageBox.Show("Obat tidak ditemukan.");
                return;
            }

            
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

            dataGridView1.DataSource = new List<Obat> { obat };
        }


        private void MasukkanObat_TextChanged(object sender, EventArgs e)
        {

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
                return;

            string statusTerpilih = comboBox1.SelectedItem.ToString();

            try
            {
                var semuaObat = await _obatService.DapatkanSemuaObatAsync();

                var hasilFilter = semuaObat.FindAll(o =>
                    o.status.ToString().Equals(statusTerpilih, StringComparison.OrdinalIgnoreCase));

                dataGridView1.DataSource = hasilFilter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data obat:\n" + ex.Message);
            }
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
    }
}
