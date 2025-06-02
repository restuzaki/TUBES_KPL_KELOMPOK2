using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apotekku_API.Models;
using TUBES_KPL_KELOMPOK2.View;

namespace GUI_KPL
{
    public partial class BacaResep : Form
    {
        private readonly string _currentUser;
        private PembelianObat _BacaResepTampilkan = new PembelianObat();
        private List<Obat> _allObats = new List<Obat>();

        public BacaResep()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            _allObats = _BacaResepTampilkan.GetObatsFromAPI().ToList();
            dataGridView1.DataSource = _allObats.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim().ToLower();

            var hasilPencarian = _allObats
                .Where(o =>
                    (!string.IsNullOrEmpty(o.nama) && o.nama.ToLower().Contains(input)) ||
                    (!string.IsNullOrEmpty(o.id) && o.id.ToLower().Equals(input)) // ID is a string now
                )
                .ToList();

            RefreshGrid(hasilPencarian); // Display only the searched items
        }

        private void RefreshGrid(List<Obat> obats)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = obats
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


        private void button3_Click(object sender, EventArgs e)
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
    }
}
