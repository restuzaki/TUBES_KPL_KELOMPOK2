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

namespace GUI_KPL
{
    public partial class MenuUser : Form
    {
        private User _currentUser;

        public MenuUser(User user)
        {
            InitializeComponent();
            _currentUser = user;

            
            label2.Text = $"Halo, {_currentUser.Nama}";
            label3.Text = $"Selamat Datang, {_currentUser.Nama}";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout berhasil.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ini ganti ke arah masing masing bagiannya
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string User = _currentUser.Nama;
            PembelianObatForm pembelianObatForm = new PembelianObatForm(User);
            pembelianObatForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ini ganti ke arah masing masing bagiannya
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BacaResepTampilkan bacaResepTampilkan = new BacaResepTampilkan();
            bacaResepTampilkan.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BacaResep bacaResep = new BacaResep();
            bacaResep.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string User = _currentUser.Nama;
            RiwayatPembelian riwayatPembelian = new RiwayatPembelian(User);
            riwayatPembelian.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

