using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Linq;
using Apotekku_API.Models;

namespace TUBES_KPL_KELOMPOK2.Services
{
    public class UserRegister
    {
        private static readonly HttpClient Client = new();
        private const string ApiUrl = "http://localhost:5193/api/User/register";

        public User? Register()
        {
            Console.WriteLine("\n=== Register User Baru ===");

            try
            {
                Console.Write("Nama: ");
                string nama = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nama))
                {
                    Console.WriteLine("Nama tidak boleh kosong.");
                    return null;
                }

                Console.Write("Password: ");
                string password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Password tidak boleh kosong.");
                    return null;
                }

                if (password.Length > 20)
                {
                    Console.WriteLine("Password terlalu panjang. Maksimal 20 karakter.");
                    return null;
                }

                if (!password.Any(char.IsUpper))
                {
                    Console.WriteLine("Password harus mengandung minimal satu huruf kapital.");
                    return null;
                }

                Console.WriteLine("Password valid.");

                var user = new User(nama, password, "Buyer");

                string jsonData = JsonSerializer.Serialize(user);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = Client.PostAsync(ApiUrl, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Registrasi berhasil.");
                }
                else
                {
                    Console.WriteLine("Registrasi gagal. Username mungkin sudah digunakan.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan saat register: {ex.Message}");
            }

            Console.ReadKey();
            return null;
        }
    }
}
