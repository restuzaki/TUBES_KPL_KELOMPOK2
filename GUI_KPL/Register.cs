using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_KPL
{
    public partial class Register : Form
    {
        private static readonly HttpClient _httpClient = new();
        private const string ApiUrl = "http://localhost:5193/api/User/register";

        public Register()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text.Trim();
            var password = textBox2.Text;
            var confirmPassword = textBox3.Text;

            if (!IsInputValid(username, password, confirmPassword))
                return;

            var user = new
            {
                nama = username,
                password = password,
                role = "Buyer"
            };

            var isSuccess = await RegisterUserAsync(user);

            if (isSuccess)
            {
                MessageBox.Show("Registrasi berhasil.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                
                // new Login().Show();
            }
            else
            {
                MessageBox.Show("Registrasi gagal. Username mungkin sudah digunakan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsInputValid(string username, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                ShowError("Username tidak boleh kosong.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowError("Password tidak boleh kosong.");
                return false;
            }

            if (password.Length > 20)
            {
                ShowError("Password terlalu panjang. Maksimal 20 karakter.");
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                ShowError("Password harus mengandung minimal satu huruf kapital.");
                return false;
            }

            if (password != confirmPassword)
            {
                ShowError("Konfirmasi password tidak cocok.");
                return false;
            }

            return true;
        }

        private async Task<bool> RegisterUserAsync(object user)
        {
            try
            {
                string json = JsonSerializer.Serialize(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(ApiUrl, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                ShowError($"Terjadi kesalahan saat registrasi: {ex.Message}");
                return false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle karakter bintang
            bool showPassword = checkBox1.Checked;
            textBox2.UseSystemPasswordChar = !showPassword;
            textBox3.UseSystemPasswordChar = !showPassword;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            // Sembunyikan password saat pertama kali form dibuka
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            // new Login().Show();
            this.Hide();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Optional event handlers (kosong jika tidak dipakai)
        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
