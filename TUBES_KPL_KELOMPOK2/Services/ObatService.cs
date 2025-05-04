using Apotekku_API.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TUBES_KPL_KELOMPOK2.Services
{
    public class ObatService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonOptions;

        public ObatService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5193/api/");

            _jsonOptions = new JsonSerializerOptions
            {
                //Converters = { new ObatStatusConverter() }
            };
        }

        public async Task<List<Obat>> GetAllObatAsync()
        {
            var response = await _client.GetAsync("obat");
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Obat>>(json, _jsonOptions);
        }

        public async Task<Obat> GetObatByIdAsync(string id)
        {
            var response = await _client.GetAsync($"obat/{id}");
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Obat>(json, _jsonOptions);
        }
    }
}