using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Apotekku_API.Models;

namespace TUBES_KPL_KELOMPOK2.View
{
    public class DataObatView
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public DataObatView()
        {
            _httpClient = new HttpClient();
            _apiUrl = "http://localhost:5193/api/Obat/";
        }

        public async Task<List<Obat>> GetAllObatAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };

                        var data = JsonSerializer.Deserialize<List<Obat>>(content, options);
                        return data ?? new List<Obat>();
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine("Gagal parsing JSON: " + ex.Message);
                        return new List<Obat>();
                    }
                }
                else
                {
                    Console.WriteLine("Gagal mengambil data obat. Status code: " + response.StatusCode);
                    return new List<Obat>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Terjadi kesalahan saat mengambil data: " + ex.Message);
                return new List<Obat>();
            }
        }

        
        public async Task TampilkanDaftarObatAsync()
        {
            var daftarObat = await GetAllObatAsync();

            if (daftarObat.Count == 0)
            {
                Console.WriteLine("Tidak ada data obat yang tersedia.");
                return;
            }

            Console.WriteLine("=== Daftar Obat ===");
            foreach (var obat in daftarObat)
            {
                Console.WriteLine($"ID: {obat.id}, Nama: {obat.nama}, Stok: {obat.stok}, Harga: {obat.harga}");
            }
        }
    }
}
