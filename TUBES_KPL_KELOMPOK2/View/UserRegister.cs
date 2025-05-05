using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Apotekku_API.Models;

namespace TUBES_KPL_KELOMPOK2.Services
{
    public class UserRegister
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string apiUrl = "http://localhost:5193/api/User/register";

        public User? Register()
        {
            Console.WriteLine("\n=== Register User Baru ===");

            Console.Write("Nama: ");
            string nama = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            string role = "Buyer";
            var user = new User(nama, password, role);

            string jsonData = JsonSerializer.Serialize(user);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                var response = client.PostAsync(apiUrl, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Registrasi berhasil!");
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

            Console.WriteLine("\nTekan sembarang tombol untuk kembali ke menu register...");
            Console.ReadKey();
            return null;
        }
    }
}
