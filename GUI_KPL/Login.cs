using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Apotekku_API.Models; 

namespace GUI_KPL
{
    public partial class Login : Form
    {
        private readonly string jsonFilePath = "Data/User.json";

        public Login()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Nama tidak boleh kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password tidak boleh kosong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var users = LoadUsers();

            var user = users.FirstOrDefault(u =>
                u.Nama.Equals(nama, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            if (user != null)
            {
                MessageBox.Show($"Login berhasil. Selamat datang, {user.Nama}!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // (ini nanti kemenu home sesuai dia user atau apa)
            }
            else
            {
                MessageBox.Show("Nama atau password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<User> LoadUsers()
        {
            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    MessageBox.Show("File data tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<User>();
                }

                string json = File.ReadAllText(jsonFilePath);
                return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membaca file JSON: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<User>();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
