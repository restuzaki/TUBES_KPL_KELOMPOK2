using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using Apotekku_API.Models;

namespace GUI_KPL
{
    public partial class BacaResepTampilkan : Form
    {
        private readonly string _currentUser;
        private PembelianObat _BacaResepTampilkan = new PembelianObat();

        public BacaResepTampilkan()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = _BacaResepTampilkan.GetObatsFromAPI().ToList();
        }

        private void dgvObat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "status" && e.Value != null)
            {
                var status = (ObatStatus)e.Value;
                if (status == ObatStatus.Kadaluarsa)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
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
